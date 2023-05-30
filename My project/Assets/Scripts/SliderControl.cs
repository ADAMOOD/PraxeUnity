using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderControl : MonoBehaviour
{
    public Slider slider;
    public GameObject TextObjecGameObject;
    private Text text;
   
    void Start()
    {
        slider=GetComponent<Slider>();
        text=TextObjecGameObject.GetComponent<Text>();
        slider.value = 100;
        text.text = slider.value.ToString();
    }
    public void sliderChange()
    {
        text.text = slider.value.ToString();
    }

    public void changeFont(int headersNum)
    {
        Debug.Log(slider.value);
       var headers= GameObject.FindGameObjectsWithTag("Header");
       foreach (var header in headers)
       {
           Text text = header.GetComponent<Text>();
           text.fontSize = (int)(headersNum * slider.value);
       }
    }
    public static int getSliderValue(GameObject GObject)
    {
       Slider s = GObject.GetComponent<Slider>();
       return (int)s.value;
    }
}
