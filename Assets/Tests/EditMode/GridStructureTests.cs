using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTests
{
    private GridStructure gridStructure;
    
    [OneTimeSetUp]
    public void init()
    {
        gridStructure = new GridStructure(3, 100, 100);
    }
    
    
    // A Test behaves as an ordinary method
    [Test]
    public void GridStructureTestsSimplePasses()
    {
        Assert.NotNull(gridStructure);
    }
    
    [Test]
    public void CalculateGridPosition_0_Pass(
        [Random(0f,2.9f,5)] float x,
        [Random(0f,2.9f,5)] float y,
        [Random(0f,2.9f,5)] float z )
    {
        // Arrange
        Vector3 inputPosition = new Vector3(x, y, z);
        Vector3 expectedPosition = new Vector3(0,0,0);

        // Act
        Vector3 returnedPosition = gridStructure.CalculateGridPosition(inputPosition);
        
        // Assert
        Assert.AreEqual(expectedPosition, returnedPosition);
    }
    
    [Test]
    public void CalculateGridPosition_3_Pass(
        [Random(3f,5.9f,5)] float x,
        [Random(3f,5.9f,5)] float y,
        [Random(3f,5.9f,5)] float z )
    {
        // Arrange
        Vector3 inputPosition = new Vector3(x, y, z);
        Vector3 expectedPosition = new Vector3(3,0,3);

        // Act
        Vector3 returnedPosition = gridStructure.CalculateGridPosition(inputPosition);
        
        // Assert
        Assert.AreEqual(expectedPosition, returnedPosition);
    }
    
    [Test]
    public void CalculateGridPosition_0_X_Fail(
        [Random(3f,5.9f,5)] float x,
        [Random(0f,2.9f,5)] float y,
        [Random(0f,2.9f,5)] float z )
    {
        // Arrange
        Vector3 inputPosition = new Vector3(x, y, z);
        Vector3 expectedPosition = new Vector3(0,0,0);

        // Act
        Vector3 returnedPosition = gridStructure.CalculateGridPosition(inputPosition);
        
        // Assert
        Assert.AreNotEqual(expectedPosition, returnedPosition);
    }
    
    [Test]
    public void CalculateGridPosition_0_Z_Fail(
        [Random(0f,2.9f,5)] float x,
        [Random(0f,2.9f,5)] float y,
        [Random(3f,5.9f,5)] float z )
    {
        // Arrange
        Vector3 inputPosition = new Vector3(x, y, z);
        Vector3 expectedPosition = new Vector3(0,0,0);

        // Act
        Vector3 returnedPosition = gridStructure.CalculateGridPosition(inputPosition);
        
        // Assert
        Assert.AreNotEqual(expectedPosition, returnedPosition);
    }
    
    [Test]
    public void CalculateGridIndex_1_Pass()
    {
        // Arrange
        Vector3 inputPosition = new Vector3(3, 3, 3);
        Vector2Int expectedPosition = new Vector2Int(1,1);

        // Act
        Vector2Int returnedPosition = gridStructure.CalculateGridIndex(inputPosition);
        
        // Assert
        Assert.AreEqual(expectedPosition, returnedPosition);
    }
    
    [Test]
    public void IsCellTaken_False_Pass()
    {
        // Arrange
        Vector3 inputPosition = new Vector3(3, 3, 3);
        Vector2Int expectedPosition = new Vector2Int(1,1);

        // Act
        Vector2Int returnedPosition = gridStructure.CalculateGridIndex(inputPosition);
        
        // Assert
        Assert.AreEqual(expectedPosition, returnedPosition);
    }
}
