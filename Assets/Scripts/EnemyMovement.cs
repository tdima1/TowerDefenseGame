using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Pathfinder))]
public class EnemyMovement : MonoBehaviour
{
   [SerializeField] private Pathfinder _pathfinder;

   [SerializeField] Waypoint _startWaypoint ;
   [SerializeField] Waypoint _endWaypoint;

   // Start is called before the first frame update
   void Start()
   {
      _pathfinder = FindObjectOfType<Pathfinder>();
      StartCoroutine(GoThroughPath(_pathfinder.GetPath(_startWaypoint, _endWaypoint)));
   }

   // Update is called once per frame
   void Update()
   {

   }

   public IEnumerator GoThroughPath(List<Waypoint> path)
   {
      for(int i = path.Count-1; i >=0; i--){
         Waypoint waypoint = path[i];
         transform.position = waypoint.transform.position;
         waypoint.SetTopColor(Color.blue);
         yield return new WaitForSeconds(1.5f);
      }
   }

}
