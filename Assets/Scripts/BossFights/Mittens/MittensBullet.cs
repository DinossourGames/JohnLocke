using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MittensBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosion;
    [SerializeField] private int damage;
    [SerializeField] private int piercing;
    private float timeToDie;

    void Start()
    {
        //Invoke("DestroyProjectile", lifeTime);
        timeToDie = Time.time + lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.right);
        if (Time.time >= timeToDie)
            DestroyProjectile();
    }

    void DestroyProjectile()
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MittensGameManager.DealDamage(gameObject, collision.gameObject, damage);
        if (collision.CompareTag("Player")|| collision.CompareTag("EnemyShot")) return;
        if (piercing <= 0)
            DestroyProjectile();
        else
            piercing--;
    }
}