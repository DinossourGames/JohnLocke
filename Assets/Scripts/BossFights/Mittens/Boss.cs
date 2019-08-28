using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalHealth;
    [SerializeField] private GameObject bossBones;
    public Transform player;
    [SerializeField] private Animator animator;
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private float speed;

    public int Health
    {
        get => _health;
        set => _health = value;
    }
    public int TotalHealth
    {
        get => _totalHealth;
        set => _totalHealth = value;
    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        Health = TotalHealth;
    }

    private void Update()
    {
        Movement();
    }
    
    private void Movement()
    {
       // animator.SetBool("IsWalking", true);
        var p = player.position;
        direction = new Vector2
        {
            x = p.x - transform.position.x,
            y = p.y - transform.position.y
        };
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position =
            Vector2.MoveTowards(transform.position, player.position, speed * MittensGameManager.difficulty * Time.deltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        MittensGameManager.DealDamage(gameObject, other.gameObject, 1);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        MittensGameManager.DealDamage(gameObject, other.gameObject, 1);
    }
}
