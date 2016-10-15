using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{
    public float speed = 10f;
    public Junction target, from;
    public Service service;

    public void Update()
    {
        Move(speed * Time.deltaTime);
    }

    public void Move(float distance)
    {
        Vector3 direction = target.transform.position - transform.position;
        if (direction.magnitude < distance)
        {
            transform.position = target.transform.position;
            from = target;
            target = target.Target;
            Move(distance - direction.magnitude);
        }
        else
        {
            transform.Translate(direction.normalized * distance, Space.World);
            Quaternion quaternion = new Quaternion();
            quaternion.SetLookRotation(direction, Vector3.up);
            transform.rotation = quaternion;
        }
    }

    public void Flip()
    {
        Junction junction = target;
        target = from;
        from = junction;
    }
}