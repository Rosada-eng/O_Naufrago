using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEntity : MonoBehaviour
{

    public List<bool> childrenStatus = new List<bool>();

    private int totalChildren = 0;
    public float spawnProbability = 0.5f;

    public string type = "";

    private GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        totalChildren = transform.childCount;

        for (int i = 0; i < totalChildren; i++)
        {
            Transform child = transform.GetChild(i);
            float random = Random.Range(0f, 1f);
            if (random < spawnProbability)
            {
                child.gameObject.SetActive(true);
                childrenStatus.Add(true);
            }
            else
            {
                child.gameObject.SetActive(false);
                childrenStatus.Add(false);
            }
        }


        if (type == "Wood")
        {
            int needsToHave = player.GetComponent<GameEngine>().woodsToCollect;
            Debug.Log("need: " + needsToHave + " " + type);
            Debug.Log("have: " + countActiveChildren().ToString());
            spawnUntilEnough(needsToHave);

        }
        else if (type == "Rope")
        {
            int needsToHave = player.GetComponent<GameEngine>().ropesToCollect;
            Debug.Log("need: " + needsToHave + " " + type);
            Debug.Log("have: " + countActiveChildren().ToString());
            spawnUntilEnough(needsToHave);

        }
        else if (type == "Fabric")
        {
            int needsToHave = player.GetComponent<GameEngine>().fabricsToCollect;
            Debug.Log("need: " + needsToHave + " " + type);
            Debug.Log("have: " + countActiveChildren().ToString());
            spawnUntilEnough(needsToHave);

        }




    }

    private void spawnUntilEnough(int needsToHave)
    {
        int activeCount = countActiveChildren();

        while (activeCount - 2 < needsToHave)
        {
            int random_idx = Random.Range(0, totalChildren);
            Transform child = transform.GetChild(random_idx);
            if (child.gameObject.activeSelf == false)
            {
                child.gameObject.SetActive(true);
                childrenStatus[random_idx] = true;
                Debug.Log("EXTRA child " + random_idx + " ACTIVE - position: " + child.position.x + ", " + child.position.y + ", " + child.position.z);
            }

            activeCount = countActiveChildren();
        }
    }

    private int countActiveChildren()
    {
        int totalChildren = transform.childCount;
        int activeChildren = 0;
        for (int i = 0; i < totalChildren; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                activeChildren += 1;
            }
        }
        Debug.Log("Active Children: " + activeChildren);

        return activeChildren;
    }
}
