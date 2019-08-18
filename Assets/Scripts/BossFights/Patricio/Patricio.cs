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
    [SerializeField, Header("ATRIBUTES")]
    private float speed = 300;
    [SerializeField]
    private Vector2 movement;
    [SerializeField]
    private bool jump;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool shoot;

    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private bool staring;
    [SerializeField]
    private bool invunerable;
    [SerializeField]
    private bool invunerableLocker;
    [SerializeField]
    private bool special;



    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        gamepad = Gamepad.current;

    }

    // Update is called once per frame
    void Update()
    {
        GamepadCheck();
        Move();
        Jump();
        Invunerable();
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
        rbd.velocity = new Vector2(movement.x * speed * Time.deltaTime, rbd.velocity.y);
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

    }

    public void OnDeviceRegain(PlayerInput input)
    {

    }

    #endregion
}
