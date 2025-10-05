using FileSystem;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataLoader
{
    public static List<BuildingInfoData> LoadData(string path)
    {
        List<BuildingInfoData> loadData = new List<BuildingInfoData>();
        List<string> saveFile = FileLoader.LoadFiles(path);
        foreach (var file in saveFile)
        {
            StreamReader reader = new StreamReader(file);
            string jsonItem = reader.ReadToEnd();
            reader.Close();
            if (jsonItem == "")
                continue;
            SerializedArray<BuildingInfoData> building = JsonUtility.FromJson<SerializedArray<BuildingInfoData>>(jsonItem);
            loadData = building.Items;
        }
        return loadData;
    }
}
