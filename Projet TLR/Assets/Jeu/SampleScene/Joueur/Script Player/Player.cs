using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    private float horizontal;
    private float vertical;
    private bool isGrounded;
    private bool inputJump;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * 2 * vertical * Time.deltaTime);
        transform.Translate(Vector3.right * 2 * horizontal * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * 4 * vertical * Time.deltaTime);
            transform.Translate(Vector3.right * 4 * horizontal * Time.deltaTime);
        }

        if (!inputJump && isGrounded)
        {
            inputJump = Input.GetKey(KeyCode.Space);
        }
            
      
    }
    void FixedUpdate()
    {
       if(inputJump && isGrounded)
        {
            rb.AddForce(Vector3.up *3.5f, ForceMode.Impulse);
            inputJump = false;
            isGrounded = false;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

}
