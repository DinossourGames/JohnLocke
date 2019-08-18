using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Patricio : MonoBehaviour
{
    Rigidbody2D rbd;
    Gamepad gamepad;
    private float speed = 500;
    private Vector2 movement;
    private bool jump;
    private bool canShoot;



    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        rbd.velocity = new Vector2(movement.x * speed * Time.deltaTime, rbd.velocity.y);

        if (movement.x > 0)
            gamepad.SetMotorSpeeds(0f, 1f);
        else if (movement.x < 0)
            gamepad.SetMotorSpeeds(1f, 0f);
        else
            gamepad.SetMotorSpeeds(0f, 0f);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                movement = context.ReadValue<Vector2>();
                break;
            case InputActionPhase.Canceled:
                movement =  Vector2.zero;
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

    public void Shoot(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Started: //Verify the type of input ieg Press or Hold
                break;
            case InputActionPhase.Performed: //Read input here
                canShoot = true; 
                break;
            case InputActionPhase.Canceled: //Reset values 
                canShoot = false;
                break;
        }
    }



}
