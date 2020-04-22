using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivityY = 2f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    float rotationY = 0f;

    void Update()
    {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
    }
}
