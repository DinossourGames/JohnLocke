using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Object = UnityEngine.Object;

public enum BossState{Waiting, One, Two, Three}

public class MittensGameManager : MonoBehaviour
{
   [SerializeField] private BossState _bossState;
   [SerializeField] private GameObject boss;
   [SerializeField] private Boss dinoBoss;

   private void Start()
   {
      var dinoBos = Instantiate(boss, transform.position, Quaternion.identity);
      dinoBos.transform.SetParent(transform);
      dinoBoss = dinoBos.GetComponent<Boss>();
   }

   private void Update()
   {
      if (dinoBoss.Health < dinoBoss.TotalHealth)
      {
         print("yay");
      }
   }

   public static void DealDamage(GameObject sender, GameObject target, int damage)
   {
      
      
      if (sender.CompareTag("MittensBullet"))
      {
         if (target.CompareTag("Boss"))
         {
            print("da");
            target.GetComponent<Boss>().TakeDamage(damage);
         }
         else if (target.CompareTag("Missile"))
         {
            //target.GetComponent<>()
         }
      }
   }
}
