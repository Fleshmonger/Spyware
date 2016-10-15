using UnityEngine;
using System.Collections;

public abstract class Node : MonoBehaviour
{
    public Building[] buildings;

    public void Arrive(Vehicle vehicle)
    {
        foreach (Building building in buildings)
        {
            building.Arrive(vehicle);
        }
    }

    public abstract Node GetTarget(Node from);
}