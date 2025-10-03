using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Bootstrap : MonoBehaviour
{
    public Dictionary<string, Building> buildings;

    // Start is called before the first frame update
    void Start()
    {
        LoadBuildings();
        //Next load or something
    }

    public void LoadBuildings()
    {
        buildings = new Dictionary<string, Building>();
        List<string> files = FileLoader.LoadFiles("resources/items");//GetFiles("resources/items");
        foreach (string file in files)
        {
            StreamReader reader = new StreamReader(file);
            string jsonItem = reader.ReadToEnd();
            reader.Close();
            if (jsonItem == "")
                continue;
            Building building = JsonUtility.FromJson<Building>(jsonItem);
            buildings.Add(building.Id,building);

        }
    }
}
