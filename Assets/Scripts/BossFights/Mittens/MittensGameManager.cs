using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public enum BossState{Waiting, One, Two, Three}

public class MittensGameManager : MonoBehaviour
{
   public static BossState _bossState;
   [SerializeField]public static int difficulty;
   [SerializeField] private GameObject boss;
   [SerializeField] private Boss dinoBoss;
   [SerializeField] private Light2D globalLight;

   private void Start()
   {
      _bossState = BossState.Waiting;
      var dinoBos = Instantiate(boss, transform.position, Quaternion.identity);
      dinoBos.transform.SetParent(transform);
      dinoBoss = dinoBos.GetComponent<Boss>();
   }

   private void Update()
   {
      if (dinoBoss.Health < dinoBoss.TotalHealth/5)
      {
         _bossState = BossState.Three;
         difficulty = 3;
         globalLight.intensity = 0.005f;
      }
      else if (dinoBoss.Health < dinoBoss.TotalHealth / 2)
      {
         _bossState = BossState.Two;
         difficulty = 2;
         globalLight.intensity = 0.05f;
      }
      else if (dinoBoss.Health < dinoBoss.TotalHealth)
      {
         _bossState = BossState.One;
         difficulty = 1;
         globalLight.intensity = 0.5f;
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

      if (sender.CompareTag(("EnemyShot")))
      {
         if (target.CompareTag("Player"))
         {
            target.GetComponent<Player>().TakeDamage(damage);
         }
      }
   }
}
