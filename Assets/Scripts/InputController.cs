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
            if (Physics.Raycast(ray, out hit))
            {
                GameObject target = hit.collider.gameObject;
                Junction junction = target.GetComponentInParent<Junction>();
                if (junction)
                {
                    junction.Turn();
                }
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
