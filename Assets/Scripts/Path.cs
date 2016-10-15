using UnityEngine;
using System.Collections;

public class Path : Node
{
    public Node nodeA, nodeB;

    public override Node GetTarget(Node from)
    {
        if (nodeA.Equals(from))
        {
            return nodeB;
        }
        else if (nodeB.Equals(from))
        {
            return nodeA;
        }
        else
        {
            return null;
        }
    }
}