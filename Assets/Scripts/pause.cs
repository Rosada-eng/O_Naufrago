using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class pause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public EventSystem eventSystem;
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("esc");
            if(GameIsPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void press_play(){
        Debug.Log("play");
        Resume();
        }

    public void press_restart(){
        Debug.Log("restart");
        SceneManager.LoadScene(0);
        }

    public void press_quit(){
        Debug.Log("quit");
        Application.Quit();
    }

    public void Resume(){
        Debug.Log("resume");
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }
    public void Pause(){
        Debug.Log("pause");
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }
}

