using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject Prefab;
    private static bool TableOpened;
    private static GameObject tableInstance=null;

    public void ButtonClicked(GameObject cliGameObject)
    {
        Button buttonComponent = cliGameObject.GetComponent<Button>();
        TextMeshProUGUI textMesh = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();//veme text z tlacitka na ktere se kliklo 
        DataSerilization(textMesh.text);
        GameObject Object = Instantiate(Prefab);//zobrazi tabulklu
        tableInstance = Object;
        TableOpened = true;
    }

    void Update()
    {
        if (TableOpened)//nevim jak zavrit
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(tableInstance);
                TableOpened = false;

            }
        }
    }

    public void DataSerilization(string inputString)
    {
        Debug.Log(inputString);
        string[] data = Quiz.ExtractValuesFromFormattedString(inputString);
        string[] names = {"Max", "Now", "RoomName", "Date","Rank"};
        for (int i = 0; i < name.Length; i++)
        {
            
            if (i<(names.Length-1))
            {
                Debug.Log($"{names[i]}-->{data[i]}");    
                InsertDataToComponents(data[i], names[i]);
            }
            else
            {
               /* double randomValue = UnityEngine.Random.Range(0, 10);
                InsertDataToComponents(randomValue.ToString(), names[i]);*/
            }
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

    private GameObject FindChildByName(Transform parent, string name)
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
