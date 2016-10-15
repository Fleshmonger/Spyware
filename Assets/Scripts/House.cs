using UnityEngine;
using System.Collections;

public class House : Building
{
    public Service emergency;

    override public void Arrive(Vehicle vehicle)
    {
        if (vehicle.service.Equals(emergency))
        {
            emergency = null;
        }
    }
}
