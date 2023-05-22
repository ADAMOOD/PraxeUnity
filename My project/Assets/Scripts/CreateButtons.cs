using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    void Start()
    { 
        foreach (var quiz in DataController.GetQuizzes())
        {
            Debug.Log(quiz);
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
