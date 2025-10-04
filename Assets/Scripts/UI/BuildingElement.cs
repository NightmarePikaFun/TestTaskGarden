using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildingElement : MonoBehaviour
{
    [SerializeField]
    private Image buildingImage;
    [SerializeField]
    private Button activateButton;

    private Building currentBuilding;
    private GameController gameController;

    private bool state = false;

    public void Construct(GameController controller)
    {
        gameController = controller;
    }


    private void Awake()
    {
        activateButton.onClick.AddListener(ActivateBuilding);
    }

    public void SetBuilding(Building building)
    {
        currentBuilding = building;
        buildingImage.sprite = currentBuilding.Sprite;
    }

    public void ActivateBuilding()
    {
        //TODO change UI mb switch
        gameController.SetBuilding(currentBuilding, this);
        state = !state;
    }

    public void ResetState()
    {
        state = !state;
    }
}
