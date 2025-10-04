using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private MovableBuilding buildingPrefab;

    private bool canBuild = false;

    private BuildingElement _element;
    private MovableBuilding movableBuilding;

    private BuildingController buildingController;
    private InputController inputController;

    [Inject]
    private void Construct(BuildingController bController, InputController iController)
    {
        buildingController = bController;
        inputController = iController;
        inputController.SetPlaceAction(ActivateBuilding);
    }

    public void SetBuilding(Building building, BuildingElement buildingElement)
    {
        canBuild = true;
        if(_element == null)
        {
           movableBuilding = Instantiate(buildingPrefab);
        }
        else
        {
            _element.ResetState();
        }
        movableBuilding.Construct(building, inputController);
        _element = buildingElement;
    }

    public void Deactivate()
    {
        Destroy(movableBuilding.gameObject);
        movableBuilding = null;
        _element.ResetState();
        _element = null;
        canBuild = false;
    }


    public void ActivateBuilding()
    {
        if (movableBuilding == null)
            return;
        if (canBuild && movableBuilding.CanPlace())
        {
            movableBuilding.Place();
            buildingController.AddNewBuilding(movableBuilding.GetBuldingInfo());
            movableBuilding = null;
            _element.ResetState();
            _element = null;
            canBuild = false;
            inputController.ClearMoveAction();
            Debug.Log("+");
        }
    }

    void Update()
    {
        
    }
}
