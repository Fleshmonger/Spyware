using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Floorplan))]
[ExecuteInEditMode]
public class Stage : MonoBehaviour
{
    public float gridScale = 5;
    public GameObject cornerPrefab, hallPrefab;
    private List<GameObject> modules = new List<GameObject>();

    private void Start()
    {
        GenerateModules();
    }

    public void RemoveModules()
    {
        if (Application.isEditor)
        {
            foreach (GameObject module in modules)
            {
                DestroyImmediate(module);
            }
        }
        else
        {
            foreach (GameObject module in modules)
            {
                Destroy(module);
            }
        }
        modules.Clear();
    }

    public void GenerateModules()
    {
        Floorplan floorplan = GetComponent<Floorplan>();

        for (int x = 0; x < floorplan.Width; x++)
        {
            for (int z = 0; z < floorplan.Length; z++)
            {
                if (!floorplan.GetTile(x, z))
                {
                    GenerateCorner(x, z);
                }
            }
        }
    }

    private Vector3 GridToWorld(float x, float z)
    {
        return new Vector3(gridScale * x, 0f, gridScale * z);
    }

    private void GenerateCorner(int gridX, int gridZ)
    {
        GameObject corner = Instantiate(cornerPrefab, GridToWorld(gridX, gridZ), Quaternion.identity) as GameObject;
        corner.hideFlags = HideFlags.DontSaveInEditor;
        corner.transform.parent = transform;
        modules.Add(corner);
    }

    private void GenerateHall(int gridX, int gridZ, bool xAligned)
    {
        Quaternion rotation;
        if (xAligned)
        {
            rotation = Quaternion.identity;
        }
        else
        {
            rotation = new Quaternion(0, 1, 0, 1);
        }
        GameObject hall = Instantiate(hallPrefab, GridToWorld(gridX, gridZ), rotation) as GameObject;
        hall.hideFlags = HideFlags.DontSaveInEditor;
        hall.transform.parent = transform;
        modules.Add(hall);
    }
}
