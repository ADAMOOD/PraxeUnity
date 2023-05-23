using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public GameObject Prefab;
    public bool TableOpened=false;
    public void ButtonClicked(GameObject cliGameObject)
    {
        Button buttonComponent = cliGameObject.GetComponent<Button>();
        TextMeshProUGUI textMesh = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();//veme text z tlacitka na ktere se kliklo 
        GameObject Object = Instantiate(Prefab);//zobrazi tabulklu
         Data(textMesh.text);
        TableOpened=true;
    }

    public void CloseTableOnClick(GameObject pareGameObject)
    {
        if (TableOpened)
        {
           Destroy(FindChildByName(pareGameObject.transform, "Canvas (1)")); 
        }
    }

    public void Data(string inputString)
    {
        Debug.Log(inputString);
        string[] data = Quiz.ExtractValuesFromFormattedString(inputString);
        string[] names = {"Max", "Now", "RoomName", "Date"};
        for (int i = 0; i < data.Length; i++)
        {
            InsertDataToComponents(data[i],names[i]);
        }
    }
    private void InsertDataToComponents(string data,string name)
    {
        GameObject child = FindChildByName(Prefab.transform, name);
        if (child != null)
        {
            Debug.Log(child.transform.name);
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
