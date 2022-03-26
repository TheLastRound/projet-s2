using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomDeplace : MonoBehaviour
{
    private RaycastHit Hit;

    void Update()
    {
     
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Translate(Vector3.right  * Time.deltaTime);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, 1))
        {
            transform.Rotate(Vector3.up * Random.Range(90, 180));
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Hit, 1))
        {
            transform.Rotate(Vector3.up * Random.Range(90, 180));
        }
        
        

    }
}
