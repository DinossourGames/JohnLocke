using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

enum State
{
    Rising,
    Falling,
    MovingRight,
    MovingLeft,
    Idle
}

public class Platform : MonoBehaviour
{
    [SerializeField, Header("Fill Atributes")]
    private GameObject fillPlatform;

    [SerializeField] private State state = State.Idle;
    [SerializeField, Range(0f, 1f)] private float fillRatio;
    [SerializeField, Range(0f, 3f)] private float fillDelay;

    private float fillAmmount;
    [SerializeField] private bool _hasCollision;

    // Screen bounds
    private float top;
    private float bottom;
    private float left;
    private float right;

    private void Start()
    {
        top = Screen.safeArea.yMin;
        bottom = Screen.safeArea.yMax;
        left = Screen.safeArea.xMin;
        right = Screen.safeArea.xMax;
    }

 

    private IEnumerator Increase()
    {
        yield return new WaitForSeconds(fillDelay);

        while (fillAmmount < 1f && _hasCollision)
        {
            if (fillAmmount > 1f)
            {
                fillAmmount = 0f;
                yield return null;
            }

            fillAmmount += fillRatio;
            var localScale = fillPlatform.transform.localScale;
            fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);
            yield return new WaitForSeconds(fillDelay);
        }
    }

    private IEnumerator Decrease()
    {
        yield return new WaitForSeconds(fillDelay);

        while (fillAmmount > 0f && !_hasCollision)
        {
            if (fillAmmount < 0f)
            {
                fillAmmount = 0f;
                yield return null;
            }

            fillAmmount -= fillRatio;
            var localScale = fillPlatform.transform.localScale;
            fillPlatform.transform.localScale = new Vector3(localScale.x, fillAmmount, localScale.z);
            yield return new WaitForSeconds(fillDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        _hasCollision = true;
        StartCoroutine(Increase());

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.collider.CompareTag("Player")) return;
        _hasCollision = false;
        StartCoroutine(Decrease());

    }
}