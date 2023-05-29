using System;
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
    public GameObject objNum;
    private DataController Controller;
    [SerializeField] private GameObject PrefabImage;
    private bool helper;
    private GameObject LoadingInstance;

    void Start()
    {
        helper = true;
        Controller = new DataController();
        LoadGamesToButtonsWithNum(buttonPrefab);
    }

    void Update()
    {
        if (Controller.Loading && !helper)
        {
            LoadingInstance = Instantiate(PrefabImage, transform);
            helper = true;
        }

        if (!Controller.Loading && helper)
        {
            Destroy(LoadingInstance);
            helper = false;
        }
    }


    /* public void LoadGamesToButtons(GameObject buttonPrefab)
     {
         DataController request = new DataController();
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
             buttonText.text = "ŽÁDNÉ HRY NENALEZENY";
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
     }*/
    public async void LoadGamesToButtonsWithNum(GameObject buttonPrefab)
    {
        Controller = new DataController(); //to melo spravit null reference
        helper = false;
        int num = SliderControl.getSliderValue(objNum);
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        await Controller.GetQuizzesAsync(num);

        if (Controller.Quizzes.Length == 0 || (Controller.Quizzes == null))
        {
            GameObject buttonInstance = Instantiate(buttonPrefab, transform);
            buttonInstance.transform.SetParent(transform);
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonInstance.GetComponent<Image>().color = Color.red;
            buttonText.text = "ŽÁDNÉ HRY NENALEZENY";
        }

        int i = 1;
        Array.ForEach(Controller.Quizzes, quiz =>
        {
            GameObject buttonInstance = Instantiate(buttonPrefab,transform);
            buttonInstance.transform.SetParent(transform);
            Button b=buttonInstance.GetComponent<Button>();
            b.GetQuizToButtonScript(quiz);
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.fontSize = 20;
            buttonText.text = quiz.ToString();
            if (i % 2 == 0)
            {
                buttonText.color = Color.white;
                buttonInstance.GetComponent<Image>().color = Color.gray;
            }
            else
            {
                buttonInstance.GetComponent<Image>().color = Color.white;
                buttonText.color = Color.black;
            }

            i++;
        });
    }
}