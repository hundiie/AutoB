using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ricimi;

public class Main_Option : MonoBehaviour
{
    public CanvasGroup _CanvasGroup;
    public GameObject Prefab_Setting;

    public void SetButton_Option()
    {
        SetCanvasGroup(true);
        Time.timeScale = 0;
    }
    public void SetButton_Back()
    {
        Time.timeScale = 1;
        SetCanvasGroup(false);
    }
    public void SetButton_Settion()
    {
        SetCanvasGroup(false);
        GameObject ins = Instantiate(Prefab_Setting, Canvas_Main.instance.transform);
        ins.GetComponent<Setting>().Init();
    }
    public void SetButton_Main()
    {
        SetCanvasGroup(false);
        Time.timeScale = 1;
        Transition.LoadLevel("Title", 2, Color.black);
    }

    public void SetCanvasGroup(bool value)
    {
        _CanvasGroup.alpha = value ? 1 : 0;
        _CanvasGroup.interactable = value;
        _CanvasGroup.blocksRaycasts = value;
    }
}
