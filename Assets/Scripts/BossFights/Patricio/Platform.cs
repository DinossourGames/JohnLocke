using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

enum State
{
    Rising,
    Falling,
    MovingRight,
    MovingLeft,
    IdleDown,
    IdleUp,
    Increasing,
    Decreasing
}

public class Platform : MonoBehaviour
{
    [SerializeField, Header("Fill Atributes")]
    private GameObject fillPlatform;

    [SerializeField] private GameObject basePlatform;

    [SerializeField] private State state;
    [SerializeField, Range(0f, 1f)] private float fillRatio;
    [SerializeField, Range(0f, 3f)] private float fillDelay;
    private Vector3 localScale;

    private float fillAmmount;
    private bool _hasCollision;

    // Screen bounds
    [SerializeField, Header("Boundaries"), Space]
    private Camera mainCamera;

    [SerializeField] private Vector2 screenBounds;


    // Sprite Bounds
    private BoxCollider2D _collider2D;
    [SerializeField] private Vector2 platformBounds;
    [SerializeField, Range(1, 15)] private float upSpeed;

    //references
    private Transform player;
    private SpriteRenderer baseSpriteRenderer;
    private Rigidbody2D rb;
    [SerializeField, Space] private bool isTop;

    [Header("Position Check"), Space] [SerializeField]
    private Transform leftChecker;

    [SerializeField] private Transform rightChecker;
    [SerializeField] private bool right;
    [SerializeField] private bool left;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        state = State.IdleDown;
        _collider2D = GetComponent<BoxCollider2D>();
        localScale = fillPlatform.transform.localScale;
        platformBounds = _collider2D.size;
        baseSpriteRenderer = basePlatform.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var position = transform.position;
        isTop = position.y > screenBounds.y / 2;
        left = Physics2D.OverlapPoint(leftChecker.position, layerMask);
        right = Physics2D.OverlapPoint(rightChecker.position, layerMask);
    }


    private void FixedUpdate()
    {
    }

    private IEnumerator OneLeft()
    {
        state = State.MovingLeft;
        yield return StartCoroutine(ShakePlatform());
        var next = transform.position.x - platformBounds.x;

        while (transform.position.x > next)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.left;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + platformBounds.x / 2,
                screenBounds.x - platformBounds.x / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator OneRight()
    {
        state = State.MovingRight;
        yield return StartCoroutine(ShakePlatform());
        var next = transform.position.x - platformBounds.x;

        while (transform.position.x < next)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.right;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + platformBounds.x / 2,
                screenBounds.x - platformBounds.x / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator GoRight()
    {
        yield return StartCoroutine(ShakePlatform());
        state = State.MovingRight;

        while (transform.position.x < screenBounds.x - platformBounds.x / 2)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.right;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + platformBounds.x / 2,
                screenBounds.x - platformBounds.x / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator GoLeft()
    {
        yield return StartCoroutine(ShakePlatform());
        state = State.MovingLeft;
        while (transform.position.x > screenBounds.x * -1 + platformBounds.x / 2)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.left;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + platformBounds.x / 2,
                screenBounds.x - platformBounds.x / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator Fall()
    {
        yield return StartCoroutine(ShakePlatform());
        yield return new WaitForSeconds(.2f);
        yield return StartCoroutine(ShakePlatform());
        yield return new WaitForSeconds(.2f);
        yield return StartCoroutine(ShakePlatform());
        state = State.Falling;

        while (transform.position.y > screenBounds.y * -1 + platformBounds.y / 2)
        {
            var position = transform.position;
            position += Time.deltaTime * 25 * Vector3.down;

            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + platformBounds.y / 2,
                screenBounds.y - platformBounds.y / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = State.IdleDown;
    }

    [SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeNullComparison")]
    private IEnumerator Rise()
    {
        state = State.Rising;
        yield return StartCoroutine(ShakePlatform());

        while (transform.position.y < screenBounds.y - platformBounds.y / 2)
        {
            var position = transform.position;
            position += Time.fixedDeltaTime * upSpeed * Vector3.up;

            if (player != null)
                if (position.y > screenBounds.y - platformBounds.y && player.parent != null)
                    StartCoroutine(DropPlayer());

            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + platformBounds.y / 2,
                screenBounds.y - platformBounds.y / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        state = State.IdleUp;
    }

    private IEnumerator Die()
    {
        state = State.Falling;
        yield return StartCoroutine(ShakePlatform());
        rb.isKinematic = false;
        rb.gravityScale = 5;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator DropPlayer()
    {
        var atualColor = baseSpriteRenderer.color;
        baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, .25f);
        player.parent = null;
        _collider2D.enabled = false;
        yield return new WaitForSeconds(.4f);
        _collider2D.enabled = true;
        baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, 1f);
    }

    private IEnumerator ShakePlatform()
    {
        yield return new WaitForSeconds(.4f);
        fillAmmount = 0;
        fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);
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

        yield return new WaitForSeconds(.4f);
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(fillDelay);
        var peak = false;
        state = State.Increasing;
        while (fillAmmount <= 1.0f && _hasCollision)
        {
            fillAmmount += fillRatio;
            if (fillAmmount > 1f)
            {
                peak = true;
                state = State.Rising;
                continue;
            }

            fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);
            yield return new WaitForSeconds(fillDelay);
        }

        if (!peak) yield break;
        fillAmmount = 0f;
        fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);

        StartCoroutine(BossFightManager.FightState == BossFightState.Stage3 ? Die() : Rise());
    }

    private IEnumerator Decrease()
    {
        yield return new WaitForSeconds(fillDelay);
        state = State.Decreasing;
        while (fillAmmount > 0f && !_hasCollision)
        {
            fillAmmount -= fillRatio;
            fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);
            yield return new WaitForSeconds(fillDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player") || state != State.IdleDown) return;
        player = other.collider.transform;
        player.SetParent(transform);
        _hasCollision = true;
        StopAllCoroutines();
        StartCoroutine(Increase());
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player") || state != State.IdleDown) return;
        player = other.collider.transform;
        player.SetParent(null);
        _hasCollision = false;
        StopAllCoroutines();
        StartCoroutine(Decrease());
    }
}