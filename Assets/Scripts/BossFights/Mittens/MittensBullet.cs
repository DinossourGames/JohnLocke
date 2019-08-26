using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MittensBullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float speed;
    [SerializeField] private GameObject explosion;
    [SerializeField] private string target;
    [SerializeField] private int damage;
    [SerializeField] private int piercing;
    private float timeToDie;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        timeToDie = Time.time + lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *speed * Time.deltaTime);
        if (Time.time >= timeToDie)
            DestroyProjectile();
    }

    void DestroyProjectile()
    {
        //Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            //collision.GetComponent<enemy>().TakeDamage(damage);
            if (piercing <= 0)
                DestroyProjectile();
            else
                piercing--;
        }
    }
}
