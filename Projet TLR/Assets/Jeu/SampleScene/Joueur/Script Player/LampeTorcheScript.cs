using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampeTorcheScript : MonoBehaviour
{
    Light lght;

    // Start is called before the first frame update
    void Start()
    {
        lght = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            lght.enabled = !lght.enabled;
        }

    }

}
