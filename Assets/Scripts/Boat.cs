using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;

    public bool isAbleToTravel = false;
    public bool isDiscovered = false;


    // TODO: Change sprite when is able to travel (fixed)

    void Start()
    {
        // select a random sprite
        int index = Random.Range(0, sprites.Length);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[index];


    }

}
