using UnityEngine;

public class TrapCollision : MonoBehaviour
{
    public bool WallCollide = false;
    bool isEmpty = true;
    
    public void isEmptySet(bool value)
    {
        isEmpty = value;
    }

    public bool isEmptyGet()
    {
        return isEmpty;
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
            isEmptySet(false);
        }
        
    }

    public void deleteTrap(RaycastHit hit)
    {
        if (hit.collider.gameObject.CompareTag("Trap"))
        {
            Destroy(hit.collider.gameObject);
            isEmptySet(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WallObject"))
        {
            WallCollide = false;
        }

        isEmptySet(true);
    }

}
