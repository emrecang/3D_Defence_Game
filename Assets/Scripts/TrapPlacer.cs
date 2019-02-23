using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    float maxDistance = 20f;
    public GameObject[] Trap;

    private void Start()
    {
        fpsLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInChildren<Camera>();
    }
    public void FixedUpdate()
    {
        Vector3 originAim = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(originAim, fpsCam.transform.forward, out hit, maxDistance))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Sadece duvar için pozisyon. Yer için farklı olacak
                Vector3 spawnPos = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
                Instantiate(Trap[0], spawnPos, hit.transform.rotation);
            }

            GameObject candidateWall = hit.collider.gameObject;
            WallCalculation cwScript = candidateWall.GetComponent<WallCalculation>();
            Debug.Log(hit.transform.position);
        }
    }
}
