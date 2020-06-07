using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
   [SerializeField] [Range(1f, 20f)] int _gridSize = 10;
   TextMesh _textMesh;

   void Awake()
   {
      _textMesh = GetComponentInChildren<TextMesh>();
   }

   void Update()
   {
      SnapObjectToGrid();
      UpdateGridCoordText();
   }

   /// <summary>
   /// Makes the object snap to a grid, with the grid size defined by the object scale on all axis.
   /// </summary>
   private void SnapObjectToGrid()
   {
      float snapPosX = Mathf.RoundToInt(transform.position.x / _gridSize) * _gridSize;
      float snapPosY = Mathf.RoundToInt(transform.position.y / _gridSize) * _gridSize;
      float snapPosZ = Mathf.RoundToInt(transform.position.z / _gridSize) * _gridSize;
      transform.position = new Vector3(snapPosX, snapPosY, snapPosZ);
   }

   private void UpdateGridCoordText()
   {
      _textMesh.text = (transform.position.x / _gridSize).ToString() + ":" + (transform.position.z / _gridSize).ToString();
   }
}
