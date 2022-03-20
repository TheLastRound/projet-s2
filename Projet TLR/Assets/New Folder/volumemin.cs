using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class volumemin : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    public void volmin() {
        Debug.Log("test");
        music.volume-=(float)0.1;

          }
    

}
