﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    public GameObject Parent;
    public Vector2 Direction;

    private void Start()
    {
        Invoke(nameof(DestroyProjectile), lifeSpan);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      print(other.tag);
    }
}
