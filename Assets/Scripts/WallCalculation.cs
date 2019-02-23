﻿using UnityEngine;

public class WallCalculation : MonoBehaviour
{
    int trapSize = 0;
    float wallOffsetEnd = 0;
    float wallOffsetStart = 0;
    float placeableAreaLength;
    public GameObject[] Trap;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateWallScale();
    }

    void CalculateWallScale()
    {
        if (Trap.Length > 0)
        {
            if (Trap[0] != null)
            {
                wallOffsetEnd = this.transform.localScale.x - (Trap[trapSize].transform.localScale.x / 2);
                wallOffsetStart = (Trap[trapSize].transform.localScale.x / 2);
                placeableAreaLength = (wallOffsetEnd - wallOffsetStart) / 2;

            }
            if (this.transform.localRotation.y > 0)
            {
                wallOffsetEnd = this.transform.position.z + placeableAreaLength;
                wallOffsetStart = this.transform.position.z - placeableAreaLength;
                //Debug.Log("Rotation = " + this.transform.rotation.eulerAngles.y + " Then We in Z coord"); Açı verir;
            }
            else
            {
                wallOffsetEnd = this.transform.position.x + placeableAreaLength;
                wallOffsetStart = this.transform.position.x - placeableAreaLength;
                // Debug.Log("Rotation = " + this.transform.localRotation.y + " Then We in X coord");
            }
        }

        Debug.Log("Start Offset = " + wallOffsetStart);
        Debug.Log("End Offset = " + wallOffsetEnd);

        //Debug.Log("StartArea = " + (this.transform.position.z - placeableAreaLength));
        //Debug.Log("EndArea = " + (this.transform.position.z + placeableAreaLength));
    }

    void CalculateGroundScale()
    {

    }
}
