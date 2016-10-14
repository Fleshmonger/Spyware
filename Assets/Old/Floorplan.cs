using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Stage))]
[ExecuteInEditMode]
public class Floorplan : MonoBehaviour
{
    private enum Sign { RIGHT, LEFT, FORWARD, BACK }

    [SerializeField]
    private int _width = 1, _length = 1;

    public int Width
    {
        get
        {
            return _width;
        }
        set
        {
            if (value != _width && value >= 1)
            {
                _width = value;
                Initialize();
                Stage stage = GetComponent<Stage>();
                if (stage)
                {
                    stage.RemoveModules();
                    stage.GenerateModules();
                }
            }
        }
    }

    public int Length
    {
        get
        {
            return _length;
        }
        set
        {
            if (value != _length && value >= 1)
            {
                _length = value;
                Initialize();
                Stage stage = GetComponent<Stage>();
                if (stage)
                {
                    stage.RemoveModules();
                    stage.GenerateModules();
                }
            }
        }
    }

    private bool[,] tileGrid;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        bool[,] oldGrid = tileGrid;
        tileGrid = new bool[Width, Length];
        for (int i = 0, minWidth = Mathf.Min(oldGrid.GetLength(0), Width); i < minWidth; i++)
        {
            for (int j = 0, minLength = Mathf.Min(oldGrid.GetLength(1), Length); j < minLength; j++)
            {
                tileGrid[i, j] = oldGrid[i, j];
            }
        }
    }

    public bool Contains(int x, int z)
    {
        return x >= 0 && x < Width && z >= 0 && z < Length;
    }

    public bool GetTile(int x, int z)
    {
        if (Contains(x, z))
        {
            return tileGrid[x, z];
        }
        else
        {
            return false;
        }
    }

    public void SetTile(int x, int z, bool value)
    {
        if (Contains(x, z))
        {
            tileGrid[x, z] = value;
        }
    }
}