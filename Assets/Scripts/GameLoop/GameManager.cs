using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using GameData;
using FileSystem;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> sprites;

    public Dictionary<string, Building> buildings;

    private BuildingController buildingController;
    private List<Building> buildingList;

    [Inject]
    private void Construct(BuildingController controller)
    {
        buildingController = controller;
    }

    private void Start()
    {
        LoadBuildings();
        buildingController.buildings = buildings;
        buildingController.LoadBuildingSprites(sprites);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadBuildings()
    {
        buildings = new Dictionary<string, Building>();
        List<string> files = FileLoader.LoadFiles("resources/buildings");
        foreach (string file in files)
        {
            StreamReader reader = new StreamReader(file);
            string jsonItem = reader.ReadToEnd();
            reader.Close();
            if (jsonItem == "")
                continue;
            Building building = JsonUtility.FromJson<Building>(jsonItem);
            buildings.Add(building.Id, building);

        }
    }
}

