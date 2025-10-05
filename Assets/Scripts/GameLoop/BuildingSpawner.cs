using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingSpawner : MonoBehaviour
{
    [SerializeField]
    private BuildingInfo buildingPrefab;

    private BuildingController buildingController;

    [Inject]
    private void Construct(BuildingController bController)
    {
        buildingController = bController;
    }

    public void SpawnBuilding(List<BuildingInfoData> data)
    {
        foreach(var item in data)
        {
            BuildingInfo buildingInfo = Instantiate(buildingPrefab);
            buildingInfo.Construct(buildingController.GetBuilding(item.Id));
            buildingInfo.transform.position = item.Position;
            buildingController.AddNewBuilding(buildingInfo);
        }
    }
}
