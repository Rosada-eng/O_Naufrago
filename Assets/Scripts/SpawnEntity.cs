using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{

    public List<bool> childrenStatus = new List<bool>();
    public float spawnProbability = 0.5f;



    void Awake()
    {
        int totalChildren = transform.childCount;
        for (int i = 0; i < totalChildren; i++)
        {
            Transform child = transform.GetChild(i);
            float random = Random.Range(0f, 1f);
            if (random < spawnProbability)
            {
                child.gameObject.SetActive(true);
                childrenStatus.Add(true);
                Debug.Log("child " + i + " ACTIVE - position: " + child.position.x + ", " + child.position.y + ", " + child.position.z);
            }
            else
            {
                child.gameObject.SetActive(false);
                childrenStatus.Add(false);
            }


        }
    }

}
