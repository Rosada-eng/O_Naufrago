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

// Bem-vindo ao Arquipélago Sombrio, sobrevivente! 
// Você está prestes a embarcar em uma jornada emocionante e perigosa. 
// Rumores dizem que coisas estranhas acontecem nesta ilha aparentemente desabitada,
// Mas seu avião passou por uma pane e você foi forçado a abandoná-lo, acionando seu paraquedas.
// O destino te colocou aqui, agora soó resta fugir, ou morrer tentando. 
// Com poucos recursos e em um lugar desconhecido, você precisará usar sua coragem e instintos para explorar a ilha e encontrar uma maneira de sobreviver
// E a única saída parece ser o mar. Boa sorte!