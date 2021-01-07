using Unity.Mathematics;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject buildingPrefab;
    public Transform groundTransform;
    public void CreateBuilding(Vector3 gridPosition, GridStructure grid)
    {
        if (grid.IsCellTaken(gridPosition)) return;
        
        GameObject newStructure = Instantiate(
            buildingPrefab,
            groundTransform.position + gridPosition,
            quaternion.identity);
        
        grid.PlaceStructureOnGrid(newStructure, gridPosition);
    }
}
