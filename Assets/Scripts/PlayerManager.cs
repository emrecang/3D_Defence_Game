using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    TrapPlacer trapPlacerLogic;



    void Start()
    {
        trapPlacerLogic = GetComponent<TrapPlacer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            trapPlacerLogic.trapPhase = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            trapPlacerLogic.trapPhase = false;
        }
    }
}
