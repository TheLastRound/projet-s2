using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.Characters.ThirdPerson;

namespace MyNamespace
{
    public class PlayerMov : MonoBehaviour
    {
        Rigidbody rb;
        private float horizontal;
        private float vertical;
        private bool isGrounded;
        private bool inputJump;
        public float walk = 2.5f;
        public float run = 3.5f;

        private PhotonView view;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            {
                if (Player.player.Length == 1)
                {
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
                else if (view.IsMine)
                {
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
        void FixedUpdate()
        
        {
            if (Player.player.Length == 1)
            {
                if (inputJump && isGrounded)
                {
                    rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
                    inputJump = false;
                    isGrounded = false;
                }
            }
            else if (view.IsMine)  
            {
                if (inputJump && isGrounded)
                {
                    rb.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
                    inputJump = false;
                    isGrounded = false;
                }
            }
        }
    }
}

