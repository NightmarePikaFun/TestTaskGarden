using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController
{
    public Dictionary<string, Building> buildings;

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
}
