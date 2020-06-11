using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinder))]
public class EnemyMovement : MonoBehaviour
{
   [SerializeField] Pathfinder _pathfinder;
   [SerializeField] Waypoint _startWaypoint;
   [SerializeField] Waypoint _endWaypoint;

   List<Waypoint> _path = new List<Waypoint>();

   // Start is called before the first frame update
   void Start()
   {
      _path = _pathfinder.BreadthFirst(_startWaypoint, _endWaypoint);
      _pathfinder.ColorStartAndEndWaypoints(_startWaypoint, _endWaypoint);
      StartCoroutine(GoThroughPath());
   }

   // Update is called once per frame
   void Update()
   {

   }

   public IEnumerator GoThroughPath()
   {
      for(int i = _path.Count-1; i >=0; i--){
         Waypoint waypoint = _path[i];
         transform.position = waypoint.transform.position;
         waypoint.SetTopColor(Color.blue);
         //waypoint.SetTopColor(Color.yellow);
         yield return new WaitForSeconds(1f);
      }
   }

}
