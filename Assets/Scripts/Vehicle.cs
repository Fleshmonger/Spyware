using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{
    public float speed = 10f;
    public Node target, from;
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
            Node destination = target;
            target = target.GetTarget(from);
            from = destination;
            destination.Arrive(this);
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
        Node junction = target;
        target = from;
        from = junction;
    }
}