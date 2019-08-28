using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    [SerializeField] private Animator bossAnimator;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform missilShootPoint;
    [SerializeField] private GameObject armGun;
    [SerializeField] private Vector2 lastPosition;
    [SerializeField] private bool isFacingRight;

    [SerializeField, Header("Prefabs"), Space]
    private Bullet bulletPrefab;

    [SerializeField] private GameObject missilPrefab;
    [SerializeField] private GameObject missilParryPrefab;

    [SerializeField] private Patricio _patricio;

    [SerializeField, Header("Pointers")] private Transform burstPoint;

    private bool canShoot;
    [SerializeField] private bool canFollow;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        _patricio = FindObjectOfType<Patricio>();
        canFollow = true;
        StartCoroutine(BurstShoot());
    }


    private void Update()
    {
        if (canFollow)
            Follow();
    }

    private IEnumerator BurstShoot()
    {
        canFollow = false;
        yield return StartCoroutine(PreparePosition());

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

    private IEnumerator PreparePosition()
    {
        yield return new WaitForSeconds(1.4f);

        bossAnimator.SetBool(IsWalking, true);

        var position = transform.parent.position;

        while (Mathf.Abs(position.x - burstPoint.position.x) > 0.05f &&
               Mathf.Abs(position.y - burstPoint.position.y) > 0.05f)
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

            position = Vector2.MoveTowards(position, burstPoint.position, 3 * Time.deltaTime);
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
}