using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public Canvas canvas;
    public Slider healthBar;

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
    private bool playerExists;
    [SerializeField] private float timeBetweenSpecials;
    private int countSpecial;


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
        canvas = FindObjectOfType<Canvas>();
        healthBar = FindObjectOfType<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerExists = true;
        animator = GetComponent<Animator>();
        Health = TotalHealth;
        healthBar.maxValue = TotalHealth;
        healthBar.value = 0;
        
    }

    private IEnumerator Special()
    {
        while (playerExists)
        {
            yield return new WaitForSeconds(timeBetweenSpecials);
            canMove = false;
            var r = Random.Range(1, 3);
            print(r);
            switch (r)
            {
                case 1:
                    StartCoroutine(Charge());
                    break;
                case 2:
                    StartCoroutine(Spiral());
                    break;
            }
        }
    }
    private IEnumerator Spiral()
    {
        while (countSpecial < 20 * MittensGameManager.difficulty)
        {
            Instantiate(basicShot, basicShotPoint.position, Quaternion.AngleAxis(angle - (countSpecial*(50 / MittensGameManager.difficulty)), Vector3.forward) );
            countSpecial++;
            yield return null;
        }

        canMove = true;
        countSpecial = 0;
        //ResetShooting();
        yield return null;
    }

    private IEnumerator Charge()
    {
        yield return new WaitForSeconds(1);
        TrueFlip();
        Vector3 specialTarget = player.position;
        while (transform.position != specialTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, specialTarget, speed * 5 *MittensGameManager.difficulty * Time.deltaTime);
            yield return null;
        }
        canMove=true;
        //ResetShooting();
        yield return null;
    }

    private IEnumerator ShootMissile()
    {
        while (playerExists)
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
        healthBar.value = healthBar.maxValue - _health;
        playerExists = player != null;
        if(!playerExists)
            StopAllCoroutines();
        Flip();

        if (MittensGameManager._bossState != BossState.Waiting) return;
    }


    private void Flip()
    {
        if (playerExists && canMove)
        {
            TrueFlip();
        }
    }

    private void TrueFlip()
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
        while (playerExists)
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
        while (playerExists)
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
        {
            canMove = true;
            StartCoroutine(Movement());
            StartCoroutine(Shoot());
            StartCoroutine(ShootMissile());
            StartCoroutine(Special());
        }

        _health -= damageAmount;
        if (_health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("VitoriaMittens");
        }
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