using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveData;
using TMPro;

public class Setting : MonoBehaviour
{
    public Item_Setting[] Item;

    public TextMeshProUGUI Text_00;

    private void Awake()
    {
        Init();
    }
    
    public void Init()
    {
        for (int i = 0; i < Item.Length; i++)
        {
            Item[i].Text_Head.text = LanguageData.Setting_Head[i, SaveValuePlayer.LanguageValue];
            Item[i].StringValue = LanguageData.GetSettingValue(i);
            Item[i].Value = SaveValueSetting.SettingValue[i];
        }
        Text_00.text = LanguageData.Setting_AddText[0, SaveValuePlayer.LanguageValue];
    }

    public void SetButton_Defaults()
    {
        for (int i = 0; i < Item.Length; i++)
        {
            Item[i].Value = SaveValueSetting.SettingValue[i];
            SaveValueSetting.SatSetting(i, 0);
        }
    }
    public void SetButton_Confirm()
    {
        for (int i = 0; i < Item.Length; i++)
        {
            SaveValueSetting.SatSetting(i, Item[i].Value);
        }

        Time.timeScale = 1;
        Destroy(gameObject);
    }
    public void SetButton_Cancel()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
