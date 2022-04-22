using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickItem : MonoBehaviour
{
    public bool IsRange;
    public KeyCode interactKey;
    public UnityEvent pick;
    public HUD_Script hud;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                pick.Invoke();
                hud.ClosMessagePanel();
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pick"))
        {
            IsRange = true;
            hud.OpenMessagePanel();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Pick"))
        {
            IsRange = false;
            hud.ClosMessagePanel();
        }
    }
}
