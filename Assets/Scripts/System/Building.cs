using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Building
{
    public string _id;
    public string _name;
    public int _cost;
    public int _production;
    public int _workTime;
    public string _spriteName;

    public Sprite Sprite { get; private set; }

    public string Id
    {
        get => _id;
    }

    public string Name
    {
        get => _name;
    }

    public int Cost
    {
        get => _cost;
    }

    public int Production
    {
        get => _production;
    }

    public int WorkTime
    {
        get => _workTime;
    }

    public Building(string id, string name, int cost, int production, int workTime, string spriteName)
    {
        _id = id;
        _name = name;
        _cost = cost;
        _production = production;
        _workTime = workTime;
        _spriteName = spriteName;
    }

    public void SetSprite(Sprite sprite) => Sprite = sprite;
}
