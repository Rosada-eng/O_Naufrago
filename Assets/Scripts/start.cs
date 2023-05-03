using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{   
    public GameObject SettingsMenuUI;
    public GameObject StartMenuUI;
    public GameObject TextUI;
    public float delay = 30.0f;

    public AudioClip loopSound;
    public AudioClip onceSound;
    public AudioClip thirdSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = loopSound;
        audioSource.loop = true;
        audioSource.Play();
        SettingsMenuUI.SetActive(false);
        StartMenuUI.SetActive(false);    
        TextUI.SetActive(true);
        Invoke("DelayedFunction", delay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void DelayedFunction()
    {
        TextUI.SetActive(false);
        StartMenuUI.SetActive(true);
        audioSource.Stop();
        audioSource.clip = onceSound;
        audioSource.loop = false;
        audioSource.Play();
        Invoke("PlayThirdSound", 2.0f);
    }

    private void PlayThirdSound()
    {
        audioSource.clip = thirdSound;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void press_settings(){
        Debug.Log("settings");
        SettingsMenuUI.SetActive(true);
        StartMenuUI.SetActive(false);
        }
    
    public void press_back(){
        Debug.Log("back");
        SettingsMenuUI.SetActive(false);
        StartMenuUI.SetActive(true);
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

