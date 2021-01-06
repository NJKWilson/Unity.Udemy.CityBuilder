using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public InputManager inputManager;
    private GridStructure _gridStructure;
    private const int CellSize = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        _gridStructure = new GridStructure(3);
        inputManager.AddListenerOnPointerDownEvent(HandleInput);
    }

    private void HandleInput(Vector3 position)
    {
        placementManager.CreateBuilding(_gridStructure.CalculateGridPosition(position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
