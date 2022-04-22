using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class volumemax : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public void volmax()
    {
        Debug.Log("test");
        music.volume += (float)0.1;

    }


}
