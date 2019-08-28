using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Lifetime;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Lifetime;
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
        transform.Translate(Vector2.right * speed * MittensGameManager.difficulty * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        MittensGameManager.DealDamage(gameObject, other.gameObject, 1);
    }
}
