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



    private void OnTriggerEnter(Collider o)
    {
        if (o.gameObject.CompareTag("Heart"))
        {
            Destroy(this.gameObject);
            o.transform.localScale -= new Vector3(0.2F, 0.2F, 0.2F);
            if(o.transform.localScale.x < 0.8f)
            {
                Destroy(o.gameObject);
                Debug.Log("My Heart Is Destroyed :( ");
            }
        }
    }
}
