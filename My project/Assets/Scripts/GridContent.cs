using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GridContent : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        foreach (var p in Player.SortPlayersByRankDescending(Room.ButtonThing.Players) )
        {
            GameObject playerisntance = Instantiate(prefab, transform);
            InsertInformationsToGameObjectText(p.Name,"Name",playerisntance);
            InsertInformationsToGameObjectText(p.Rank,"Rank", playerisntance);
            InsertInformationsToGameObjectText(p.Country, "Country", playerisntance);
        }
    }

    private void InsertInformationsToGameObjectText(string information,string gameObjectName,GameObject Parent)
    {
        GameObject PlayerName = Room.FindChildByName(Parent.transform, gameObjectName);
        Text PlayerNameText = PlayerName.GetComponent<Text>();
        PlayerNameText.text =information;
    }
}
