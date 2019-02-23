using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    float maxDistance = 20f;
    public GameObject[] Trap;
    bool isPlacable = false;

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
            isPlacable = false;
            placeTrap(hit);
        }
    }

    public void placeTrap(RaycastHit hit)
    {


        GameObject candidateWall = hit.collider.gameObject;
        WallCalculation cwScript = candidateWall.GetComponent<WallCalculation>();
        Debug.Log(hit.point);

        if (hit.collider.gameObject.CompareTag("WallObject"))
        {
            isPlacable = cwScript.CalculateWallScale(hit.point.x, hit.point.z);
        }
        if(hit.collider.gameObject.CompareTag("GroundObject"))
        {
            isPlacable = cwScript.CalculateGroundScale(hit.point.x, hit.point.z);
        }


        if (Input.GetKeyDown(KeyCode.Space) && isPlacable)
        {
            //Sadece duvar için pozisyon. Yer için farklı olacak
            Vector3 spawnPos = new Vector3(hit.point.x, hit.transform.position.y, hit.point.z);
            Instantiate(Trap[0], spawnPos, hit.transform.rotation);
        }
        
    }
}
