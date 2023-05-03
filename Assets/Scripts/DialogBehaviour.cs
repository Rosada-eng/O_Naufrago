using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogBehaviour : MonoBehaviour
{
    public TextMeshProUGUI UIText;
    private bool isCalled = false;
    void Start()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        UIText.text = "";

    }
    public void showMessage(string message, float delay = 10f)
    {
        if (!isCalled)
        {
            isCalled = true;
            UIText.text = message;
            Invoke("hideMessage", delay);
        }

    }
    public void hideMessage()
    {
        UIText.text = "";
        isCalled = false;
    }
}
