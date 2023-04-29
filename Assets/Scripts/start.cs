using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{   
    public GameObject SettingsMenuUI;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        SettingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void press_settings(){
        Debug.Log("settings");
        SettingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        }
    
    public void press_back(){
        Debug.Log("back");
        SettingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void press_quit(){
        Debug.Log("quit");
        Application.Quit();
    }

    public void press_play(){
        Debug.Log("restart");
        SceneManager.LoadScene(1);
        }
}
