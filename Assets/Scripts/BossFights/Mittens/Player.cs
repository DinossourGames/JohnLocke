using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private InputActions Controls;
    private Vector2 moveInput;
    private BoxCollider2D hitbox;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    private void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
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
            default:
                throw new ArgumentOutOfRangeException();
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
}
