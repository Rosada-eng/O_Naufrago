using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;

    private Vector3[] positions = {
        new Vector3(-11f, 14f, 0f),
        new Vector3(60f, 40f, 0f)
    };

    private Vector3[] rotations = {
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 45f)
    };

    void Awake()
    {
        // select a random sprite
        int index = Random.Range(0, sprites.Length);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[index];

        // select a random spawn
        index = Random.Range(0, positions.Length);
        transform.position = positions[index];
        transform.eulerAngles = rotations[index];

    }

}
