using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameData;
using System;

public class FileController : MonoBehaviour
{
    private string loadPath = "savedata";
    private string savePath = "savedata/save.json";

    private BuildingController buildingController;
    [Inject]
    private void Construct(BuildingController bController)
    {
        buildingController = bController;
    }

    public void SaveData()
    {
        DataSaver.SaveData(buildingController.GetAllBuildings(), savePath);
    }

    public List<BuildingInfoData> LoadData()
    {
        return DataLoader.LoadData(loadPath);
    }
}

[Serializable]
public class SerializedArray<T>
{
    public List<T> Items;

    public SerializedArray(List<T> items)
    {
        Items = items; 
    }
}
