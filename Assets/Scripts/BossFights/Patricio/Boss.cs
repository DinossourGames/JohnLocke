using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public enum Positions
{
    Burst,
    Missil,
    Initial
}

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform missilShootPoint;
    [SerializeField] private GameObject armGun;
    [SerializeField] private Vector2 lastPosition;
    [SerializeField] private bool isFacingRight;
    [SerializeField] private bool canFollow;
    public float life = 100;

    [SerializeField, Header("Prefabs"), Space]
    private Bullet bulletPrefab;

    [SerializeField] private Bullet missilPrefab;
    [SerializeField] private Bullet missilParryPrefab;

    [SerializeField] private Patricio _patricio;

    [SerializeField, Header("Pointers")] private Transform burstPoint;
    [SerializeField] private Transform missilPoint;
    [SerializeField] private Transform inicialPoint;


    private bool canShoot;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        _patricio = FindObjectOfType<Patricio>();
        canFollow = true;
    }


    private void Update()
    {
        if(life <= 0)
            Destroy(gameObject);
        if (canFollow)
            Follow();
    }


    public IEnumerator ShootAt()
    {
        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(2f);
            StartCoroutine(TargetShoot());
            yield return new WaitForSeconds(2f);
            StartCoroutine(TargetShoot());
        }
    }

    public IEnumerator ParrySequence()
    {
        yield return new WaitForSeconds(1.2f);
        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(1.2f);
        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(1.2f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.12f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.07f);
        yield return StartCoroutine(ShootMissil(true));
        yield return new WaitForSeconds(.3f);
        yield return StartCoroutine(ShootMissil(false));
        yield return new WaitForSeconds(.4f);
        yield return StartCoroutine(ShootMissil(true));
    }

    public IEnumerator TargetShoot()
    {
        bulletPrefab.Parent = gameObject;
        bulletPrefab.Direction = isFacingRight ? Vector2.right : Vector2.left;
        canFollow = false;
        yield return new WaitForSeconds(.12f);
        Instantiate(bulletPrefab, shootPoint.position, armGun.transform.rotation);
        canFollow = true;
    }

    public IEnumerator ShootMissil(bool parry)
    {
        canFollow = false;
        yield return StartCoroutine(PreparePosition(Positions.Missil));
        bossAnimator.SetBool("isMissil", true);
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

        Instantiate(tiro, shootPoint.position, quaternion.identity);
        bossAnimator.SetBool("isMissil", false);

        canFollow = true;
    }

    public IEnumerator BurstShoot()
    {
        canFollow = false;
        yield return StartCoroutine(PreparePosition(Positions.Burst));

        bulletPrefab.Parent = gameObject;
        bulletPrefab.Direction = isFacingRight ? Vector2.right : Vector2.left;
        canShoot = false;
        yield return new WaitForSeconds(2f);

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
        yield return new WaitForSeconds(1.4f);

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
        armGun.transform.rotation = Quaternion.AngleAxis(isFacingRight ? angle - 13 : angle - 168, Vector3.forward);
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
            if (bull.Parent != transform)
            {
                life -= bull.damage * 20;
            }
        }

        if (other.CompareTag("Platform"))
        {
            print("YAAAAAAAAY");
        }
    }


}