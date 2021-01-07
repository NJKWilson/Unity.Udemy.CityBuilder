using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public InputManager inputManager;
    public int width, length;
    private GridStructure _gridStructure;
    private const int CellSize = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        _gridStructure = new GridStructure(3, width, length);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        Vector3 gridPosition = _gridStructure.CalculateGridPosition(position);
        if (!_gridStructure.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, _gridStructure);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
