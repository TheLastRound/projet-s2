using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
}
