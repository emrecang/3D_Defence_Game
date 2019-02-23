using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    float maxDistance = 20f;
    public GameObject[] TrapPrefabs;
    public GameObject[] GhostTrapPrefabs;
    GameObject ghostTrap;
    public int index = 0;
    public int tempIndex = 0;

    bool isPlacable = false;
    bool trapSelected = true;
    bool ghostCreated = false;

    private void Start()
    {
        fpsLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInChildren<Camera>();
    }
    public void FixedUpdate()
    {
        Vector3 originAim = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (trapSelected)
        {
            if (Physics.Raycast(originAim, fpsCam.transform.forward, out hit, maxDistance))
            {
                if (!ghostCreated)
                {
                    ghostTrap = Instantiate(GhostTrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
                    ghostCreated = true;
                    tempIndex = index;
                }
                if(ghostCreated && (tempIndex != index))
                {
                    Destroy(ghostTrap);
                    ghostCreated = false;
                }
                if (ghostCreated)
                {
                    ghostTrap.transform.position = spawnPosCalculator(hit);
                    ghostTrap.transform.rotation = hit.transform.rotation;
                    Debug.Log(spawnPosCalculator(hit));
                }
                isPlacable = false;
                placeTrap(hit);

            }
        }
        

    }
 
    public bool placeTrap(RaycastHit hit)
    {
        GameObject candidateWall = hit.collider.gameObject;
        WallCalculation cwScript = candidateWall.GetComponent<WallCalculation>();
        
        Debug.Log(Mathf.Round(hit.point.x));

        if (hit.collider.gameObject.CompareTag("WallObject"))
        {
            isPlacable = cwScript.CalculateWallScale(Mathf.Round(hit.point.x), Mathf.Round(hit.point.z));
        }
        if(hit.collider.gameObject.CompareTag("GroundObject"))
        {
            isPlacable = cwScript.CalculateGroundScale(Mathf.Round(hit.point.x), Mathf.Round(hit.point.z));
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isPlacable)
        {
            //Sadece duvar için pozisyon. Yer için farklı olacak
            
            Instantiate(TrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
            return true;
        }
        return false;
    }

    public Vector3 spawnPosCalculator(RaycastHit hit)
    {
        Vector3 spawnPos = new Vector3(Mathf.Round(hit.point.x), hit.transform.position.y, hit.point.z);
        return spawnPos;
    }
}
