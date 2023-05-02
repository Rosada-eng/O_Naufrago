using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFabricCollected : MonoBehaviour
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
        int amountToCollect = player.GetComponent<GameEngine>().fabricsToCollect;

        if (amountToCollect == 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(true);
            string textToShow = player.GetComponent<PlayerController>().fabricCollected.ToString();
            textToShow += " / ";
            textToShow += player.GetComponent<GameEngine>().fabricsToCollect.ToString();
            UIText.text = textToShow;
        }
    }
}
