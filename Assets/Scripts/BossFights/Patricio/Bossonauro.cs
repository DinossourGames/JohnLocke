﻿using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.PS4;
using Random = UnityEngine.Random;

public enum Positions
{
    Burst,
    Missil,
    Initial,
    Random
}

public enum Actions
{
    NONE,
    Shoot,
    FollowShoot,
    ParrySequence,
    ParryShoot,
    BurstShoot,
    Move
}

public class Bossonauro : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform missilShootPoint;
    [SerializeField] private GameObject armGun;
    [SerializeField] private Vector2 lastPosition;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool canFollow;
    public float life = 1000;

    [Header("Actions")] public Actions NextAction = Actions.NONE;


    [SerializeField, Header("Prefabs"), Space]
    private Bullet bulletPrefab;

    [SerializeField] private Bullet missilPrefab;
    [SerializeField] private Bullet missilParryPrefab;

    [SerializeField] private Patricio _patricio;

    [SerializeField, Header("Pointers")] private Transform burstPoint;
    [SerializeField] private Transform missilPoint;
    [SerializeField] private Transform inicialPoint;
    [SerializeField] private Transform[] positions;


    private bool canShoot;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    public bool isDoing;

    // Start is called before the first frame update
    void Start()
    {
        NextAction = Actions.NONE;
        _patricio = FindObjectOfType<Patricio>();
        canFollow = true;
        StartCoroutine(UpdateCorroutine());
        StartCoroutine(BossFight());
    }

    private IEnumerator BossFight()
    {
        while (true)
        {
            if (!isDoing)
                NextAction = RandomAction();
            yield return null;
        }
    }


    Actions RandomAction()
    {
        var action = Random.Range(0, 5);
        switch (action)
        {
            case 0:
                return NextAction = Actions.Move;
            case 1:
                return NextAction = Actions.Shoot;
            case 2:
                return NextAction = Actions.FollowShoot;
            case 3:
                return NextAction = Actions.BurstShoot;
            case 4:
                return NextAction = Actions.ParrySequence;
            case 5:
                return NextAction = Actions.ParryShoot;
            default:
                return Actions.Move;
        }
    }

    public IEnumerator UpdateCorroutine()
    {
        while (true)
        {
            if (NextAction == Actions.NONE || isDoing) yield return null;

            switch (NextAction)
            {
                case Actions.NONE:
                    yield return new WaitForEndOfFrame();
                    break;
                case Actions.Shoot:
                    isDoing = true;
                    yield return StartCoroutine(ShootAt());
                    isDoing = false;
                    break;
                case Actions.FollowShoot:
                    isDoing = true;

                    yield return StartCoroutine(TargetShoot());
                    isDoing = false;

                    break;
                case Actions.ParrySequence:
                    isDoing = true;

                    yield return StartCoroutine(ParrySequence());
                    isDoing = false;

                    break;
                case Actions.ParryShoot:
                    isDoing = true;

                    yield return StartCoroutine(ShootMissil(true));
                    isDoing = false;

                    break;
                case Actions.BurstShoot:
                    isDoing = true;

                    yield return StartCoroutine(BurstShoot());
                    isDoing = false;

                    break;
                case Actions.Move:
                    isDoing = true;

                    yield return StartCoroutine(PreparePosition(Positions.Random));
                    isDoing = false;

                    break;
                default:
                    yield return null;
                    break;
            }

            yield return null;
        }
    }


    private void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("VitoriaPatricio");
        }

        if (canFollow)
            Follow();
    }


    public IEnumerator ShootAt()
    {
        NextAction = Actions.NONE;

        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(TargetShoot());
        }
    }

    public IEnumerator ParrySequence()
    {
        NextAction = Actions.NONE;

        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(.22f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.22f);
        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(.22f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.1f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.1f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.1f);
        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(.24f);
        yield return StartCoroutine(ShootMissil(true));
    }

    public IEnumerator TargetShoot()
    {
        NextAction = Actions.NONE;

        bulletPrefab.Parent = gameObject;
        bulletPrefab.Direction = isFacingRight ? Vector2.right : Vector2.left;
        canFollow = false;
        yield return new WaitForSeconds(.12f);
        Instantiate(bulletPrefab, shootPoint.position, armGun.transform.rotation);
        canFollow = true;
    }

    public IEnumerator ShootMissil(bool parry)
    {
        NextAction = Actions.NONE;
        canFollow = false;
        if (Vector2.Distance(missilPoint.transform.position, transform.position) > .05f)
            yield return StartCoroutine(PreparePosition(Positions.Missil));
        Bullet tiro;
        if (parry)
        {
            tiro = missilParryPrefab;
            tiro.Direction = isFacingRight ? Vector2.right : Vector2.left;
            tiro.Parent = gameObject;
        }
        else
        {
            tiro = missilPrefab;
            tiro.Direction = isFacingRight ? Vector2.right : Vector2.left;
            tiro.Parent = gameObject;
        }

        bossAnimator.SetBool("isMissil", true);
        yield return new WaitForSeconds(.3f);

        Instantiate(tiro, missilShootPoint.position, missilShootPoint.rotation);
        bossAnimator.SetBool("isMissil", false);
        yield return new WaitForSeconds(.3f);

        canFollow = true;
        NextAction = Actions.NONE;
    }

    public IEnumerator BurstShoot()
    {
        canFollow = false;


        yield return StartCoroutine(PreparePosition(Positions.Burst));


        Patricio.ds4.SetMotorSpeeds(.5f, .80f);
        yield return new WaitForSeconds(1f);
        Patricio.ds4.SetMotorSpeeds(0f, 0f);
        Patricio.ds4.SetMotorSpeeds(.5f, .80f);
        yield return new WaitForSeconds(1f);
        Patricio.ds4.SetMotorSpeeds(0f, 0f);
        Patricio.ds4.SetMotorSpeeds(.5f, .80f);
        yield return new WaitForSeconds(1f);
        Patricio.ds4.SetMotorSpeeds(0f, 0f);

        bulletPrefab.Parent = gameObject;
        bulletPrefab.Direction = isFacingRight ? Vector2.right : Vector2.left;
        canShoot = false;

        var burst = Random.Range(20, 50);
        var range = 180 / burst;

        for (var i = 0; i < burst; i++)
        {
            armGun.transform.rotation = Quaternion.AngleAxis((range * i) - 90, Vector3.forward);
            Instantiate(bulletPrefab, shootPoint.position, armGun.transform.rotation);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (var i = burst; i > 0; i--)
        {
            armGun.transform.rotation = Quaternion.AngleAxis((range * i) - 90, Vector3.forward);
            Instantiate(bulletPrefab, shootPoint.position, armGun.transform.rotation);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        for (var i = 0; i < burst; i++)
        {
            armGun.transform.rotation = Quaternion.AngleAxis((range * i) - 90, Vector3.forward);
            Instantiate(bulletPrefab, shootPoint.position, armGun.transform.rotation);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        canFollow = true;
    }

    public IEnumerator PreparePosition(Positions p)
    {
        NextAction = Actions.NONE;


        bossAnimator.SetBool(IsWalking, true);

        var position = transform.parent.position;
        var ponto = Vector2.zero;

        switch (p)
        {
            case Positions.Burst:
                ponto = (Vector2) burstPoint.transform.position;
                break;
            case Positions.Missil:
                ponto = (Vector2) missilPoint.transform.position;
                break;
            case Positions.Initial:
                ponto = (Vector2) inicialPoint.transform.position;
                break;
            default:
                ponto = positions[Random.Range(0, positions.Length)].position;
                break;
        }


        while (Mathf.Abs(position.x - ponto.x) > 0.05f &&
               Mathf.Abs(position.y - ponto.y) > 0.05f)
        {
            if (position.x - lastPosition.x < 0 && !isFacingRight)
            {
                isFacingRight = true;
                var localScale = transform.localScale;
                transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            }

            if (position.x - lastPosition.x > 0 && isFacingRight)
            {
                isFacingRight = false;
                var scale = transform.localScale;
                transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
            }

            position = Vector2.MoveTowards(position, ponto, 3 * Time.deltaTime);
            transform.parent.position = position;
            lastPosition = position;
            yield return Time.fixedDeltaTime;
        }

        bossAnimator.SetBool("isWalking", false);

        isFacingRight = false;
        var localScale1 = transform.localScale;
        transform.localScale = new Vector3(Mathf.Abs(localScale1.x), localScale1.y, localScale1.z);
    }

    private IEnumerator ShakeIt()
    {
        var counter = 0f;
        const float maxX = .2f;
        const float maxY = .4f;
        const float shakeTime = .3f;
        var pos = transform.position;
        while (counter <= shakeTime)
        {
            counter += Time.deltaTime;
            transform.position = pos + new Vector3((shakeTime - counter) * Random.Range(-maxX, maxX),
                                     (shakeTime - counter) * Random.Range(-maxY, maxY));
            yield return new WaitForEndOfFrame();
        }

        transform.position = pos;
    }

    private void Follow()
    {
        Flip();
        Rotate();
    }

    private void Rotate()
    {
        var direction = new Vector2
        {
            x = _patricio.transform.position.x - transform.position.x,
            y = _patricio.transform.position.y - transform.position.y
        };

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        armGun.transform.rotation = Quaternion.AngleAxis(isFacingRight ? angle : angle - 180, Vector3.forward);
    }

    private void Flip()
    {
        if (transform.position.x - _patricio.transform.position.x < 0 && !isFacingRight)
        {
            isFacingRight = true;
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }

        if (!(transform.position.x - _patricio.transform.position.x > 0) || !isFacingRight) return;
        isFacingRight = false;
        var scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            var bull = other.GetComponent<Bullet>();
            if (bull.Parent != gameObject)
            {
                if (life >= 0)
                {
                    life -= 5;
                    StartCoroutine(ShakeIt());
                }
            }
        }

        if (other.CompareTag("Platform"))
        {
            var platform = other.transform.GetComponent<Platform>();
            if (platform.state == State.Falling)
            {
                if (life >= 0)
                {
                    life -= 25;
                    StartCoroutine(ShakeIt());
                }
            }
        }
    }
}