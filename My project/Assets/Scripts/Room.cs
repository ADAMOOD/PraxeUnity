using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRoom : MonoBehaviour
{
    public GameObject canvas;
    public void ButtonClicked()
    {
        if (canvas.activeInHierarchy == false)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
        
    }
}
