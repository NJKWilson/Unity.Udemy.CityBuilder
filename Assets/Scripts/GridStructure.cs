using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
    private readonly int cellSize;

    public GridStructure(int cellSize)
    {
        this.cellSize = cellSize;
    }
    
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x / cellSize);
        int z = Mathf.FloorToInt(inputPosition.z / cellSize);
        return new Vector3(x * cellSize, 0, z * cellSize);
    }
}
