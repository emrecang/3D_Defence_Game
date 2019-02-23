using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    private Camera fpsCam;
    private LineRenderer fpsLine;
    float maxDistance;

    private void Start()
    {
        fpsLine = GetComponent<LineRenderer>();
        fpsCam = GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        Vector3 originAim = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        Raycast hit;

        //if(Physics.Raycast(originAim,fpsCam.transform.forward,  hit ))
        //{

        //}
    }
}
