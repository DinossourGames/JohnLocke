using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour, InputActions.IMittensBossFightActions
{
	[Header("Shooting")]
	[SerializeField] private float cadence;
	[SerializeField] private int totalAmmo;

	[Header("Reloading")]
	[SerializeField] private float reloadTime;
	[SerializeField] private Color32 _reloadingColor = new Color32(130, 13, 0, 255);

	[Header("Spawing")]
	[FormerlySerializedAs("bullet")]
	[SerializeField] private GameObject bulletPrefab;
	[FormerlySerializedAs("shotPoint")]
	[SerializeField] private GameObject shootSpawnPoint;

	private Camera _camera;
	private Player _player;
	private SpriteRenderer _spriteRenderer;
	
	private InputActions _inputActions;
	
	private Vector2 _aimDirection;
	
	private int _currentAmmo;
	private bool _isShooting;
	private bool _isReloading;
	private float _nextShootTime;

	private void Awake()
	{
		_camera = Camera.main;
		_player = FindObjectOfType<Player>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		
		_inputActions = new InputActions();
		_inputActions.MittensBossFight.Aim.performed += ctx => Internal_SetAimDirection(ctx.ReadValue<Vector2>());
		_inputActions.MittensBossFight.Shoot.performed += ctx => _isShooting = true;
		_inputActions.MittensBossFight.Shoot.canceled += ctx => _isShooting = false;
	}

	private void Start()
	{
		_currentAmmo = totalAmmo;
		_spriteRenderer.color = Color.white;
	}

	private void Update()
	{
		UpdateAimDirection();
		UpdateFacingDirection();
		
		if (_isShooting && !_isReloading)
			Shoot();
	}

	private void OnEnable()
	{
		_isReloading = false;
		_inputActions.MittensBossFight.Enable();
	}

	private void OnDisable()
	{
		_inputActions.MittensBossFight.Disable();
	}

	private void UpdateFacingDirection()
	{
		Vector2 dir = _aimDirection * _player.facingDirection;
		float aimAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler(Vector3.forward * aimAngle);
	}

	private void Shoot()
	{
		if (_isReloading || Time.time < _nextShootTime)
			return;

		if (_currentAmmo <= 0)
		{
			StartCoroutine(ReloadRoutine());
			return;
		}

		_currentAmmo--;
		_nextShootTime = Time.time + cadence;

		float aimAngle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.Euler(Vector3.forward * aimAngle);
		
		Instantiate(bulletPrefab, shootSpawnPoint.transform.position, rotation);
	}
	
	private void Reload()
	{
		if (!_isReloading)
			StartCoroutine(ReloadRoutine());
	}

	private IEnumerator ReloadRoutine()
	{
		// Begin
		_isReloading = true;
		_spriteRenderer.color = _reloadingColor;
		
		// Wait
		yield return new WaitForSeconds(reloadTime);
		
		// Complete
		_isReloading = false;
		_currentAmmo = totalAmmo;
		_spriteRenderer.color = Color.white;
	}

	private void UpdateAimDirection()
	{
		if (!Player.isDesktopInput)
			return;

		Vector2 mousePos = Mouse.current.position.ReadValue();
		Vector2 selfScreenPoint = _camera.WorldToScreenPoint(this.transform.position);
		Internal_SetAimDirection((mousePos - selfScreenPoint).normalized);
	}

	private void Internal_SetAimDirection(Vector2 dir)
	{
		_aimDirection = dir;
	}


	void InputActions.IMittensBossFightActions.OnAim(InputAction.CallbackContext context) => Internal_SetAimDirection(context.ReadValue<Vector2>());
	void InputActions.IMittensBossFightActions.OnReload(InputAction.CallbackContext context) => Reload();

#region Useless Garbage

	void InputActions.IMittensBossFightActions.OnMove(InputAction.CallbackContext context) => Nothing();
	void InputActions.IMittensBossFightActions.OnShoot(InputAction.CallbackContext context) => Nothing();
	void InputActions.IMittensBossFightActions.OnDash(InputAction.CallbackContext context) => Nothing();
	void InputActions.IMittensBossFightActions.OnSwitchWeapons(InputAction.CallbackContext context) => Nothing();
	void InputActions.IMittensBossFightActions.OnRestart(InputAction.CallbackContext context) => Nothing();
	void InputActions.IMittensBossFightActions.OnStart(InputAction.CallbackContext context) => Nothing();
	
	[EditorBrowsable(EditorBrowsableState.Never)]
	private static void Nothing()
	{
		
	}

#endregion
}