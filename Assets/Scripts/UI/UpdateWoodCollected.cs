using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateWoodCollected : MonoBehaviour
{

    private TextMeshProUGUI UIText;
    private GameObject player;
    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void LateUpdate()
    {
        int amountToCollect = player.GetComponent<GameEngine>().woodsToCollect;

        if (amountToCollect == 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(true);
            string textToShow = player.GetComponent<PlayerController>().woodCollected.ToString();
            textToShow += " / ";
            textToShow += player.GetComponent<GameEngine>().woodsToCollect.ToString();
            UIText.text = textToShow;
        }

    }
}
