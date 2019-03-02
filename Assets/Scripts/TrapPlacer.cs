using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    [Range (10,100)]
    public float maxDistance = 20f;
    public GameObject[] TrapPrefabs;
    public GameObject[] GhostTrapPrefabs;
    public GameObject ghostTrap;
    public int index = 0;
    public int tempIndex = 0;
    public Material green;
    public Material red;
    public TrapCollision trapLogic;
    public GameObject ghost;
    CursorLockMode wantedCursorMode;


    public bool isPlaceEmpty = true;
    public bool isWallColliding = false;
    public bool isPlacable = true;
    bool trapSelected = true;
    bool ghostCreated = false;

    private void Start()
    {
        fpsLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInChildren<Camera>();
    }
    public void FixedUpdate()
    {
        GhostTrap();
        SetCursorState();
    }
 
    public bool placeTrap(RaycastHit hit)
    {
        GameObject candidateWall = hit.collider.gameObject;
        WallCalculation cwScript = candidateWall.GetComponent<WallCalculation>();
        isWallColliding = trapLogic.isCollidingWall();

        if (hit.collider.gameObject.CompareTag("WallObject")){
            isPlacable = cwScript.CalculateWallScale(hit.point.x, hit.point.z);
        }

        if(hit.collider.gameObject.CompareTag("GroundObject") && !isWallColliding)
        {
            isPlacable = cwScript.CalculateGroundScale(hit.point.x, hit.point.z);
        }
        
        if (Input.GetKey(KeyCode.Mouse0) && isPlacable )
        {
            if (isPlaceEmpty)
            {
                Instantiate(TrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
                return true;
            }
        }
        return false;
    }

    public Vector3 spawnPosCalculator(RaycastHit hit)
    {
        Vector3 spawnPos = new Vector3(Mathf.Round(hit.point.x), hit.transform.position.y, Mathf.Round(hit.point.z));
        return spawnPos;
    }


    public void GhostTrap()
    {
        Vector3 originAim = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (trapSelected)
        {
            wantedCursorMode = CursorLockMode.Locked;

            if (Physics.Raycast(originAim, fpsCam.transform.forward, out hit, maxDistance))
            {
                if (!ghostCreated)
                {
                    ghostTrap = Instantiate(GhostTrapPrefabs[index], spawnPosCalculator(hit), hit.transform.rotation);
                    ghostCreated = true;
                    trapLogic = ghostTrap.GetComponent<TrapCollision>();
                    tempIndex = index;
                }

                if (ghostCreated && (tempIndex != index))
                {
                    Destroy(ghostTrap);
                    ghostCreated = false;
                }

                if (ghostCreated)
                {
                    ghostTrap.transform.position = spawnPosCalculator(hit);
                    ghostTrap.transform.rotation = hit.transform.rotation;

                    isPlaceEmpty = trapLogic.isEmpty();

                    if (isPlacable && isPlaceEmpty)
                    {
                        ghostTrap.gameObject.GetComponent<MeshRenderer>().material = green;
                    }
                    else
                    {
                        ghostTrap.gameObject.GetComponent<MeshRenderer>().material = red;
                    }
                }

                isPlacable = false;
                placeTrap(hit);
            }
            else
            {
                Debug.Log("TOO FAR");
            }
        }
        else
        {
            wantedCursorMode = CursorLockMode.Confined;
        }
        

    }

    void SetCursorState()
    {
        Cursor.lockState = wantedCursorMode;
        Cursor.visible = (CursorLockMode.Locked != wantedCursorMode);
    }
}
