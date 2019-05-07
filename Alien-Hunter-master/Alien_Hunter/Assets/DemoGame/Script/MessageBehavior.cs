using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBehavior : MonoBehaviour
{
    public Image MessagePanel;
    private Text message;
    private Color DestColor = new Color(1, 1, 1, 0);

    private void Start()
    {
        message = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        MessagePanel.color = Color.Lerp(MessagePanel.color, DestColor, .01f);
        message.color = Color.Lerp(message.color, Color.clear, .01f);
    }

    public void SetMessage(string msg)
    {
        Color tmpCol = MessagePanel.color;
        tmpCol.a = 1;
        MessagePanel.color = tmpCol;

        message.text = msg;
        tmpCol = message.color;
        tmpCol.a = 1;
        message.color = tmpCol;
    }
}
