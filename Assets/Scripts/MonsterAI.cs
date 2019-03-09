using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    public GameObject Heart;
    public NavMeshAgent agent;
    Vector3 HeartPosition;
    // Start is called before the first frame update
    void Start()
    {
        HeartPosition = Heart.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(HeartPosition);
    }
}
