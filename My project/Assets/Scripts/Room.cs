using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class Room : MonoBehaviour
{
    public GameObject Prefab;
    private static bool TableOpened;
    private static GameObject tableInstance=null;
    public GameObject PlayersContainerPrefab;
    public GameObject GridContentForPlayers;

    public void ButtonClicked(GameObject cliGameObject)
    {
        Button buttonComponent = cliGameObject.GetComponent<Button>();
        TextMeshProUGUI textMesh = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();//veme text z tlacitka na ktere se kliklo 
        DataSerilization(buttonComponent.Quiz);
        GameObject GObject = Instantiate(Prefab);//zobrazi tabulklu
        tableInstance = GObject;
        TableOpened = true;
    }

    void Update()
    {
        if (TableOpened)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject PlayersTable = FindChildByName(tableInstance.transform, "PlayersTable");
                RectTransform rectTransform = PlayersTable.GetComponent<RectTransform>();
                Vector2 mousePosition = Input.mousePosition;
                if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
                {
                    Destroy(tableInstance);
                    TableOpened = false;
                }
            }
        }
    }

    public void DataSerilization(Quiz quiz)
    {
        string[] data =
        {
            quiz.maxPlayerCount.ToString(), quiz.currentPlayerCount.ToString(), quiz.roomState.ToString(),
            quiz.createdAt.ToString()
        };
        string[] names = {"Max", "Now", "RoomName", "Date"};
        for (int i = 0; i < names.Length; i++)
        {
            InsertDataToComponents(data[i], names[i]);
        }
        foreach (var p in quiz.Players)
        {
            GameObject playerisntance = Instantiate(PlayersContainerPrefab,GridContentForPlayers.transform); 
           // playerisntance.transform.SetParent(gridContent.transform);
        }
    }
    private void InsertDataToComponents(string data,string name)
    {
        GameObject child = FindChildByName(Prefab.transform, name);
        if (child != null)
        {
            Text text = child.GetComponent<Text>();
            text.text = data;
        }
    }

    public static GameObject FindChildByName(Transform parent, string name)
    {
        if (parent.name == name)
        {
            return parent.gameObject;
        }
        for (int i = 0; i < parent.childCount; i++)
        {
            GameObject child = FindChildByName(parent.GetChild(i), name);
            if (child != null)
            {
                return child.gameObject;
            }
        }
        return null;
    }
}
