using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class DataSaver
{
    public static void SaveData(List<BuildingInfo> buildings, string path)
    {
        SerializedArray<BuildingInfoData> data = ConvertToSaveData(buildings);
        string saveData = JsonUtility.ToJson(data);
        Save(saveData, path);
    }


    private static void Save(string data, string path)
    {
        StreamWriter writer = new StreamWriter(path,false);
        writer.Write(data);
        writer.Close();
    }

    private static SerializedArray<BuildingInfoData> ConvertToSaveData(List<BuildingInfo> buildings)
    {
        SerializedArray<BuildingInfoData> savedData;
        List<BuildingInfoData> list = new List<BuildingInfoData>();
        foreach(var bulding in buildings)
        {
            BuildingInfoData info = new BuildingInfoData(bulding);
            list.Add(info);
        }
        savedData = new SerializedArray<BuildingInfoData>(list);
        return savedData;
    }
}

