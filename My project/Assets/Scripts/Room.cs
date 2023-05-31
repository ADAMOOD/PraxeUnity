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
    public static Quiz ButtonThing;

    public void ButtonClicked(GameObject cliGameObject)
    {
        Button buttonComponent = cliGameObject.GetComponent<Button>();
        ButtonThing = buttonComponent.Quiz;
        TextMeshProUGUI textMesh = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();//veme text z tlacitka na ktere se kliklo 
        DataSerialization(buttonComponent.Quiz);

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
            /* if (Input.GetMouseButtonDown(0))
             {
                 Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 bool clickedOnStill = false;
                 RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                 if (hit.collider != null)
                 {
                     GameObject clickedObject = hit.collider.gameObject;
                     Debug.Log($"{clickedObject.name} -> {clickedObject.tag}");
                     if (clickedObject.CompareTag("Still"))
                     {
                         clickedOnStill = true;
                     }
                 }
                 if (!clickedOnStill)
                 {
                     Destroy(tableInstance);
                     TableOpened = false;
                 }
             }*/
            /*if (Input.GetMouseButtonDown(0))
            {


                if (clickedObjectTag != "Still")
                {
                    Destroy(tableInstance);
                    TableOpened = false;
                }
            }*/
        }
    }

    public void DataSerialization(Quiz quiz)
    {
        string[] data =
        {
           $"{quiz.maxPlayerCount.ToString()}/{quiz.currentPlayerCount.ToString()}" , quiz.roomState.ToString(), quiz.createdAt.ToString()
        };
        string[] names = { "Max/Curr","RoomName", "Date"};
        for (int i = 0; i < names.Length; i++)
        {
            InsertDataToComponents(data[i], names[i]);
        }

    }
    private void InsertDataToComponents(string data,string name)
    {
        GameObject child = FindChildByName(Prefab.transform, name);
        if (child != null)
        {
            TextMeshProUGUI text = child.GetComponent<TextMeshProUGUI>();
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
