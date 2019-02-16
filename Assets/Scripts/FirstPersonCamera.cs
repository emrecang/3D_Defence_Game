using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class FirstPersonCamera : MonoBehaviour
{
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    [DllImport("user32.dll")]
    static extern int ShowCursor(bool bShow);

    Transform CameraTransform;

    int ScreenCenterX;
    int ScreenCenterY;
    // Start is called before the first frame update
    void Start()
    {
        ScreenCenterY = Screen.height / 2;
        ScreenCenterX = Screen.width / 2;
        CameraTransform = GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 lookat = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Quaternion rayQuart = new Quaternion(ray.direction.x, ray.direction.y, ray.direction.z, Quaternion.identity.w);
        //transform.rotation = rayQuart;

        SetCursorPos(ScreenCenterX, ScreenCenterY);
        Debug.Log("Y = " + ScreenCenterY);
        Debug.Log("X = " + ScreenCenterX);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("amk emresinin işi");
            ShowCursor(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("amk emresinin işi2");
            ShowCursor(false);
        }

    }
    void FixedUpdate()
    {
        RotatePlayer(Input.mousePosition.x, Input.mousePosition.y);
    }
    void RotatePlayer(float mousePosX, float mousePosY)
    {
        Quaternion playerQuartenion = this.transform.rotation;
        float rotateAxisHorizontal = Mathf.Abs(mousePosX - ScreenCenterX);
        float rotateAxisVertical = Mathf.Abs(mousePosY - ScreenCenterY);

        Debug.Log(rotateAxisHorizontal);
        Debug.Log(rotateAxisVertical);
        playerQuartenion.SetLookRotation(new Vector3(rotateAxisHorizontal, rotateAxisVertical, 1));

        Debug.Log(rotateAxisHorizontal);
        Debug.Log(rotateAxisVertical);
        playerQuartenion.SetLookRotation(new Vector3(rotateAxisHorizontal, rotateAxisVertical, 1));

    }

}
