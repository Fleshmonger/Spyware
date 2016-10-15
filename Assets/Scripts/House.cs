using UnityEngine;
using System.Collections;

public class House : Building
{
    private Color colorTransparent = new Color(0f, 0f, 0f, 0f);
    public Service emergency;
    public SpriteRenderer sign;

    public void Awake()
    {
        SetEmergency(emergency);
    }

    override public void Arrive(Vehicle vehicle)
    {
        if (vehicle.service.Equals(emergency))
        {
            SetEmergency(null);
        }
    }

    public void SetEmergency(Service emergency)
    {
        this.emergency = emergency;
        if (emergency == null)
        {
            HouseManager._instance.FreeHouse(this);
            sign.color = colorTransparent;
        }
        else
        {
            HouseManager._instance.OccupyHouse(this);
            sign.color = emergency.color;
        }
    }
}
