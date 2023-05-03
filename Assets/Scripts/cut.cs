using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cut : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 10.0f;

    public AudioClip loopSound;
    public AudioClip onceSound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = loopSound;
        audioSource.loop = true;
        audioSource.Play();
         Invoke("DelayedFunction", delay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void DelayedFunction()
    {
        audioSource.Stop();
        audioSource.clip = onceSound;
        audioSource.loop = false;
        audioSource.Play();
        SceneManager.LoadScene(3);
    }
}
