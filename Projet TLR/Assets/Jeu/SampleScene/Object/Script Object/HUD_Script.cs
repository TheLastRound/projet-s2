using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class HUD_Script : MonoBehaviour
{

    public GameObject MessagePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMessagePanel()
    {
        MessagePanel.SetActive(true);
    }

    public void ClosMessagePanel()
    {
        MessagePanel.SetActive(false);
    }
}
