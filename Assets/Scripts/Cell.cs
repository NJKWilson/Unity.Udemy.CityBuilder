using UnityEngine;

public class Cell
{
    private GameObject _structureModel = null;
    private bool _isTaken = false;
    
    public bool isTaken
    {
        get => _isTaken;
    }

    public void SetConstruction(GameObject structuralModel)
    {
        _structureModel = structuralModel;
        _isTaken = true;
    }
}
