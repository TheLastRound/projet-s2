using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject ScriptDesac;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScriptDesac.GetComponent<RandomDeplace>().enabled = false;
            ScriptDesac.GetComponent<FollowPlayer>().enabled = true;
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScriptDesac.GetComponent<FollowPlayer>().enabled = false;
            ScriptDesac.GetComponent<RandomDeplace>().enabled = true;
        }

    }
}
