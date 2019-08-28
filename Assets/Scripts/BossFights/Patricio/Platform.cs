using System.Collections;
using UnityEngine;
#pragma warning disable 414

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
    [SerializeField, Header("Platform Configuration")]
    private GameObject fillPlatform;

    [SerializeField] private State state;
    [SerializeField, Space] private bool isTop;
    [SerializeField] private GameObject basePlatform;
    [SerializeField, Range(0f, 1f)] private float fillRatio;
    [SerializeField, Range(0f, 3f)] private float fillDelay;
    [SerializeField, Range(1, 15)] private float upSpeed;
    private Vector3 _localScale;
    private float _fillAmmount;
    private bool _hasCollision;

    public bool movementLocker;

    // Screen bounds
    [SerializeField, Header("Boundaries"), Space]
    private Camera mainCamera;

    [SerializeField] private Vector2 screenBounds;

    // Sprite Bounds
    private BoxCollider2D _collider2D;

    [SerializeField] private Vector2 platformBounds;

    //references
    private Transform _player;
    private SpriteRenderer _baseSpriteRenderer;
    private Rigidbody2D _rb;

    private Coroutine _decrease;
    private Coroutine _increase;

    private bool _shake;
    [SerializeField] private float scaleY;
    [SerializeField] private float safeOffset;


    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        state = State.IdleDown;
        _collider2D = GetComponent<BoxCollider2D>();
        _localScale = fillPlatform.transform.localScale;
        _baseSpriteRenderer = basePlatform.GetComponent<SpriteRenderer>();
        platformBounds = new Vector2(_baseSpriteRenderer.size.x,_baseSpriteRenderer.size.y);
        scaleY = transform.localScale.y;
        safeOffset = 0.01f;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _collider2D.size = _baseSpriteRenderer.size * _baseSpriteRenderer.transform.localScale;

        var position = transform.position;
        isTop = position.y > screenBounds.y / 2;
    }

    public void UpdateState(PlatformPosition update)
    {
        var position = transform.position;
        var distance = Vector3.Distance(position, update.Position.center);
        var direction = position.x - update.Position.center.x > 0; //  > 0 - right | < 0 -left

        if (state == State.Rising || state == State.Falling || state == State.IdleUp ||
            state == State.MovingLeft ||
            state == State.MovingRight || movementLocker)
            return;

        var yDiff = Mathf.Abs(transform.position.y - update.Position.center.y);

        if (distance < 3.4f && distance > 2.5f && yDiff < .4f)
        {
            if (BossFightManager.BossSide == BossSide.Right)
            {
                if (direction)
                {
                    movementLocker = true;
                    StartCoroutine(Move(update.Position.center, true));
                }
            }

            if (BossFightManager.BossSide == BossSide.Left)
            {
                if (!direction)
                {
                    movementLocker = true;
                    StartCoroutine(Move(update.Position.center, false));
                }
            }
        }
    }


    private IEnumerator Move(Vector2 endpoint, bool movingLeft)
    {
        if (_increase != null)
            StopCoroutine(_increase);
        if (_decrease != null)
            StopCoroutine(_decrease);

        state = movingLeft ? State.MovingLeft : State.MovingRight;
        yield return StartCoroutine(ShakePlatform());

        while (Vector2.Distance(transform.position, endpoint) > .1f)
        {
            transform.position += Time.deltaTime * upSpeed * (movingLeft ? Vector3.left : Vector3.right);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = isTop ? State.IdleUp : State.IdleDown;
        if (_hasCollision)
            _increase = StartCoroutine(Increase());
        yield return new WaitForSeconds(2f);
        movementLocker = false;
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
        state = State.MovingRight;

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

        state = isTop ? State.IdleUp : State.IdleDown;
    }

    private IEnumerator GoLeft()
    {
        yield return StartCoroutine(ShakePlatform());
        state = State.MovingLeft;
        var bounds = _baseSpriteRenderer.bounds;
        var bound = new Vector2(screenBounds.x * -1 + bounds.extents.x, transform.position.y);

        while (Vector2.Distance(transform.position, bound) > 0)
        {
            var position = transform.position;
            position += Time.deltaTime * upSpeed * Vector3.left;

            position.x = Mathf.Clamp(position.x, screenBounds.x * -1 + bounds.extents.x,
                screenBounds.x - bounds.extents.x);

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

        while (transform.position.y > screenBounds.y * -1 +  (scaleY + 0.01f) / 2)
        {
            var position = transform.position;
            position += Time.deltaTime * 25 * Vector3.down;

            
            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 + (scaleY + 0.01f) / 2,
                screenBounds.y -(platformBounds.y - scaleY + 0.01f) / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        state = State.IdleDown;
        movementLocker = false;
    }

    private IEnumerator Rise()
    {
        yield return StartCoroutine(ShakePlatform());
        state = State.Rising;

        while (transform.position.y < screenBounds.y - (platformBounds.y - scaleY + safeOffset) / 2)
        {
            var position = transform.position;
            position += Time.fixedDeltaTime * upSpeed * Vector3.up;

            if (position.y > screenBounds.y - platformBounds.y)
                StartCoroutine(DropPlayer());

            position.y = Mathf.Clamp(position.y, screenBounds.y * -1 +  (platformBounds.y - scaleY + safeOffset) / 2,
                screenBounds.y -  (platformBounds.y - scaleY + safeOffset) / 2);

            transform.position = position;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        state = State.IdleUp;
    }

    private IEnumerator Shinee()
    {
        state = State.Falling;
        yield return StartCoroutine(ShakePlatform());
        _rb.isKinematic = false;
        _rb.gravityScale = 5;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator DropPlayer()
    {
        _hasCollision = false;
        var atualColor = _baseSpriteRenderer.color;
        _baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, .25f);
        if (_player != null)
            _player.parent = null;
        _collider2D.enabled = false;
        yield return new WaitForSeconds(.4f);
        // ReSharper disable once Unity.InefficientPropertyAccess
        _collider2D.enabled = true;
        _baseSpriteRenderer.color = new Color(atualColor.r, atualColor.g, atualColor.b, 1f);
    }

    private IEnumerator ShakePlatform()
    {
        _shake = true;
        yield return new WaitForSeconds(.4f);
        _fillAmmount = 0;
        fillPlatform.transform.localScale = new Vector3(_localScale.x, _fillAmmount, _localScale.z);
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
        _shake = false;
    }

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(fillDelay);
        var peak = false;
        state = State.Increasing;
        while (_fillAmmount <= 1.0f && _hasCollision)
        {
            _fillAmmount += fillRatio * 3 * Time.fixedDeltaTime;
            if (_fillAmmount > 1f)
            {
                peak = true;
                state = State.Rising;
                continue;
            }

            fillPlatform.transform.localScale = new Vector3(_localScale.x, _fillAmmount, _localScale.z);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        if (!peak) yield break;
        _fillAmmount = 0f;
        fillPlatform.transform.localScale = new Vector3(_localScale.x, _fillAmmount, _localScale.z);

        StartCoroutine(RiseCycle());
    }

    private IEnumerator Decrease()
    {
        yield return new WaitForSeconds(fillDelay);
        state = State.Decreasing;
        while (_fillAmmount > 0f && !_hasCollision)
        {
            _fillAmmount -= fillRatio * 3 * Time.fixedDeltaTime;
            if (_fillAmmount < 0)
                _fillAmmount = 0;

            fillPlatform.transform.localScale = new Vector3(_localScale.x, _fillAmmount, _localScale.z);
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || state == State.MovingLeft || state == State.MovingRight ||
            state == State.Rising || state == State.Falling) return;
        _player = other.transform;
        _player.SetParent(transform);
        _hasCollision = true;
        if (_increase != null)
            StopCoroutine(_increase);
        if (_decrease != null)
            StopCoroutine(_decrease);

        _increase = StartCoroutine(Increase());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || state == State.Rising || state == State.Falling) return;
        _player = other.transform;
        _player.SetParent(null);
        _hasCollision = false;

        if (_increase != null)
            StopCoroutine(_increase);
        if (_decrease != null)
            StopCoroutine(_decrease);
        _decrease = StartCoroutine(Decrease());
    }
}