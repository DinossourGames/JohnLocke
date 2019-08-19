using DS4_Wrapper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Patricio : MonoBehaviour
{

    Rigidbody2D rbd;
    Gamepad gamepad;
    [SerializeField, Header("MOVEMENT")]
    private float speed = 300;
    [SerializeField]
    private Vector2 movement;
    [SerializeField]
    private bool jump;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isFacingRight;
    [SerializeField]
    private bool freezeMovement;


    [SerializeField, Header("GROUND CHECKING"), Space]
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask ground;

    [SerializeField, Space, Header("ABILITIES")]
    private bool staring;
    [SerializeField]
    private bool invunerable;
    [SerializeField]
    private bool invunerableLocker;

    [SerializeField, Space, Header("SHOOTS")]
    private bool special;
    [SerializeField]
    private bool shoot;
    [SerializeField]
    private Transform shootOrigin;
    [SerializeField]
    private Vector2 vectorOffset;
    [SerializeField]
    private float offset;
    [SerializeField,Range(0f,.24f)]
    private float deadZone;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        gamepad = Gamepad.current;

    }

    // Update is called once per frame
    void Update()
    {
        //GamepadCheck();
        Move();
        Jump();
        Invunerable();
        Shoot();
    }

    [Obsolete]
    private void Shoot()
    {
        Aim();
    }

    private void Aim()
    {
        var movementNormalized = Vector2.zero;

 

        if (movement.x > deadZone)
            movementNormalized.x = 1;
        else if (movement.x < -deadZone)
            movementNormalized.x = -1;


        if (movement.y > deadZone)
            movementNormalized.y = 1;
        else if (movement.y < -deadZone)
            movementNormalized.y = -1;


        var dir = (movement.x > -deadZone && movement.x < deadZone) ? (isFacingRight ? Vector2.right : Vector2.left) : movementNormalized;

        vectorOffset.x = dir.x * offset;
        vectorOffset.y = dir.y * offset;

        shootOrigin.position = transform.position + new Vector3(vectorOffset.x, vectorOffset.y);
    }

    private void GamepadCheck()
    {
        if (gamepad != null)
        {
            print(GetComponent<PlayerInput>().controlScheme);
        }
    }

    private void Invunerable()
    {
        if (invunerable && !invunerableLocker)
        {
            invunerableLocker = true;
            StartCoroutine(SetLight());
        }
    }

    IEnumerator SetLight()
    {
        DS4Manager.Instancia.SetRightRumble(50, 0);
        DS4Manager.Instancia.SetLights(255, 0, 0);
        yield return new WaitForSeconds(3);
        DS4Manager.Instancia.SetLights(0, 255, 0);
        invunerableLocker = false;
        DS4Manager.Instancia.SetRumble(false);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

    }

    private void Jump()
    {
        if (isGrounded && jump)
        {
            rbd.velocity = Vector2.up * jumpForce;
        }
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
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        if (movement.x < 0 && isFacingRight)
        {
            isFacingRight = false;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

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
