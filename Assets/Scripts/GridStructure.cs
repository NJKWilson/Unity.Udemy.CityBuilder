using System;
using UnityEngine;

public class GridStructure
{
    private readonly int _cellSize;
    private readonly int _width, _length;
    private Cell[,] _grid;
    public GridStructure(int cellSize, int width, int length)
    {
        _cellSize = cellSize;
        _width = width;
        _length = length;
        _grid = new Cell[width, length];

        for (int widthIndex = 0; widthIndex < _grid.GetLength(0); widthIndex++)
        {
            for (int lengthIndex = 0; lengthIndex < _grid.GetLength(1); lengthIndex++)
            {
                _grid[widthIndex, lengthIndex] = new Cell();
            }
        }
    }
    
    public Vector3 CalculateGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt(inputPosition.x / _cellSize);
        int z = Mathf.FloorToInt(inputPosition.z / _cellSize);
        return new Vector3(x * _cellSize, 0, z * _cellSize);
    }

    public Vector2Int CalculateGridIndex(Vector3 gridPosition)
    {
        return new Vector2Int((int)(gridPosition.x / _cellSize), (int)gridPosition.z / _cellSize);
    }

    public bool IsCellTaken(Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        if (
            cellIndex.x >= 0 
            && cellIndex.x < _grid.GetLength(1) 
            && cellIndex.y >= 0 
            && cellIndex.y < _grid.GetLength(0))
        {
            return _grid[cellIndex.x, cellIndex.y].isTaken;
        }

        throw new IndexOutOfRangeException($"Index {cellIndex} is not in grid");
    }

    public void PlaceStructureOnGrid(GameObject structure, Vector3 gridPosition)
    {
        Vector2Int cellIndex = CalculateGridIndex(gridPosition);
        
        if (IsCellTaken(gridPosition) == false)
        {
            _grid[cellIndex.x, cellIndex.y].SetConstruction(structure);
        }
        else
        {
            Debug.Log($"Can not place structure at {cellIndex}, cell is taken");
        }
    }
}
