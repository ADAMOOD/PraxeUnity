using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using WebSocketSharp;
public class WebsocketConnect : MonoBehaviour
{
    public GameObject addressGO;

    public void kliknuti()
    {
        string address = addressGO.GetComponent<TextMeshProUGUI>().text;
        using (var ws = new WebSocket(address))
        {
            ws.OnMessage += (sender, e) =>
               Debug.Log("Laputa says: " + e.Data);
            ws.Connect();
            ws.Send("BALUS");
        }
    }
}
