using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

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
    [SerializeField] private bool isFacingRight;
    private Quaternion shotRotation;
    private int countMissile;
    [SerializeField] private float MissileDelay;


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
        StartCoroutine(Movement());
        StartCoroutine(Shoot());
        StartCoroutine(ShootMissile());
    }

    private IEnumerator ShootMissile()
    {
        while (player != null)
        {
            if (canMove)
            {
                if (countMissile < 1 + MittensGameManager.difficulty)
                {
                    Instantiate(missile, missileLauncher.position, Quaternion.AngleAxis(90*countMissile, Vector3.forward));
                    countMissile++;
                    yield return null;
                }
                else
                {
                    yield return new WaitForSeconds(MissileDelay);
                    countMissile = 0;
                }
            }

            yield return null;
        }
    }

    private void Update()
    {
        Flip();

        if (MittensGameManager._bossState != BossState.Waiting) return;
    }


    private void Flip()
    {
        if (transform.position.x - player.transform.position.x < 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }

        if (!(transform.position.x - player.transform.position.x > 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
    }

    private IEnumerator Shoot()
    {
        while (player != null)
        {
            if (canMove)
            {
                if (countShot < 3 + MittensGameManager.difficulty)
                {
                    Instantiate(basicShot, basicShotPoint.position, shotRotation);
                    countShot++;
                    yield return new WaitForSeconds(1f - (MittensGameManager.difficulty * 0.2f));
                }
                else
                {
                    yield return new WaitForSeconds(basicShotDelay -
                                                    ((MittensGameManager.difficulty - 1) * basicShotDelay) / 4);
                    countShot = 0;
                }
            }

            yield return null;
        }
    }

    private IEnumerator Movement()
    {
        while (player != null)
        {
            if (canMove)
            {
                // animator.SetBool("IsWalking", true);
                var p = player.position;
                direction = new Vector2
                {
                    x = p.x - basicShotPoint.position.x,
                    y = p.y - basicShotPoint.position.y
                };
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rotation = Quaternion.AngleAxis(isFacingRight ? angle - 168 : angle, Vector3.forward);
                //shotRotation = Quaternion.AngleAxis(angle, Vector3.forward);
                shotRotation = Quaternion.AngleAxis(angle - Random.Range(-10, 10), Vector3.forward);
                arm.transform.rotation = rotation;
                transform.position =
                    Vector2.MoveTowards(transform.position, player.position,
                        speed * MittensGameManager.difficulty * Time.deltaTime);
            }

            yield return null;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (_health == _totalHealth)
            canMove = true;
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