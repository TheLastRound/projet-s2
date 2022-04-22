using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class settings : MonoBehaviour
{
    public void reload(){
        SceneManager.LoadScene("menu");
        }
}
