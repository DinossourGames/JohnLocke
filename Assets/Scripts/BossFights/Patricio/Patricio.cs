using System.Collections;
using DS4_Wrapper;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.Serialization;

public class Patricio : MonoBehaviour
{
    private Rigidbody2D rbd;

    [SerializeField] [Header("MOVEMENT")] private float speed = 300;
    [SerializeField] private Vector2 movement;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool freezeMovement;
    [SerializeField] [Space] private Vector2 movementNormalized;

    [SerializeField] [Space] [Header("Jump")]
    private bool jump;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime;
    [SerializeField] private float jumpTimeCounter;
    [SerializeField] private bool isJumping;
    [SerializeField] private int framCount;
    [SerializeField] private bool parry;
    [SerializeField] private bool goFurther;

    [SerializeField] [Header("GROUND CHECKING")] [Space]
    private bool isGrounded;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Vector2 lastPostition;
    [SerializeField] private float distance;

    [SerializeField] [Space] [Header("ABILITIES")]
    private bool staring;

    [SerializeField] private bool invunerable;
    [SerializeField] private bool isInv;
    [SerializeField] private bool invunerableLocker;

    [SerializeField] [Space] [Header("SHOOTS")]
    private bool special;

    [SerializeField] private bool shoot;
    [SerializeField] private float shootTime;
    [SerializeField] private float shootDelay;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootOrigin;
    [SerializeField] private Vector2 vectorOffset;
    [SerializeField] private float offset;
    [SerializeField] [Range(0f, .24f)] private float deadZone;



    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        parry = false;
    }


    private void Update()
    {
        Jump();
        Invulnerable();
        Shoot();
        lastPostition = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
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
        else if (movement.x < -deadZone) movementNormalized.x = -1;

        if (movement.y > deadZone)
            movementNormalized.y = 1;
        else if (movement.y < -deadZone) movementNormalized.y = -1;

        if (movementNormalized != Vector2.zero && isGrounded) invunerableLocker = false;

        movementNormalized = movementNormalized == Vector2.zero
            ? isFacingRight ? Vector2.right : Vector2.left
            : movementNormalized;

        vectorOffset.x = movementNormalized.x * offset;
        vectorOffset.y = movementNormalized.y * offset;

        shootOrigin.position = transform.position + new Vector3(vectorOffset.x, vectorOffset.y);
    }

    private void Invulnerable()
    {
        if (isInv)
        {
           GamepadManager.SetRumble(0f,1f);
           GamepadManager.SetLighbar(new Color32(255,0,255,0));
        }
        else
        {
            GamepadManager.SetRumble(0,0);
            GamepadManager.SetLighbar(new Color32(32, 255, 0, 0));

        }


        if (!invunerableLocker)
        {
            isInv = false;
            
        }

        if (!invunerable || isInv || !invunerableLocker) return;
        isInv = true;
        invunerableLocker = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ParryObject")) parry = jump && !isGrounded && framCount <= 12;
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
        if (jump) framCount++;

        if (isGrounded && jump)
        {
            rbd.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            isJumping = true;
        }

        if (goFurther)
        {
            if (jump && isJumping)
            {
                if (jumpTimeCounter > 0)
                {
                    rbd.velocity = Vector2.up * (jumpForce * .8f);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
        }

        if (isGrounded) invunerableLocker = false;

        distance = transform.position.y - lastPostition.y;

        if (!isGrounded && distance < 0)
        {
            invunerableLocker = true;
            rbd.velocity += Vector2.down * 1.2f;
        }
        else
        {
            invunerableLocker = false;
        }

        if (!parry || !jump) return;
        rbd.velocity = 1.4f * jumpForce * Vector2.up;
        parry = false;
    }

    private void Move()
    {
        Flip();
        if (!freezeMovement) rbd.velocity = new Vector2(movement.x * speed, rbd.velocity.y);
    }

    private void Flip()
    {
        if (movement.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }

        if (!(movement.x < 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
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
                isJumping = false;
                framCount = 0;
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
    
    #endregion
}