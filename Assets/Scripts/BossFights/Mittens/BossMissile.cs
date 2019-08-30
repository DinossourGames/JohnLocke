using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class BossMissile : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer sprite;
    private Vector2 direction;
    private float angle;
    private Quaternion rotation;
    [SerializeField] private GameObject explosion;

    [SerializeField] private bool canStart;
    [SerializeField] private float delay;
    private float timeToDie;
    [SerializeField] private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();
        timeToDie = Time.time + lifetime;
        StartCoroutine(Delay(delay));
    }

    private void Update()
    {
        if(Time.time >= timeToDie)
            DestroyMissile();
        if (player != null && canStart)
        {
            var p = player.position;
            direction = new Vector2
            {
                x = p.x - transform.position.x,
                y = p.y - transform.position.y
            };
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = rotation;

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(1.5f * speed * Time.deltaTime * Vector2.right);
        }
    }

    public void TakeDamage()
    {

        health--;
        sprite.color = new Color32(255, 38, 52, 255);
        if (health <= 0)
        {
            DestroyMissile();
        }
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canStart = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        MittensGameManager.DealDamage(gameObject, other.gameObject, 1);
    }

    public void DestroyMissile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
