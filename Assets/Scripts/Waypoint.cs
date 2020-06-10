using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
   const int _gridCellSize = 11;
   Vector3Int _positionInGrid;

   public int GetGridCellSize()
   {
      return _gridCellSize;
   }

   public Vector3 GetPositionInGrid()
   {
      float gridPosX = Mathf.RoundToInt(transform.position.x / _gridCellSize);
      float gridPosY = Mathf.RoundToInt(transform.position.y / _gridCellSize);
      float gridPosZ = Mathf.RoundToInt(transform.position.z / _gridCellSize);
      return new Vector3(gridPosX, gridPosY, gridPosZ);
   }

   public void SetTopColor(Color color)
   {
      MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
      topMeshRenderer.material.color = color;
   }

   // Update is called once per frame
   void Update()
   {

   }
}
