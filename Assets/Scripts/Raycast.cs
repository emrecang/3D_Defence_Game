using UnityEngine;

public class Raycast : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            // Debug.Log(hit.point);
            // Debug.Log(ray.origin);

            //TODO player ve raycatsini önle.
        }
        // Debug.Log(Input.mousePosition);
    }
}