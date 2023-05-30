using UnityEngine;
using UnityEngine.UI;

public class ScrollColor : MonoBehaviour
{
    public Scrollbar ScrollBar;
    public GameObject ColoredArea;

    public void Scrolling()
    {
        float lerpValue = 1f - ScrollBar.value; // Invert
        Color startColor = Color.green;
        Color endColor = Color.red;
        Color lerpedColor = Color.Lerp(startColor, endColor, lerpValue);
        Image coloredImage = ColoredArea.GetComponent<Image>();
        coloredImage.color = lerpedColor;
    }
}
