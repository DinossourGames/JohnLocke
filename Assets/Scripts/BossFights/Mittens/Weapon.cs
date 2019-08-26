using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private PlayerInput a;
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        a = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
        
        sprite.flipY = direction.x < 0;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSwitchWeapons(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnAim(InputAction.CallbackContext context)
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
                AimPerformed(context);
                break;
            case InputActionPhase.Canceled:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void AimPerformed(InputAction.CallbackContext context)
    {
        if (a.devices[0].Equals("Gamepad"))
        {
            direction = context.ReadValue<Vector2>();
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            if (Camera.main != null)
            {
                var mouse = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
                direction = new Vector2
                {
                    x = mouse.x - transform.position.x,
                    y = mouse.y - transform.position.y
                };
            }

            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}
