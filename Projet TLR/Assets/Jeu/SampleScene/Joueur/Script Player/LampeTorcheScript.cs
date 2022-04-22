using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeTorcheScript : MonoBehaviour
{
    Light lght;
    AudioSource son;

    // Start is called before the first frame update
    void Start()
    {
        lght = GetComponent<Light>();
        son = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            son.Play();
            lght.enabled = !lght.enabled;
        }

    }

}
