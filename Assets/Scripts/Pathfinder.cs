using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
   Dictionary<Vector3, Waypoint> _grid = new Dictionary<Vector3, Waypoint>();

   [SerializeField] Waypoint _startWaypoint;
   [SerializeField] Waypoint _endWaypoint;

   void Start()
    {
      LoadGrid();
      ColorStartAndEndWaypoints();
    }

   private void LoadGrid()
   {
      var waypoints = FindObjectsOfType<Waypoint>();
      foreach (Waypoint waypoint in waypoints) {
         bool isOverlapping = _grid.ContainsKey(waypoint.GetPositionInGrid());
         if (isOverlapping) {
            Debug.Log("Overlapping block " + waypoint);
         } else { 
            _grid.Add(waypoint.GetPositionInGrid(), waypoint);
         }
      }
      print(_grid.Count);
   }

   private void ColorStartAndEndWaypoints()
   {
      _startWaypoint.SetTopColor(Color.green);
      _endWaypoint.SetTopColor(Color.red);
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
