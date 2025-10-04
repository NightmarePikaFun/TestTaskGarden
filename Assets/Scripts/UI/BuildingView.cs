using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameData;

public class BuildingView : MonoBehaviour
{
    [SerializeField]
    private BuildingElement buildingPrefab;
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private List<BuildingElement> buildings;

    private BuildingController buildingController;
    private GameController gameController;

    [Inject]
    private void Construct(GameController gController ,BuildingController bController)
    {
        gameController = gController;
        buildingController = bController;
    }

    private void Start()
    {
        InitBuildings();
    }

    public void Initialize()
    {
        canvasGroup.alpha = 0;
    }

    public void SwitchView()
    {
        canvasGroup.alpha = canvasGroup.alpha == 1 ? 0 : 1;
    }

    public void InitBuildings()
    {
        foreach (var building in buildingController.buildings)
        {
            BuildingElement buildingElement = Instantiate(buildingPrefab, transform);
            buildingElement.Construct(gameController);
            buildings.Add(buildingElement);
            buildingElement.SetBuilding(building.Value);
        }
    }
}
