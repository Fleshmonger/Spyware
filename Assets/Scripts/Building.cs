using UnityEngine;
using System.Collections;

public abstract class Building : MonoBehaviour
{
    public abstract void Arrive(Vehicle vehicle);
}
