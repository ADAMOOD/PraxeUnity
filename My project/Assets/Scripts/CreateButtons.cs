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
    private DataController Controller ;
    [SerializeField] private GameObject PrefabImage;
    private bool helper;
    private GameObject LoadingInstance;
    void Start()
    {
        helper=true;
        Controller = new DataController();
        Controller.QuizzesLoaded += OnQuizzesLoaded; // Pøipojení k události QuizzesLoaded
        LoadGamesToButtonsWithNum(buttonPrefab);
    }

    void Update()
    {
        if (Controller.Loading && !helper)
        {
            Debug.Log("nacitani");
            LoadingInstance = Instantiate(PrefabImage, transform);
            helper = true;
        }
        if (!Controller.Loading && helper)
        {
            Debug.Log($"niceni {PrefabImage.name}");
            Destroy(LoadingInstance); // Znièení instance objektu
            helper = false;
        }
    }

    // Metoda, která se volá po dokonèení naèítání kvízù
    private void OnQuizzesLoaded()
    {
        Debug.Log("Naèítání dokonèeno"); // Zde mùžete provést další akce po dokonèení naèítání
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
        helper = false;
        int num = SliderControl.getSliderValue(objNum);
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        await Controller.GetQuizzesAsync(num);

        if (Controller.Quizzes.Length == 0 || (Controller.Quizzes == null))
        {
            buttonPrefab.GetComponent<Image>().color = Color.red;
            GameObject buttonInstance = Instantiate(buttonPrefab, transform);
            buttonInstance.transform.SetParent(transform);
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = "ŽÁDNÉ HRY NENALEZENY";
        }
        Array.ForEach(Controller.Quizzes, quiz =>
        {
            if (buttonPrefab.GetComponent<Image>().color != Color.white)
            {
                buttonPrefab.GetComponent<Image>().color = Color.white;
            }
            GameObject buttonInstance = Instantiate(buttonPrefab, transform);
            buttonInstance.transform.SetParent(transform);
            TextMeshProUGUI buttonText = buttonInstance.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = quiz.ToString();
        });
        Debug.Log("Naèítání dokonèeno");
    }
}
