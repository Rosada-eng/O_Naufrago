using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSingleBoat : MonoBehaviour
{
    private int totalChildren;

    void Start()
    {
        totalChildren = transform.childCount;
        int random = Random.Range(0, totalChildren);
        for (int i = 0; i < totalChildren; i++)
        {
            if (i != random)
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(false);
            }
            else
            {
                Transform child = transform.GetChild(i);
                child.gameObject.SetActive(true);
            }
        }

    }
}
