using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSprite : MonoBehaviour
{
    public Sprite[] sprites;

    private Dictionary<int, string> spriteTag = new Dictionary<int, string>(){
        {0, "Wood"},
        {1, "Wood"},
        {2, "Fabric"},
        {3, "Fabric"},
        {4, "Fabric"},
        {5, "Rope"},
        {6, "Rope"},
        {7, "Rope"},
    };
    public void Awake()
    {
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];

        transform.parent.tag = spriteTag[index];
    }

}
