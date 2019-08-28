using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalHealth;
    [SerializeField] private GameObject bossBones;
    [SerializeField] private GameObject basicShot;
    [SerializeField] private GameObject missile;
    [SerializeField] private Transform basicShotPoint;
    [SerializeField] private Transform missileLauncher;
    [SerializeField] private GameObject arm;
    public Transform player;
    [SerializeField] private Animator animator;
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private float speed;
    private float scale;
    private float reverseScale;
    [SerializeField] private bool canMove;
    private int countShot;
    [SerializeField] private float basicShotDelay;


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
        scale = transform.localScale.x;
        reverseScale = -scale;
        canMove = true;
        StartCoroutine(Movement());
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(reverseScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
        }

        if (MittensGameManager._bossState != BossState.Waiting) return;
        
    }

    private IEnumerator Shoot()
    {
        if (countShot < 3 + MittensGameManager.difficulty)
        {
            Instantiate(basicShot, basicShotPoint.position, rotation);
            countShot++;
            yield return new WaitForSeconds(1f - (MittensGameManager.difficulty * 0.2f));
        }
        else
        {
            yield return new WaitForSeconds(basicShotDelay - ((MittensGameManager.difficulty - 1) * basicShotDelay) / 4);
            countShot = 0;
        }
    }

    private IEnumerator Movement()
    {
        while (canMove)
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
            arm.transform.rotation = rotation;
            transform.position =
                Vector2.MoveTowards(transform.position, player.position,
                    speed * MittensGameManager.difficulty * Time.deltaTime);
        }

        yield return null;
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
