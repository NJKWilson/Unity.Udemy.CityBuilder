using Unity.Mathematics;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public GameObject buildingPrefab;
    public Transform groundTransform;
    public void CreateBuilding(Vector3 gridPosition)
    {
        Instantiate(
            buildingPrefab,
            groundTransform.position + gridPosition,
            quaternion.identity);
    }
}
