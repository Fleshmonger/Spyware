using UnityEngine;
using System.Collections;

public class Vehicle : MonoBehaviour
{
    /*
    private Vector3[] directionVectors = {
                                             Vector3.left,
                                             Vector3.right,
                                             Vector3.down,
                                             Vector3.up
                                         };
    */
    public enum ServiceType
    {
        PUBLIC,
        HEALTH,
        FIRE,
        POLICE,
        SCHOOL
    }
    /*
    public enum Direction
    {
        LEFT,
        RIGHT,
        DOWN,
        UP
    };
    */

    public float speed = 10f;
    public Junction target, from;
    public ServiceType serviceType;

    /*
    private Vector3 DirectionVector(Direction direction)
    {
        return directionVectors[(int)direction];
    }
    */
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