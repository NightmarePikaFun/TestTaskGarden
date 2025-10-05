using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Building currentBuilding;

    public void Construct(Building building)
    {
        currentBuilding = building;
        spriteRenderer.sprite = building.Sprite;
    }

    public Building GetBuilding() => currentBuilding;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
