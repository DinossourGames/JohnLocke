﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using Object = UnityEngine.Object;

public class Weapon : MonoBehaviour, InputActions.IMittensBossFightActions
{
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    private SpriteRenderer sprite;
    [SerializeField] private InputActions actions;
    [SerializeField] private bool trigger;
    private float shotTime;
    [SerializeField] private int ammo;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float cadence;
    [SerializeField] private int totalAmmo;
    [SerializeField] private float reloadTime;
    [SerializeField] private bool reloading;
    [SerializeField] private float spread;
    [SerializeField] private float reverseScale;
    [SerializeField] private float scale;
    [SerializeField] private bool isFacingRight;


    private void Awake()
    {
        isFacingRight = true;
        actions = new InputActions();
        actions.MittensBossFight.Aim.performed += ctx => OnAim(ctx);
        actions.MittensBossFight.Shoot.performed += ctx => trigger = true;
        actions.MittensBossFight.Shoot.canceled += ctx => trigger = false;
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
        ammo = totalAmmo;
        scale = transform.localScale.y;
        reverseScale = -scale;
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        GetMouseInput();
        rotation = Quaternion.AngleAxis( angle, Vector3.forward);
        transform.rotation = rotation;
        sprite.flipY = direction.x < 0;
        
        if(trigger && !reloading)
            Shoot();
        
        
    }
    
    private void Flip()
    {
        if (transform.position.x - direction.x < 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x , localScale.y, localScale.z);
            sprite.flipY = true;
        }

        if (!(transform.position.x - direction.x > 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x , scale.y, scale.z);
        sprite.flipY = false;

    }
    
    private void Shoot()
    {
        if (Time.time >= shotTime)
        {
            if (ammo > 0)
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                shotTime = Time.time + cadence;
                ammo--;
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }
    private IEnumerator Reload()
    {
        reloading = true;
        sprite.color = new Color32(130, 13, 0, 255);
        yield return new WaitForSeconds(reloadTime);
        ammo = totalAmmo;
        sprite.color = Color.white;
        reloading = false;

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
        StartCoroutine(Reload());
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
    }
}