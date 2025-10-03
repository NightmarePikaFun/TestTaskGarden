using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public int Cost { get; private set; }
    public int Production { get; private set; }
    public int WorkTime { get; private set; }

    public Building(string id ,string name, int cost, int production, int workTime)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Production = production;
        WorkTime = workTime;
    }   
}
