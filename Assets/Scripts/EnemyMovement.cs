using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] List<Waypoint> _path;

   // Start is called before the first frame update
   void Start()
   {
      StartCoroutine(GoThroughPath());
   }

   IEnumerator GoThroughPath()
   {
      foreach(Waypoint waypoint in _path) {
         transform.position = waypoint.transform.position;
         yield return new WaitForSeconds(1f);
      }
   }

   // Update is called once per frame
   void Update()
   {

   }
}
