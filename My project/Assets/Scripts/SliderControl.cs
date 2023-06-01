using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SliderControl : MonoBehaviour
{
    public Slider slider;
    public GameObject TextObjecGameObject;
    private Text text;
    public Dictionary<TextMeshProUGUI, float> MaxSizesOfObjects;
    void Start()
    {
        slider = GetComponent<Slider>();
        text = TextObjecGameObject.GetComponent<Text>();
        text.text = slider.value.ToString();
        MaxSizesOfObjects = new Dictionary<TextMeshProUGUI, float>();
        slider.value = slider.maxValue;
        changeFont();
    }
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
            float fontSizeHeaders = Mathf.Lerp(40f, 72, slider.value / 10f);
            HText.fontSize = (int)(fontSizeHeaders);
            if (HText.isTextOverflowing)
            {
                HText.overflowMode = TextOverflowModes.Ellipsis;
            }
        }
        foreach (var normal in normals)
        {
            TextMeshProUGUI NText = normal.GetComponent<TextMeshProUGUI>();
            float fontSizeHeaders = Mathf.Lerp(15f, 32, slider.value / 10f);
            NText.fontSize = (int)(fontSizeHeaders);
            if (NText.isTextOverflowing)
            {
                NText.overflowMode = TextOverflowModes.Ellipsis;
            }
        }
    }

    public void GetObjectsMaxsizes()
    {
        Debug.Log(MaxSizesOfObjects);
        var headers = GameObject.FindGameObjectsWithTag("Header");
        var normals = GameObject.FindGameObjectsWithTag("Normal");
        headers = CheckForDoubles(headers);
        normals = CheckForDoubles(normals);
        AddDatatoDictionary(headers);
        AddDatatoDictionary(normals);
        foreach (var Gobject in MaxSizesOfObjects)
        {
            Debug.Log($"{Gobject.Key.text}----->{Gobject.Value} font size");
        }
    }

    private void AddDatatoDictionary(GameObject[] array)
    {
        if (array == null)
        {
            return;
        }
        foreach (var header in array)
        {
            TextMeshProUGUI text = header.GetComponent<TextMeshProUGUI>();
            float maxSize = text.fontSize;
            do
            {
                maxSize += 1;
            } while (!text.isTextOverflowing);
            MaxSizesOfObjects.Add(text, maxSize);
        }
    }

    private GameObject[] CheckForDoubles(GameObject[] array)
    {
        if (array.Length == 0)
        {
            return new GameObject[0];
        }
        foreach (var item in array)
        {
            if (!item.GetComponent<TextMeshProUGUI>())
            {
                array = array.Where(obj => obj != item).ToArray();
                break;
            }
            TextMeshProUGUI text = item.GetComponent<TextMeshProUGUI>();
            if (MaxSizesOfObjects.ContainsKey(text) || text.text == "")
            {
                array = array.Where(obj => obj != item).ToArray();
            }
        }
        return array;
    }

    public static int getSliderValue(GameObject GObject)
    {
        Slider s = GObject.GetComponent<Slider>();
        return (int)s.value;
    }
}
