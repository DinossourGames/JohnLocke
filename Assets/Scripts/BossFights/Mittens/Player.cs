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
    [SerializeField] private SpriteRenderer backSprite;
    [SerializeField] private Vector2 boundsMin;
    [SerializeField]private Vector2 boundsMax;
    private Vector2 playerSize;

    // Start is called before the first frame update
    private void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        var bounds = backSprite.bounds;
        boundsMin = bounds.min;
        boundsMax = bounds.max;
        playerSize = sprite.bounds.extents;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * speed;
    }

    private void LateUpdate()
    {
        var position = transform.position;
        position.x = Mathf.Clamp(position.x, boundsMin.x + playerSize.x, boundsMax.x - playerSize.x);
        position.y = Mathf.Clamp(position.y, boundsMin.y + playerSize.y, boundsMax.y-playerSize.y);
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
