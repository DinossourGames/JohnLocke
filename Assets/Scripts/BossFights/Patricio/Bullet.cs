using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifeSpan;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;

    private Rigidbody2D rbd;

    public GameObject Parent;
    public Vector2 Direction;

    private void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        rbd.mass = 0;
        rbd.gravityScale = 0;
        rbd.velocity = Direction * speed;
        Invoke("DestroyProjectile", lifeSpan);
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(Parent))
            return;

    }
}
