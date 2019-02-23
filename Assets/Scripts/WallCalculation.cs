using UnityEngine;

public class WallCalculation : MonoBehaviour
{
    int trapSize = 0;
    float wallOffsetEnd = 0;
    float wallOffsetStart = 0;
    float placeableAreaLength;
    float myAngle;
    public GameObject[] Trap;
    
    public bool CalculateWallScale(float posX, float posZ)
    {
        myAngle = Mathf.Cos(transform.rotation.eulerAngles.y);
       
        if (Trap.Length > 0)
        {
            if (Trap[0] != null)
            {
                wallOffsetEnd = this.transform.localScale.x - (Trap[trapSize].transform.localScale.x / 2); //duvar x genişliği - trap x genişliği /2
                wallOffsetStart = (Trap[trapSize].transform.localScale.x / 2); //trap x genişliği /2

                placeableAreaLength = (wallOffsetEnd - wallOffsetStart) / 2;

            }
            if (this.transform.localRotation.y > 0)
            {
                wallOffsetEnd = this.transform.position.z + placeableAreaLength;
                wallOffsetStart = this.transform.position.z - placeableAreaLength;
                if ((wallOffsetStart <= posZ && wallOffsetEnd >= posZ))
                {
                    return true;
                }
                //Debug.Log("Rotation = " + this.transform.rotation.eulerAngles.y + " Then We in Z coord"); //Açı verirs
            }
            else
            {
                wallOffsetEnd = this.transform.position.x  + placeableAreaLength;
                wallOffsetStart = this.transform.position.x  - placeableAreaLength;
                if ((wallOffsetStart <= posX && wallOffsetEnd >= posX))
                {
                    return true;
                }
                // Debug.Log("Rotation = " + this.transform.localRotation.y + " Then We in X coord");
            }
        }
        Debug.Log("Start Offset = " + wallOffsetStart + " , End Offset = " + wallOffsetEnd);
        return false;
    }

    public bool CalculateGroundScale(float posX, float posY)
    {
        return true;
    }
}
