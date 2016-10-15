using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmergencyController : MonoBehaviour
{
    private float timer = 0f;

    public Service[] services;
    public float delayMin = 10f, delayMax = 20f;

    public void Awake()
    {
        timer = RandomDelay();
    }

    private float RandomDelay()
    {
        return Random.Range(delayMin, delayMax);
    }

    private Service RandomEmergency()
    {
        if (services.Length > 0)
        {
            return services[Random.Range(0, services.Length)];
        }
        else
        {
            return null;
        }
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            House house = HouseManager._instance.RandFreeHouse();
            if (house != null)
            {
                house.SetEmergency(RandomEmergency());
                HouseManager._instance.OccupyHouse(house);
            }
            timer += RandomDelay();
        }
    }
}