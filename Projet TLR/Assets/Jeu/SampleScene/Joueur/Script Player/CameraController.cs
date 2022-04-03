using System;
using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class CameraController : MonoBehaviour
    {
        //Rotation Camera
        private float x;
        private float y;
        private Vector3 rotateValue;
        Rigidbody rb;
        private float horizontal;
        private float vertical;
        private bool isGrounded;
        private bool inputJump;
        public float walk = 2.5f;
        public float run = 3.5f;
        // Use this for initialization
        void Update()
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotateValue = new Vector3(x, y * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * walk * vertical * Time.deltaTime);
            transform.Translate(Vector3.right * walk * horizontal * Time.deltaTime);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(Vector3.forward * run * vertical * Time.deltaTime);
                transform.Translate(Vector3.right * run * horizontal * Time.deltaTime);
            }

            if (!inputJump && isGrounded)
            {
                inputJump = Input.GetKey(KeyCode.Space);
            }
    
        }
    }
}
