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
    public void showMessage(string message)
    {
        if (!isCalled)
        {
            isCalled = true;
            UIText.text = message;
            Invoke("hideMessage", 10f);
        }

    }
    public void hideMessage()
    {
        UIText.text = "";
        isCalled = false;
    }
}
