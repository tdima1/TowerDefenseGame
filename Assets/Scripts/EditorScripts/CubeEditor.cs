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
      SnapObjectToGrid();
      UpdateLabel();
   }

   /// <summary>
   /// Makes the object snap to a grid, with the grid size defined by the object scale on all axis.
   /// </summary>
   private void SnapObjectToGrid()
   {
      transform.position = _waypoint.GetPositionInGrid();
   }

   private void UpdateLabel()
   {
      string coordinateLabel = _waypoint.GetPositionInGrid().x + ":" + _waypoint.GetPositionInGrid().z;
      _textMesh.text = coordinateLabel;
      gameObject.name = coordinateLabel;
   }
}
