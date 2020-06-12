using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
   [SerializeField] Transform _target;
   [SerializeField] float _firingRange = 20f;
   private ParticleSystem _bullets;

   Transform _turretTop;


   void Start()
   {
      _turretTop = transform.Find("Top");
      _bullets = _turretTop.Find("Bullets").GetComponent<ParticleSystem>();
   }

   // Update is called once per frame
   void Update()
   {
      if (_target != null) {
         _turretTop.LookAt(_target, Vector3.up);
         FireAtTarget(IsInFiringDistance());
      } else {
         FireAtTarget(false);
      }
   }

   private void FireAtTarget(bool isActive)
   {
      var emissionModule = _bullets.emission;
      emissionModule.enabled = isActive;
   }

   private bool IsInFiringDistance()
   {
      if (Vector3.Distance(_target.localPosition, _turretTop.localPosition) <= _firingRange) {
         return true;
      }
      return false;
   }

}
