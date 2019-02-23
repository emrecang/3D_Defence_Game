using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    public bool Empty=true;
    
   

    public bool isEmpty()
    {
        return Empty;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.CompareTag("Trap"))
        {

            Empty = false;
            Debug.Log("Heyoo "+ false);
            
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Empty = true;
    }
}
