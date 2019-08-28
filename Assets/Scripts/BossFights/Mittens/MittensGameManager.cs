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
      }
   }

   public static void DealDamage(GameObject sender, GameObject target, int damage)
   {
      
      
      if (sender.CompareTag("MittensBullet"))
      {
         if (target.CompareTag("Boss"))
         {
            target.GetComponent<Boss>().TakeDamage(damage);
         }
         if (target.CompareTag("Missile"))
         {
            print("yay");
            target.GetComponent<BossMissile>().TakeDamage();
         }
      } 
      if (sender.CompareTag(("Boss")))
      {
         if(target.CompareTag("Player"))
         {
            target.GetComponent<Player>().TakeDamage(damage);
         }
      }
      if (sender.CompareTag("Missile"))
      {
         if (target.CompareTag("Player"))
         {
            target.GetComponent<Player>().TakeDamage(damage);
            sender.GetComponent<BossMissile>().DestroyMissile();
         }
      }
   }
}
