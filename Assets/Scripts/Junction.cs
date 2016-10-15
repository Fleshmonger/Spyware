using UnityEngine;
using System.Collections;

public class Junction : Node
{
    private int targetIndex = 0;

    public Node[] connections;

    private Node Target
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

    override public Node GetTarget(Node from)
    {
        return Target;
    }
}
