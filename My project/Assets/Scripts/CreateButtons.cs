using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    void Start()
    {
        LoadGamesToButtons(buttonPrefab);
    }

    public void LoadGamesToButtons(GameObject buttonPrefab)
    {
        while (transform.childCount > 0)
         {
             DestroyImmediate(transform.GetChild(0).gameObject);
         }
         Debug.Log("cekacka");
        Thread.Sleep(1000);
        if (DataController.GetQuizzes().Length==0)
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
    }
}
