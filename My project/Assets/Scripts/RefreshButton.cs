using UnityEngine;
using UnityEngine.UI;

public class RefreshButton : MonoBehaviour
{
    public CreateButtons ScriptButtons;

    public void ButtonPressed()
    {
        Debug.Log("zmacknuto");
        ScriptButtons.LoadGamesToButtons();
    }
}