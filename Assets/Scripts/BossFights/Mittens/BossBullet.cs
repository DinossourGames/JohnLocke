using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Lifetime;
    [SerializeField, Range(0f,1f)] private float intensity; 
    private float timeToDie;
    

    // Start is called before the first frame update
    private void Start()
    {
        timeToDie = Time.time + Lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToDie)
            Destroy(gameObject);
        transform.Translate(Vector2.right * speed * MittensGameManager.difficulty * intensity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss") || other.CompareTag("Missile")) return;
        MittensGameManager.DealDamage(gameObject, other.gameObject, 1);
        Destroy(gameObject);
    }
}
