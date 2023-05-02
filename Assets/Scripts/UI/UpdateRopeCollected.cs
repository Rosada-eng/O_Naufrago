using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateRopeCollected : MonoBehaviour
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
        int amountToCollect = player.GetComponent<GameEngine>().ropesToCollect;

        if (amountToCollect == 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            transform.parent.gameObject.SetActive(true);
            string textToShow = player.GetComponent<PlayerController>().ropeCollected.ToString();
            textToShow += " / ";
            textToShow += player.GetComponent<GameEngine>().ropesToCollect.ToString();
            UIText.text = textToShow;
        }
    }
}
