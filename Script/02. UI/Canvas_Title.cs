using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ricimi;

public class Canvas_Title : MonoBehaviour
{
    public Image Don;

    private void Awake()
    {
        Don.raycastTarget = false;
    }
    public void SetButton_Play()
    {
        Don.raycastTarget = true;
        Transition.LoadLevel("Panel", 2, Color.black);
    }
    public void SetButton_Option()
    {

    }
    public void SetButton_Exit()
    {

    }
}
