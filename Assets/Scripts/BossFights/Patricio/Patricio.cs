using DS4_Wrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class Patricio : MonoBehaviour
{
    Rigidbody2D rbd;
    Gamepad gamepad;
    [SerializeField, Header("MOVEMENT")] private float speed = 300;
    [SerializeField] private Vector2 movement;
    [SerializeField] private bool jump;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool freezeMovement;


    [SerializeField, Header("GROUND CHECKING"), Space]
    private bool isGrounded;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Vector2 lastPostition;
    [SerializeField] private float distance;


    [SerializeField, Space, Header("ABILITIES")]
    private bool staring;

    [SerializeField] private bool invunerable;
    [SerializeField] private bool isInv;
    [SerializeField] private bool invunerableLocker;

    [SerializeField, Space, Header("SHOOTS")]
    private bool special;

    [SerializeField] private bool shoot;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootDelay;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private Vector2 vectorOffset;
    [SerializeField] private float offset;
    [SerializeField, Range(0f, .24f)] private float deadZone;

    [SerializeField, Space] private Vector2 movementNormalized;
    [SerializeField] private bool parry;
    [SerializeField] private List<GameObject> parryed;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Invulnerable();
        Shoot();

        lastPostition = transform.position;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
    }

    #region Methods

    private void Shoot()
    {
        Aim();

        if (!shoot || !(Time.time > shootTime)) return;
        shootTime = Time.time + shootDelay;
        bulletPrefab.Parent = gameObject;
        bulletPrefab.Direction = movementNormalized;
        Instantiate(bulletPrefab, shootOrigin.position, shootOrigin.rotation);
    }

    private void Aim()
    {
        movementNormalized = Vector2.zero;

        if (movement.x > deadZone)
            movementNormalized.x = 1;
        else if (movement.x < -deadZone)
            movementNormalized.x = -1;

        if (movement.y > deadZone)
            movementNormalized.y = 1;
        else if (movement.y < -deadZone)
            movementNormalized.y = -1;

        if (movementNormalized != Vector2.zero && isGrounded)
            invunerableLocker = false;

        movementNormalized = movementNormalized == Vector2.zero
            ? (isFacingRight ? Vector2.right : Vector2.left)
            : movementNormalized;

        vectorOffset.x = movementNormalized.x * offset;
        vectorOffset.y = movementNormalized.y * offset;

        shootOrigin.position = transform.position + new Vector3(vectorOffset.x, vectorOffset.y);
    }

    private void Invulnerable()
    {
        if (!invunerableLocker)
        {
            isInv = false;
            StopAllCoroutines();
            DS4Manager.Instancia.SetLights(0, 255, 0);
            DS4Manager.Instancia.SetRumble(false);
        }

        if (!invunerable || isInv || !invunerableLocker) return;
        isInv = true;
        invunerableLocker = true;
        StartCoroutine(SetLight());
    }

    private IEnumerator SetLight()
    {
        DS4Manager.Instancia.SetRightRumble(50, 0);
        DS4Manager.Instancia.SetLights(255, 0, 0);
        yield return new WaitForSeconds(3);
        DS4Manager.Instancia.SetLights(0, 255, 0);
        invunerableLocker = false;
        DS4Manager.Instancia.SetRumble(false);
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ParryObject"))
        {
            if (parryed.Contains(other.gameObject)) return;
            parry = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ParryObject"))
        {
            parry = false;
            Destroy(other.gameObject);
        }
    }

    private void Jump()
    {
        if (isGrounded && jump)
            rbd.velocity = Vector2.up * jumpForce;

        if (isGrounded)
            invunerableLocker = false;

        distance = transform.position.y - lastPostition.y;

        if (!isGrounded && distance < 0)
        {
            invunerableLocker = true;
            rbd.velocity += Vector2.down;

            if (!parry || !jump) return;
            rbd.velocity = Vector2.up * jumpForce;
            parry = false;
        }
        else
            invunerableLocker = false;
    }

    private void Move()
    {
        Flip();
        if (!freezeMovement)
            rbd.velocity = new Vector2(movement.x * speed * Time.deltaTime, rbd.velocity.y);
    }

    private void Flip()
    {
        if (movement.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            // ReSharper disable once Unity.InefficientPropertyAccess
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }

        if (!(movement.x < 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
        // ReSharper disable once Unity.InefficientPropertyAccess
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
    }

    #endregion
    
    #region Input Action Receivers

    public void MoveInput(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                movement = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Canceled:
                movement = Vector2.zero;
                break;
        }
    }

    public void JumpInput(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                jump = true;
                break;
            case InputActionPhase.Canceled:
                jump = false;
                break;
        }
    }

    public void FreezeInput(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                freezeMovement = true;
                break;
            case InputActionPhase.Canceled:
                freezeMovement = false;
                break;
        }
    }

    public void ShootInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                shoot = true;
                break;
            case InputActionPhase.Canceled: //Reset values 
                shoot = false;
                break;
        }
    }

    public void StartInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                print("Paused");
                break;
            case InputActionPhase.Canceled: //Reset values 
                break;
        }
    }

    public void StareInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                staring = true;

                break;
            case InputActionPhase.Canceled: //Reset values 
                staring = false;
                break;
        }
    }

    public void InvunerableInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                invunerable = true;
                break;
            case InputActionPhase.Canceled: //Reset values 
                invunerable = false;
                break;
        }
    }

    public void SpecialInput(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                special = true;
                break;
            case InputActionPhase.Canceled: //Reset values 
                special = false;
                break;
        }
    }


    public void OnDeviceLost(PlayerInput input)
    {
        print(input.devices[0]);
    }

    public void OnDeviceRegain(PlayerInput input)
    {
    }

    #endregion
}