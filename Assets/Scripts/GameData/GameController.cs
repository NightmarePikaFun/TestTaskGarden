using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Building currentBuilding { get; private set; }

    private bool canBuild = false;

    private BuildingElement _element;

    public void SetBuilding(Building building, BuildingElement buildingElement)
    {
        currentBuilding = building;
        canBuild = true;
        if(_element != null)
        {
            _element.ResetState();
        }
        _element = buildingElement;
    }

    public void Deactivate()
    {

    }


    public void ActivateBuilding()
    {
        
    }

    void Update()
    {
        
    }
}
