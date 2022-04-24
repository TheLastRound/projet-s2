using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    public string scenename;
    public void changeScene()
    {
        Debug.Log("In game");
        SceneManager.LoadScene(scenename);
       

    }
    

    
    
}
