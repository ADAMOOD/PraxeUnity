using UnityEngine;
using UnityEngine.UI;

public class ScrollColor : MonoBehaviour
{
    public Scrollbar ScrollBar;
    public GameObject ColoredArea;

    public void Scrolling()
    {
        Debug.Log(ScrollBar.value);

        /*Color coloredImage = ColoredArea.transform.GetComponent<Color>();
        Debug.Log(coloredImage);
        coloredImage.color = new Color(ScrollBar.value, 0, 0);*/
    }
}
