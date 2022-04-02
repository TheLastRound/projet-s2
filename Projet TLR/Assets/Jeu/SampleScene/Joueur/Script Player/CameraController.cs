using UnityEngine;
using System.Collections;
 
public class CameraController : MonoBehaviour {
   
    public GameObject target;
    private Vector3 offset;
    private Vector3 HeightPos = new Vector3 ((float)0,(float)3,(float)0);
    private float x;
    private float y;
    private Vector3 rotateValue;
    // Use this for initialization
    void Start () {
        offset = transform.position;
    }
    void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotateValue = new Vector3(x, y * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;
    }
    // Update is called once per frame
    void LateUpdate () {
        if (target != null){
            transform.position = target.transform.position + offset+HeightPos;
            transform.rotation = target.transform.rotation;
        }
    }
}
