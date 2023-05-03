using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    private Vector3 offset;

    // Start is called before the first frame update
    // void Awake()
    // {
    //     DontDestroyOnLoad(this.gameObject);
    // }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // offset = transform.position - player.transform.position;
        offset = new Vector3(0, 4, -10);
        transform.position = player.transform.position + offset;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
