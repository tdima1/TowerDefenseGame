using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
   [SerializeField] private int _hitPoints = 10;

   // Start is called before the first frame update
   void Start()
   {

   }

   private void OnParticleCollision(GameObject other)
   {
      ProcessHit();
      print(_hitPoints);
   }

   private void ProcessHit()
   {
      _hitPoints -= 1;
      if (_hitPoints <= 0) {
         KillEnemy();
      }
   }

   private void KillEnemy()
   {
      Destroy(gameObject);
   }
}
