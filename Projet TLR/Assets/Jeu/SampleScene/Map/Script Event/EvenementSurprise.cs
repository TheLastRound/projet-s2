using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenementSurprise : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource TOCTOC;
    bool flag;
    void Start()
    {
        TOCTOC = GetComponent<AudioSource>();
        flag = true;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if ("PlayerInGame" == other.tag && flag)
        {
            TOCTOC.Play();
            flag = false;
        }
    }
}
