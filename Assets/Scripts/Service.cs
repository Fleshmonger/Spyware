using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewServiceType", menuName = "Data/Service", order = 1)]
public class Service : ScriptableObject
{
    public string type;
    public Material material;
    public Color color;
}