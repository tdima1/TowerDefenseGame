using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] public List<Waypoint> _path = new List<Waypoint>();

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   public IEnumerator GoThroughPath()
   {
      foreach(Waypoint waypoint in _path) {
         transform.position = waypoint.transform.position;
         waypoint.SetTopColor(Color.blue);
         //waypoint.SetTopColor(Color.yellow);
         yield return new WaitForSeconds(1f);
      }
   }

}
