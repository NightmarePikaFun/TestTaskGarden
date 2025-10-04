using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController
{
    public Dictionary<string, Building> buildings;

    private List<BuildingInfo> buildingList;

    public BuildingController()
    {
        buildingList = new List<BuildingInfo>();
    }

    public void LoadBuildingSprites(List<Sprite> sprites)
    {
        foreach (var sprite in sprites)
        {
            if(buildings.ContainsKey(sprite.name))
            {
                buildings[sprite.name].SetSprite(sprite);
            }
        }
    }

    public void AddNewBuilding(BuildingInfo building)
    {
        buildingList.Add(building);
    }

    public void LoadBuildings(List<BuildingInfo> buildings)
    {
        buildingList = buildings;
    }

    public List<BuildingInfo> GetAllBuildings()
    {
        return buildingList;
    }
}
