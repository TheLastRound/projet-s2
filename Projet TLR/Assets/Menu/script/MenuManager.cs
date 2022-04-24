using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{

    public CinemachineBrain mainCamera;
    public CinemachineVirtualCamera frame0_cam;
    public CinemachineVirtualCamera frame1_cam;
    public CinemachineVirtualCamera frame3_cam;
    public Button creditbut;
    public GameObject frame1;
    public GameObject frame2;
    public GameObject startbut;
    public Button startButton;
    public EventSystem ES;

    private void clicked()
    {
        frame1.SetActive(false);
        frame2.SetActive(true);
        ES.SetSelectedGameObject(startbut);
        frame0_cam.gameObject.SetActive(false);
        frame1_cam.gameObject.SetActive(true);
    }
    
    public void Credits()
    {
        frame2.SetActive(false);

        frame3_cam.gameObject.SetActive(true);
        frame1_cam.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        ES.SetSelectedGameObject(startbut);
        frame0_cam.gameObject.SetActive(true);
        frame1_cam.gameObject.SetActive(false);
        frame3_cam.gameObject.SetActive(false);

        frame1.SetActive(true);
        frame2.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        startButton.onClick.AddListener(clicked);
        creditbut.onClick.AddListener(Credits);



        if (Input.GetKeyDown(KeyCode.Escape) && !frame1.activeInHierarchy)
        {
            frame1.SetActive(true);
           
            frame2.SetActive(false);
            frame1_cam.gameObject.SetActive(false);
           
            frame0_cam.gameObject.SetActive(true);
        }
    }

    
}