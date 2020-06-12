using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
   Dictionary<Vector2Int, Waypoint> _grid = new Dictionary<Vector2Int, Waypoint>();
   Vector2Int[] _directions = {
      Vector2Int.up,
      Vector2Int.right,
      Vector2Int.down,
      Vector2Int.left
   };

   public List<Waypoint> _path = new List<Waypoint>();

   void Start()
   {
      
   }

   // Update is called once per frame
   void Update()
   {

   }

   private void LoadGrid()
   {
      var waypoints = FindObjectsOfType<Waypoint>();
      foreach (Waypoint waypoint in waypoints) {
         bool isOverlapping = _grid.ContainsKey(waypoint.GetPositionInGrid());
         if (isOverlapping) {
            waypoint.isVisited = false;
            Debug.Log("Overlapping block " + waypoint);
         } else {
            _grid.Add(waypoint.GetPositionInGrid(), waypoint);
         }
      }
      print(_grid.Count);
   }

   public void ColorStartAndEndWaypoints(Waypoint start, Waypoint end)
   {
      start.SetTopColor(Color.green);
      end.SetTopColor(Color.red);
   }

   public List<Waypoint> GetPath(Waypoint start, Waypoint end)
   {
      LoadGrid();
      ColorStartAndEndWaypoints(start, end);
      _path = BreadthFirstSearch(start, end);
      return _path;
   }

   /// <summary>
   /// Breadth first pathfinding algorithm.
   /// </summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   public List<Waypoint> BreadthFirstSearch(Waypoint start, Waypoint end)
   {
      //Can't have start equal to end.
      if (start.Equals(end)) {
         return new List<Waypoint>();
      }

      Queue<Waypoint> queue = new Queue<Waypoint>();
      queue.Enqueue(start);

      while (queue.Count > 0) {
         Waypoint currentWaypoint = queue.Dequeue();

         if (currentWaypoint.Equals(end)) {
            return Backtrack(start, end);
         } else {
            _grid[currentWaypoint.GetPositionInGrid()].isVisited = true;
            ExploreNeighbours(currentWaypoint, queue);
         }
      }

      //Path not found
      return new List<Waypoint>();
   }

   /// <summary>
   /// From the endpoint, goes through all the previous waypoints until it reaches start, recreating the path.
   /// </summary>
   /// <param name="start"></param>
   /// <param name="end"></param>
   private List<Waypoint> Backtrack(Waypoint start, Waypoint end)
   {
      Waypoint tracker = end;
      List<Waypoint> path = new List<Waypoint>();

      while(!tracker.Equals(start)) {
         path.Add(tracker);
         tracker = tracker.previousWaypoint;
      }
      path.Add(start);

      return path;
   }

   /// <summary>
   /// Checks if the current waypoint has any unvisited neighbours in the up, right, down, left directions.
   /// </summary>
   /// <param name="waypoint"></param>
   /// <param name="queue"></param>
   private void ExploreNeighbours(Waypoint waypoint, Queue<Waypoint> queue)
   {
      foreach (Vector2Int direction in _directions) {
         Vector2Int neighbourKey = new Vector2Int(waypoint.GetPositionInGrid().x + direction.x, waypoint.GetPositionInGrid().y + direction.y);

         if (_grid.ContainsKey(neighbourKey)) {
            Waypoint currentNeighbourWaypoint = _grid[neighbourKey];

            if (!currentNeighbourWaypoint.isVisited) {
               currentNeighbourWaypoint.previousWaypoint = waypoint;
               queue.Enqueue(currentNeighbourWaypoint);
            }
         }
      }
   }


}
