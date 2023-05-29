using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Quiz Quiz;

    public void GetQuizToButtonScript(Quiz q)
    {
        Quiz=q;
    }


}
