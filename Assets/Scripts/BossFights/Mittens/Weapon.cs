using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Weapon : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private InputActions actions;


    private void Awake()
    {
        actions = new InputActions();
        actions.MittensBossFight.Aim.performed += ctx => OnAim(ctx);
    }

    private void OnEnable()
    {
        actions.MittensBossFight.Enable();
    }

    private void OnDisable()
    {
        actions.MittensBossFight.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput();
        // print(Player.device);
//
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        sprite.flipY = direction.x < 0;
    }

    private void GetMouseInput()
    {
        if (!Player.device) return;
      
       var dir = Mouse.current.position.ReadValue();
       
        var mouse = Camera.main.ScreenToWorldPoint(dir);
        direction = new Vector2
        {
            x = mouse.x - transform.position.x,
            y = mouse.y - transform.position.y
        };

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
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
        AimPerformed(context);
    }

    private void AimPerformed(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//        if (Player.device.Equals("Gamepad"))
//        {
//        }

//        else
//        {
//            print("b");
//            var mouse = Camera.main.ScreenToWorldPoint(direction);
//            direction = new Vector2
//            {
//                x = mouse.x - transform.position.x,
//                y = mouse.y - transform.position.y
//            };
//
//            print("a");
//            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//        }
    }
}