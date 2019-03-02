using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    public bool Empty=true;
    public bool WallCollide = false;

    private void Start()
    {
        Empty = true;
    }

    public bool isEmpty()
    {
        return Empty;
    }

    public bool isCollidingWall()
    {
        return WallCollide;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("WallObject"))
        {
            WallCollide = true;
        }
        
        if (other.gameObject.CompareTag("Trap"))
        {
            Empty = false;
        }
    }

    public void deleteTrap(RaycastHit hit)
    {
        if (Empty == false && hit.collider.gameObject.CompareTag("Trap"))
        {
            Destroy(hit.collider.gameObject);
            WallCollide = true;
            Empty = true;
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WallObject"))
        {
            WallCollide = false;
        }
        
        Empty = true;
    }
}
