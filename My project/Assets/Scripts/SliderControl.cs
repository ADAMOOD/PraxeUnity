using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    /*void Update()
    {
        changeFont();
    }*/
    public void sliderChange()
    {
        text.text = slider.value.ToString();
    }

    public void changeFont()
    {
        var headers = GameObject.FindGameObjectsWithTag("Header");
        var normals = GameObject.FindGameObjectsWithTag("Normal");
        foreach (var header in headers)
        {
            TextMeshProUGUI HText = header.GetComponent<TextMeshProUGUI>();
            float maxsize = HText.fontSizeMax;
            float fontSizeHeaders = Mathf.Lerp(30f, maxsize, slider.value / 10f);
            HText.fontSize = (int)(fontSizeHeaders);
        }
        foreach (var normal in normals)
        {
            TextMeshProUGUI NText = normal.GetComponent<TextMeshProUGUI>();
            NText.enableAutoSizing=true;
            float fontSizeHeaders = Mathf.Lerp(15f, 30f, slider.value / 10f);
            NText.fontSize = (int)(fontSizeHeaders);
        }
    }
    public static int getSliderValue(GameObject GObject)
    {
       Slider s = GObject.GetComponent<Slider>();
       return (int)s.value;
    }
}
