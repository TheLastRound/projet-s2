using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_manager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool paused = false;
    public static bool set=false; 
    public GameObject menu;
    public GameObject player;
    public GameObject settings;

    [SerializeField] Slider volslider;
    [SerializeField] Slider sensislider;
 
    public void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", (float)0.5) ;
            LoadVol();
        }
        else
        {
            LoadVol();
        }
        if (!PlayerPrefs.HasKey("sensi"))
        {
            PlayerPrefs.SetFloat("sensi", (float)0.5);
            LoadSensi();
        }
        else
        {
            LoadSensi();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !set)
            Pause();
        if (Input.GetKeyDown(KeyCode.Escape) && set)
        {
            settings.SetActive(false);
            menu.SetActive(true);
            set = false;
        }


    }

    private void Pause()
    {
        if (paused==true)
        {
            menu.SetActive(false);
            paused = false;
        }
        else
        {
            menu.SetActive(true);
            paused = true;
        }
    }
    public void leave()
    {
        player.SetActive(false);
        Application.Quit();
    }
    public void Settings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        set=true;
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volslider.value;
        Save();
    }
    public void ChangeSensi()
    {
        CameraRotation.sensi = sensislider.value;
        Save();
    }

    private void LoadVol()
    {
        volslider.value = PlayerPrefs.GetFloat("volume");
    }
    private void LoadSensi()
    {
        sensislider.value = PlayerPrefs.GetFloat("sensi");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("volume",volslider.value);
        PlayerPrefs.SetFloat("sensi",sensislider.value);
    }
}
   


