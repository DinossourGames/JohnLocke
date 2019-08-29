using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private InputActions Controls;
    private Vector2 moveInput;
    private CircleCollider2D hitbox;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer backSprite;
    [SerializeField] private Vector2 boundsMin;
    [SerializeField] private Vector2 boundsMax;
    private Vector2 playerSize;
    [SerializeField] private float dashTime; //Moment the dash will be available
    [SerializeField] private float dashDelay; //Cooldown of the dash
    private double endDash; //Moment the dash ends
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashSpeedMod;
    private TrailRenderer trail;
    private bool invulnerable;
    [SerializeField] private int totalHealth;
    [SerializeField] private int health;
    private PlayerInput _pi;
    public static bool device;
    private bool isFacingRight;
    private float angle;
    private Vector2 direction1;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        hitbox = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        var bounds = backSprite.bounds;
        boundsMin = bounds.min;
        boundsMax = bounds.max;
        playerSize = sprite.bounds.extents;
        health = totalHealth;
        _pi = GetComponent<PlayerInput>();
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetMouseInput();
        Flip();
        print(angle);
        device = _pi.devices[0].device.displayName == "Mouse" || _pi.devices[0].device.displayName == "Keyboard";
        if (Time.time > dashTime)
            trail.enabled = true;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Time.time > endDash)
        {
            direction = moveInput;
        }

        rb.velocity = direction * speed;
    }

    private void LateUpdate()
    {
        var position = transform.position;
        position.x = Mathf.Clamp(position.x, boundsMin.x + playerSize.x, boundsMax.x - playerSize.x);
        position.y = Mathf.Clamp(position.y, boundsMin.y + playerSize.y, boundsMax.y - playerSize.y);
        transform.position = position;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Disabled:
                break;
            case InputActionPhase.Waiting:
                break;
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                MovePerformed(context);
                break;
            case InputActionPhase.Canceled:
                MoveCancelled();
                break;
        }
    }

    private void MoveCancelled()
    {
        moveInput = Vector2.zero;
    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (Time.time > dashTime)
            StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        endDash = Time.time + dashDuration;
        speed *= dashSpeedMod;
        hitbox.enabled = false;
        dashTime = Time.time + dashDelay;
        sprite.enabled = false;
        yield return new WaitForSeconds(dashDuration);
        speed /= dashSpeedMod;
        hitbox.enabled = true;
        trail.enabled = false;
        sprite.enabled = true;
    }

    private void GetMouseInput()
    {
        if (!Player.device) return;

        var dir = Mouse.current.position.ReadValue();

        var mouse = Camera.main.ScreenToWorldPoint(dir);
        direction1 = new Vector2
        {
            x = mouse.x - transform.position.x,
            y = mouse.y - transform.position.y
        };

        angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
    }

    private void Flip()
    {
        anim.SetBool("isWalking", moveInput != Vector2.zero);
        
        if (angle > -90 && angle <= 90 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            
        }
         if( (angle > 90 || angle <= 180 ) && (angle <= -90) &&
                 isFacingRight)
        {
            isFacingRight = false;
            var scale = transform.localScale;
            transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        }
         anim.SetBool("isFacingRight", isFacingRight);
    }

    public void TakeDamage(int damageAmount)
    {
        if (!invulnerable)
        {
            health -= damageAmount;
            StartCoroutine(Invulnerability(3));
            if (health <= 0)
                Destroy(gameObject);
        }
    }

    private IEnumerator Invulnerability(float time)
    {
        invulnerable = true;
        sprite.color = new Color32(254, 39, 90, 192);
        yield return new WaitForSeconds(time);
        sprite.color = Color.white;
        invulnerable = false;
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSwitchWeapons(InputAction.CallbackContext context)
    {
    }

    public void OnAim(InputAction.CallbackContext context)
    {
        AimPerformed(context);
    }

    private void AimPerformed(InputAction.CallbackContext context)
    {
        direction1 = context.ReadValue<Vector2>();
        angle = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
    }
}