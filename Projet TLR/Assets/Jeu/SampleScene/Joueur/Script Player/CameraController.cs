using System;
using UnityEngine;
using System.Collections;
 
public class CameraController : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 rotateValue;
    // Use this for initialization
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

    }
}
