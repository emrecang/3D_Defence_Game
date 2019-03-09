using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool trapPhase;



    void Start()
    {
        trapPhase = GetComponent<TrapPlacer>().trapPhase;
        trapPhase = false;
    }
}
