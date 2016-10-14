using UnityEngine;
using System.Collections;

public class Junction : MonoBehaviour
{
    private int targetIndex = 0;

    public Junction[] connections;

    public Junction Target
    {
        get
        {
            return connections[targetIndex];
        }
    }

    public void Awake()
    {
        targetIndex = Random.Range(0, connections.Length);
        Orient();
    }

    public void Turn()
    {
        targetIndex = (targetIndex + 1) % connections.Length;
        Orient();
    }

    public void Orient()
    {
        Quaternion quaternion = new Quaternion();
        quaternion.SetLookRotation(Target.transform.position - transform.position, Vector3.up);
        transform.rotation = quaternion;
    }
}
