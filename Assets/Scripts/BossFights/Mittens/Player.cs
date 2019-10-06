using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

// TODO: Implementar o cooldown de Dash
public class Player : MonoBehaviour, InputActions.IMittensBossFightActions
{
	[SerializeField] private Image[] hearts;

	[Header("Movement")]
	[FormerlySerializedAs("speed")]
	[SerializeField] private float movementSpeed;
	[SerializeField] private SpriteRenderer backSprite;

	[Space]
	[SerializeField] private Vector2 boundsMin;
	[SerializeField] private Vector2 boundsMax;

	[Header("Dash")]
	[SerializeField] private float dashDelay; //Cooldown of the dash
	[SerializeField] private float dashDuration;
	[SerializeField] private float dashSpeedMod;
	
	[Header("Health")]
	[SerializeField] private int totalHealth;
	[SerializeField] private int currentHealth;
	[Space]
	[SerializeField] Color32 invulnerableColor = new Color32(254, 39, 90, 192);

	private Camera _camera;
	private Animator _anim;
	private Rigidbody2D _rigidbody;
	private PlayerInput _playerInput;
	private TrailRenderer _trailRenderer;
	private SpriteRenderer _spriteRenderer;
	private CircleCollider2D _circleCollider;

	private Vector2 _dashDirection;
	private Vector2 _moveDirection;
	private Vector2 _playerSize;

	private bool _isDashing;
	private bool _isInvulnerable;

	private float _aimAngle;
	public int facingDirection { get; private set; }

	public static bool isDesktopInput;
	private static readonly int k_isWalking = Animator.StringToHash("isWalking");
	private static readonly int k_facingRight = Animator.StringToHash("isFacingRight");

	private void Awake()
	{
		_camera = Camera.main;
		_anim = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_playerInput = GetComponent<PlayerInput>();
		_trailRenderer = GetComponent<TrailRenderer>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_circleCollider = GetComponent<CircleCollider2D>();
	}

	private void Start()
	{
		currentHealth = totalHealth;
		facingDirection = 1;

		Bounds bounds = backSprite.bounds;
		boundsMin = bounds.min;
		boundsMax = bounds.max;
		_playerSize = _spriteRenderer.bounds.extents;
	}

	private void Update()
	{
		UpdateHealth();
		UpdateAimAngle();
		UpdateFacingDirection();

		_anim.SetBool(k_isWalking, _moveDirection.sqrMagnitude > 0);

		string deviceDisplayName = _playerInput.devices[0].device.displayName;
		isDesktopInput = deviceDisplayName == "Mouse" || deviceDisplayName == "Keyboard";
	}

	private void FixedUpdate()
	{
		UpdateMovement();
	}

	private void LateUpdate()
	{
		var position = transform.position;
		position.x = Mathf.Clamp(position.x, boundsMin.x + _playerSize.x, boundsMax.x - _playerSize.x);
		position.y = Mathf.Clamp(position.y, boundsMin.y + _playerSize.y, boundsMax.y - _playerSize.y);
		transform.position = position;
	}

	private void UpdateHealth()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			hearts[i].color = i >= currentHealth ? Color.black : Color.white;
		}
	}

	private void UpdateAimAngle()
	{
		if (!isDesktopInput)
			return;

		Vector2 mousePos = Mouse.current.position.ReadValue();
		Vector2 selfScreenPoint = _camera.WorldToScreenPoint(this.transform.position);

		Vector2 dir = (mousePos - selfScreenPoint).normalized;
		_aimAngle = Mathf.Repeat(Mathf.Atan2(dir.x, dir.y), Mathf.PI * 2);
	}

	private void UpdateFacingDirection()
	{
		float aimHorizontalDir = Mathf.Sign(Mathf.PI - _aimAngle);

		// Is Aiming to same direction
		if (aimHorizontalDir == facingDirection)
			return;

		facingDirection = (int) aimHorizontalDir;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;

		_anim.SetBool(k_facingRight, facingDirection > 0);
	}

	private void UpdateMovement()
	{
		Vector2 dir = _isDashing ? _dashDirection : _moveDirection;
		_rigidbody.velocity = dir * movementSpeed;
	}

	public void TakeDamage(int damageAmount)
	{
		if (_isInvulnerable)
			return;

		currentHealth -= damageAmount;
		this.StartCoroutine(InvulnerabilityRoutine(3));
		if (currentHealth <= 0)
		{
			Destroy(this.gameObject);
			SceneManager.LoadScene("GameOverMittens");
		}
	}

	private IEnumerator DashRoutine()
	{
		Begin();
		yield return new WaitForSeconds(dashDuration);
		Completed();

		void Begin()
		{
			_isDashing = true;
			movementSpeed *= dashSpeedMod;
			_trailRenderer.enabled = false;
			_circleCollider.enabled = false;
			_spriteRenderer.enabled = false;
		}

		void Completed()
		{
			_isDashing = false;
			movementSpeed /= dashSpeedMod;
			_trailRenderer.enabled = true;
			_circleCollider.enabled = true;
			_spriteRenderer.enabled = true;
		}
	}

	private IEnumerator InvulnerabilityRoutine(float time)
	{
		_isInvulnerable = true;
		_spriteRenderer.color = invulnerableColor;
		yield return new WaitForSeconds(time);
		_spriteRenderer.color = Color.white;
		_isInvulnerable = false;
	}

#region InputActions

	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.phase == InputActionPhase.Performed)
			_moveDirection = context.ReadValue<Vector2>();
		else if (context.phase == InputActionPhase.Canceled)
			_moveDirection = Vector2.zero;
	}

	public void OnDash(InputAction.CallbackContext context)
	{
		if (_isDashing || Mathf.Approximately(0, _moveDirection.sqrMagnitude))
			return;

		_dashDirection = _moveDirection;
		StartCoroutine(DashRoutine());
	}

	public void OnAim(InputAction.CallbackContext context)
	{
		AimPerformed(context);
	}

	public void OnRestart(InputAction.CallbackContext context)
	{
		SceneManager.Restart();
	}

	public void OnStart(InputAction.CallbackContext context)
	{
		SceneManager.LoadScene("MainMenu");
	}

	private void AimPerformed(InputAction.CallbackContext context)
	{
		Vector2 aimDir = context.ReadValue<Vector2>();
		_aimAngle = Mathf.Repeat(Mathf.Atan2(aimDir.x, aimDir.y), Mathf.PI * 2);
	}
	
	public void OnShoot(InputAction.CallbackContext context)
	{
		Debug.LogException(new NotImplementedException());
	}
	
	public void OnReload(InputAction.CallbackContext context)
	{
		Debug.LogException(new NotImplementedException());
	}

	public void OnSwitchWeapons(InputAction.CallbackContext context)
	{
		Debug.LogException(new NotImplementedException());
	}
	
#endregion
}