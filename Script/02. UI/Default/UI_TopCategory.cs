using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_TopCategory : MonoBehaviour
{
    public TextMeshProUGUI Text_Main;
    public TextMeshProUGUI Text_Sub;

    public TextMeshProUGUI Gold;
    public TextMeshProUGUI Gem;

    public Button Button_Option;

    private void Awake()
    {
        SetGold();
        SetGem();
    }

    public void SetMainText(string text)
    {
        Text_Main.text = text;
    }
    public void SetSubText(string text)
    {
        Text_Sub.text = text;
    }

    public void SetGold()
    {
        Gold.text = SaveData.SaveValueGame.Gold.ToString();
    }
    public void SetGem()
    {
        Gem.text = SaveData.SaveValueOutPlayer.Player_Gem.ToString();
    }
}
