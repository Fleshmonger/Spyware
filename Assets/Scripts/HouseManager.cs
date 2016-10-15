using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HouseManager : MonoBehaviour
{
    private List<House> free = new List<House>(), occupied = new List<House>();

    public static HouseManager _instance;
    public House[] houses;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void FreeHouse(House house)
    {
        occupied.Remove(house);
        free.Add(house);
    }

    public void OccupyHouse(House house)
    {
        free.Remove(house);
        occupied.Add(house);
    }

    public House RandFreeHouse()
    {
        if (free.Count > 0)
        {
            return free[Random.Range(0, free.Count)];
        }
        else
        {
            return null;
        }
    }
}