using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
   TextMesh _textMesh;
   Waypoint _waypoint;

   void Awake()
   {
      _waypoint = GetComponent<Waypoint>();
      _textMesh = GetComponentInChildren<TextMesh>();
   }

   void Update()
   {
      SnapBlockToGrid();
      UpdateLabel();
   }

   /// <summary>
   /// Makes the object snap to a grid, with the grid size defined by the object scale on all axis.
   /// </summary>
   private void SnapBlockToGrid()
   {
      transform.position = new Vector3Int(_waypoint.GetPositionInGrid().x * _waypoint.GetGridCellSize(), 0, _waypoint.GetPositionInGrid().y * _waypoint.GetGridCellSize());
   }

   private void UpdateLabel()
   {
      int _gridSize = _waypoint.GetGridCellSize();
      string coordinateLabel = (transform.position.x / _gridSize).ToString() + ":" + (transform.position.z / _gridSize).ToString();
      _textMesh.text = coordinateLabel;
      gameObject.name = coordinateLabel;
   }
}
