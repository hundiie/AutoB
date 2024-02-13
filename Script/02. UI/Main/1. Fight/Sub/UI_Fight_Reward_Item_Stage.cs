using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Fight_Reward_Item_Stage : MonoBehaviour
{
    public Image Image_Background;
    public Image Image_Icon;

    public TextMeshProUGUI[] _Text;

    public TextMeshProUGUI Tooltip_Head;
    public TextMeshProUGUI Tooltip_Body;

    [Header("Sprite")]
    public Sprite Coin;
    public Sprite Exp;

    public void Init()
    {
        Image_Icon.sprite = null;
        for (int i = 0; i < _Text.Length; i++)
        {
            _Text[i].text = "";
        }
    }

    public void SetCoin(int value)
    {
        Init();
        Image_Icon.sprite = Coin;
        _Text[1].text = value.ToString();

        Tooltip_Head.text = SaveData.LanguageData.Reward_Coin[SaveData.SaveValuePlayer.LanguageValue];
        Tooltip_Body.text = SaveData.LanguageData.Reward_CoinDescription[SaveData.SaveValuePlayer.LanguageValue];
        
        SaveData.SaveValueGame.Gold += value;
        Canvas_Main.instance._UI_TopCategory.SetGold();
    }
    public void SetExp(int value)
    {
        Init();
        Image_Icon.sprite = Exp;
        _Text[1].text = value.ToString();
        
        Tooltip_Head.text = SaveData.LanguageData.Reward_Exp[SaveData.SaveValuePlayer.LanguageValue];
        Tooltip_Body.text = SaveData.LanguageData.Reward_ExpDescription[SaveData.SaveValuePlayer.LanguageValue];

        for (int i = 0; i < UnitManager.instance.Units_Player.Count; i++)
        {
            UnitManager.instance.Units_Player[i].Exp += value;
        }
    }
    public void SetItem(int id)
    {
        ItemData data = ResourcesData.Get_ItemData(id);
        if (data != null)
            SetItem(data);
    }
    public void SetItem(ItemData data)
    {
        Init();
        Image_Icon.sprite = data.Sprite;
        Image_Background.color = SaveData.SaveValue.ItemColor[(int)data.Type];

        Tooltip_Head.text = data.Name[SaveData.SaveValuePlayer.LanguageValue];
        Tooltip_Body.text = data.GetItemDescription();
    }

}
