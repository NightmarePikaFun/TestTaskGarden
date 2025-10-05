using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CleanerObject : MonoBehaviour
{
    private BuildingInfo building;

    private BuildingController buildingController;
    private InputController inputController;

    [Inject]
    private void Construct(BuildingController bController, InputController iController)
    {
        buildingController = bController;
        inputController = iController;
    }

    private void Awake()
    {
        DisableCleaner();
    }

    public void EnableCleaner()
    {
        inputController.SetMoveAction(MouseMove, KeyMove);
        inputController.SetPlaceAction(Clear);
        SetCleanerState(true);
    }

    public void MouseMove(Vector3Int moveVector)
    {
        transform.position = moveVector;
    }

    public void KeyMove(Vector3Int moveVector)
    {
        transform.position += moveVector;
    }

    public void Clear()
    {
        if (building != null)
        {
            buildingController.RemoveBuilding(building);
            Destroy(building.gameObject);
        }
    }

    private void SetCleanerState(bool state)
    {
        Debug.Log("+" + state);
        gameObject.SetActive(state);
    }

    public void DisableCleaner()
    {
        building = null;
        SetCleanerState(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter-"+collision.name);
        if(collision.tag == "Building")
        {
            building = collision.GetComponent<BuildingInfo>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Building")
        {
            building = null;
        }
        Debug.Log("Exit-"+collision.name);
    }
}
