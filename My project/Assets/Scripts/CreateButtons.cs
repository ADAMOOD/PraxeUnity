using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    private SpriteRenderer loadingSprite;
    

    void Update()
    {
       /* if (DataController.loading)
        {
            loadingSprite.enabled=true;
        }
        else
        {
            loadingSprite.enabled=false;
        }*/
    }
    void Start()
    {
       // loadingSprite = GameObject.Find("Loading").GetComponent<SpriteRenderer>();
        LoadGamesToButtons(buttonPrefab);
    }

    public void LoadGamesToButtons(GameObject buttonPrefab)
    {
        while (transform.childCount > 0)
         {
             DestroyImmediate(transform.GetChild(0).gameObject);
         }
        if (DataController.GetQuizzes().Length==0||(DataController.GetQuizzes() == null))
        {
            buttonPrefab.GetComponent<Image>().color = Color.red;
            GameObject buttonInstance = Instantiate(buttonPrefab, transform);
            buttonInstance.transform.SetParent(transform);
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = "��DN� HRY NENALEZENY";
        }
        foreach (var quiz in DataController.GetQuizzes())
        {
            if (buttonPrefab.GetComponent<Image>().color != Color.white)
            {
                buttonPrefab.GetComponent<Image>().color = Color.white;
            }
            // Instantiate the buttonPrefab
            GameObject buttonInstance = Instantiate(buttonPrefab, transform);
            // Set the parent of the instantiated buttonPrefab
            buttonInstance.transform.SetParent(transform);
            // Find the Text component inside the buttonInstance
            Debug.Log(quiz.ToString());
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = quiz.ToString();
        }
    }
}
