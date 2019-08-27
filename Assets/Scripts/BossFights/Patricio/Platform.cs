using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

// ReSharper disable Unity.PerformanceCriticalCodeNullComparison

public enum State
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

    [SerializeField] private State _state;

    public State State
    {
        get => _state;
    }

    [SerializeField, Range(0f, 1f)] private float fillRatio;
    [SerializeField, Range(0f, 3f)] private float fillDelay;
    private Vector3 localScale;

    private float _fillAmmount;
    private bool _hasCollision;
    public bool _movementLocker;

    // Screen bounds
    [SerializeField, Header("Boundaries"), Space]
    private Camera mainCamera;

    [SerializeField] private Vector2 screenBounds;


    // Sprite Bounds
    private BoxCollider2D _collider2D;
    [SerializeField] private Vector2 platformBounds;
    [SerializeField, Range(1, 15)] private float upSpeed;

    //references
    private Transform _player;
    private SpriteRenderer _baseSpriteRenderer;
    private Rigidbody2D _rb;
    [SerializeField, Space] private bool isTop;

    [Header("Position Check"), Space] [SerializeField]
    private Transform leftChecker;

    [SerializeField] private Transform rightChecker;
    [SerializeField] private bool right;
    [SerializeField] private bool left;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlatformManager _pManager;
    private Coroutine decrease;
    private Coroutine increase;
    [SerializeField] private float offset;
    private bool shake;


    private void Start()
    {
        
        mainCamera = FindObjectOfType<Camera>();
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        _state = State.IdleDown;
        _collider2D = GetComponent<BoxCollider2D>();
        localScale = fillPlatform.transform.localScale;
        _baseSpriteRenderer = basePlatform.GetComponent<SpriteRenderer>();
        platformBounds = _baseSpriteRenderer.size;
        _rb = GetComponent<Rigidbody2D>();
        left = right = true;
        _pManager = FindObjectOfType<PlatformManager>();
    }

    private void Update()
    {

        _collider2D.size = _baseSpriteRenderer.size * _baseSpriteRenderer.transform.localScale;
        
        var position = transform.position;
        isTop = position.y > screenBounds.y / 2;
    }

    public void UpdateState(PlatformPosition update)
    {
        var distance = Vector3.Distance(transform.position, update.Position.center);
        var direction = transform.position.x - update.Position.center.x > 0; //  > 0 - right | < 0 -left

        if (_state == State.Rising || _state == State.Falling || _state == State.IdleUp ||
            _state == State.MovingLeft ||
            _state == State.MovingRight || _movementLocker)
            return;

        var yDiff = Mathf.Abs(transform.position.y - update.Position.center.y);

        if (distance < 3.4f && distance > 2.5f && yDiff < .4f)
        {
            if (BossFightManager.BossSide == BossSide.Right)
            {
                if (direction)
                {
                    _movementLocker = true;
                    StartCoroutine(Move(update.Position.center, true));
                }
            }

            if (BossFightManager.BossSide == BossSide.Left)
            {
                if (!direction)
                {
                    _movementLocker = true;
                    StartCoroutine(Move(update.Position.center, false));
                }
            }
        }
    }


    public IEnumerator Move(Vector2 endpoint, bool movingLeft)
    {
        if (increase != null)
            StopCoroutine(increase);
        if (decrease != null)
            StopCoroutine(decrease);
        decrease = StartCoroutine(Decrease());

        _state = movingLeft ? State.MovingLeft : State.MovingRight;
        yield return StartCoroutine(ShakePlatform());

        while (Vector2.Distance(transform.position, endpoint) > .1f)
        {
            transform.position += Time.deltaTime * upSpeed * (movingLeft ? Vector3.left : Vector3.right);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _state = isTop ? State.IdleUp : State.IdleDown;
        if (_hasCollision)
            increase = StartCoroutine(Increase());
        yield return new WaitForSeconds(2f);
        _movementLocker = false;
    }

    private IEnumerator RiseCycle()
    {
        var direction = BossFightManager.BossSide == BossSide.Left;

        switch (BossFightManager.FightState)
        {
            case BossFightState.Stage1:
                yield return StartCoroutine(Rise());
                yield return StartCoroutine(direction ? GoLeft() : GoRight());
                yield return StartCoroutine(Fall());
                break;
            case BossFightState.Stage2:
                yield return StartCoroutine(Rise());
                yield return StartCoroutine(direction ? GoLeft() : GoRight());
                yield return StartCoroutine(Fall());
                break;
            case BossFightState.Stage3:
                yield return StartCoroutine(Shinee());
                break;
            case BossFightState.Starting:
                break;
            case BossFightState.Finishing:
                break;
        }
    }

    private IEnumerator GoRight()
    {
        yield return StartCoroutine(ShakePlatform());
        _state = State.MovingRight;

        var bound = new Vector2(screenBounds.x - _baseSpriteRenderer.bounds.extents.x, transform.position.y);
        while (Vector2.Distance(transform.position, bound) > 0)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.right;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + platformBounds.x / 2,
                screenBounds.x - _baseSpriteRenderer.bounds.extents.x);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator GoLeft()
    {
        yield return StartCoroutine(ShakePlatform());
        _state = State.MovingLeft;
        var bound = new Vector2(screenBounds.x * -1 + _baseSpriteRenderer.bounds.extents.x, transform.position.y);

        while (Vector2.Distance(transform.position, bound) > 0)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.left;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + _baseSpriteRenderer.bounds.extents.x,
                screenBounds.x - _baseSpriteRenderer.bounds.extents.x);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator Fall()
    {
        yield return StartCoroutine(ShakePlatform());
        yield return new WaitForSeconds(.2f);
        yield return StartCoroutine(ShakePlatform());
        yield return new WaitForSeconds(.2f);
        yield return StartCoroutine(ShakePlatform());
        _state = State.Falling;

        while (transform.position.y > screenBounds.y * -1 + platformBounds.y / 2)
        {
            var position = transform.position;
            position += Time.deltaTime * 25 * Vector3.down;

            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + platformBounds.y / 2,
                screenBounds.y - platformBounds.y / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        _state = State.IdleDown;
        _movementLocker = false;
    }

    private IEnumerator Rise()
    {
        yield return StartCoroutine(ShakePlatform());
        _state = State.Rising;

        while (transform.position.y < screenBounds.y - platformBounds.y / 2)
        {
            var position = transform.position;
            position += Time.fixedDeltaTime * upSpeed * Vector3.up;

            if (position.y > screenBounds.y - platformBounds.y)
                StartCoroutine(DropPlayer());

            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + platformBounds.y / 2,
                screenBounds.y - platformBounds.y / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        _state = State.IdleUp;
    }

    private IEnumerator Shinee()
    {
        _state = State.Falling;
        yield return StartCoroutine(ShakePlatform());
        _rb.isKinematic = false;
        _rb.gravityScale = 5;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator DropPlayer()
    {
        var atualColor = _baseSpriteRenderer.color;
        _baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, .25f);
        if (_player != null)
            _player.parent = null;
        _collider2D.enabled = false;
        yield return new WaitForSeconds(.4f);
        _collider2D.enabled = true;
        _baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, 1f);
    }

    private IEnumerator ShakePlatform()
    {
        shake = true;
        yield return new WaitForSeconds(.4f);
        _fillAmmount = 0;
        fillPlatform.transform.localScale = new Vector3(localScale.x, _fillAmmount, localScale.z);
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
        yield return new WaitForSeconds(.4f);
        shake = false;
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(fillDelay);
        var peak = false;
        _state = State.Increasing;
        while (_fillAmmount <= 1.0f && _hasCollision)
        {
            _fillAmmount += fillRatio * 3 * Time.fixedDeltaTime;
            if (_fillAmmount > 1f)
            {
                peak = true;
                _state = State.Rising;
                continue;
            }

            fillPlatform.transform.localScale = new Vector3(localScale.x, _fillAmmount, localScale.z);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        if (!peak) yield break;
        _fillAmmount = 0f;
        fillPlatform.transform.localScale = new Vector3(localScale.x, _fillAmmount, localScale.z);

        StartCoroutine(RiseCycle());
    }

    private IEnumerator Decrease()
    {
        yield return new WaitForSeconds(fillDelay);
        _state = State.Decreasing;
        while (_fillAmmount > 0f && !_hasCollision)
        {
            _fillAmmount -= fillRatio;
            fillPlatform.transform.localScale = new Vector3(localScale.x, _fillAmmount, localScale.z);
            yield return new WaitForSeconds(fillDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player") || _state == State.MovingLeft || _state == State.MovingRight ||
            _state == State.Rising || _state == State.Falling) return;
        _player = other.collider.transform;
        _player.SetParent(transform);
        _hasCollision = true;
        if (increase != null)
            StopCoroutine(increase);
        if (decrease != null)
            StopCoroutine(decrease);

        increase = StartCoroutine(Increase());
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player") || _state == State.Rising || _state == State.Falling) return;
        _player = other.collider.transform;
        _player.SetParent(null);
        _hasCollision = false;

        if (increase != null)
            StopCoroutine(increase);
        if (decrease != null)
            StopCoroutine(decrease);
        decrease = StartCoroutine(Decrease());
    }
}