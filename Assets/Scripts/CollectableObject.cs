using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private GameObject player;

    private GameEngine gameEngine;
    private string collectableType;

    private AudioSource audioSource;
    public AudioClip collectSound;

    private bool isBoatDiscovered = false;
    private GameObject boat;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");

        audioSource = GetComponent<AudioSource>();

        collectableType = gameObject.tag;

        gameEngine = player.GetComponent<GameEngine>();
        boat = GameObject.FindWithTag("Boat");

    }

    public void Update()
    {
        isBoatDiscovered = boat.GetComponent<Boat>().isDiscovered;


        if (collectableType == "Wood" && gameEngine.woodsToCollect == 0)
        {
            gameObject.SetActive(false);
        }
        else if (collectableType == "Rope" && gameEngine.ropesToCollect == 0)
        {
            gameObject.SetActive(false);
        }
        else if (collectableType == "Fabric" && gameEngine.fabricsToCollect == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void CollisionWithPlayerDetected()
    {
        Debug.Log("Collision with " + collectableType);


        if (gameObject.CompareTag("Food"))
        {
            player.GetComponent<PlayerController>().increaseHealthPoints(10);
        }
        else if (gameObject.CompareTag("Wood"))
        {
            player.GetComponent<PlayerController>().woodCollected += 1;
        }
        else if (gameObject.CompareTag("Rope"))
        {
            player.GetComponent<PlayerController>().ropeCollected += 1;
        }
        else if (gameObject.CompareTag("Fabric"))
        {
            player.GetComponent<PlayerController>().fabricCollected += 1;
        }



        audioSource.PlayOneShot(collectSound);

        Invoke("DestroySelf", 0.4f);
    }
}
