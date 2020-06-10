using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   const int _gridCellSize = 11;
   public bool isVisited = false;
   public Waypoint previousWaypoint;

   // Update is called once per frame
   void Update()
   {

   }

   public int GetGridCellSize()
   {
      return _gridCellSize;
   }

   /// <summary>
   /// Gets the position of the block in the grid.
   /// </summary>
   /// <returns></returns>
   public Vector2Int GetPositionInGrid()
   {
      int gridPosX = Mathf.RoundToInt(transform.position.x / _gridCellSize);
      int gridPosZ = Mathf.RoundToInt(transform.position.z / _gridCellSize);
      return new Vector2Int(gridPosX, gridPosZ);
   }

   /// <summary>
   /// Gets the Mesh renderer of the block and sets it's material.
   /// </summary>
   /// <param name="color"></param>
   public void SetTopColor(Color color)
   {
      MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
      topMeshRenderer.material.color = color;
   }

   public override bool Equals(object other)
   {
      return this.GetPositionInGrid().Equals((other as Waypoint).GetPositionInGrid()); 
   }

   public override int GetHashCode()
   {
      return base.GetHashCode();
   }
}
