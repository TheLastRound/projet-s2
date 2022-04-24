using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (!PlayerPrefs.HasKey("sens"))
        {
            PlayerPrefs.SetFloat("sens", (float)0.5);
            sensislider.value = PlayerPrefs.GetFloat("sens");
        }
        else
        {
            sensislider.value = PlayerPrefs.GetFloat("sens");
        }
        if (!PlayerPrefs.HasKey("volume"))
        {
            Debug.Log("1");
            PlayerPrefs.SetFloat("volume", (float)0.5) ;
            volslider.value = PlayerPrefs.GetFloat("volume");
        }
        else
        {
            Debug.Log("2");
            volslider.value = PlayerPrefs.GetFloat("volume");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
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
    
    private void Save()
    {
        PlayerPrefs.SetFloat("volume",volslider.value);
        PlayerPrefs.SetFloat("sens",sensislider.value);
    }

    public void Menu()
    {
        
        SceneManager.LoadScene("menu");
        player.SetActive(false);

    }
}
   


