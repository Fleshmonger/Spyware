using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Raycast thrown...");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit!");
                GameObject target = hit.collider.gameObject;
                Junction junction = target.GetComponentInParent<Junction>();
                if (junction)
                {
                    Debug.Log("Junction!");
                    junction.Turn();
                }
            }
        }
    }
}
