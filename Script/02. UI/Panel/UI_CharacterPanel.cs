using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_CharacterPanel : MonoBehaviour
{
    [HideInInspector] public CharacterData data;

    [Header("Character Description")]
    public TextMeshProUGUI Text_CharacterName;
    public TextMeshProUGUI Text_CharacterDescription;
    public TextMeshProUGUI Text_PassiveDescription;
    public TextMeshProUGUI Text_PassiveLevel;
    public TextMeshProUGUI Text_PassiveCost;
    public TextMeshProUGUI Text_PassiveRefundName;
    public TextMeshProUGUI Text_PassiveRefundDescription;
    public TextMeshProUGUI Text_PassiveRefundCost;

    [Header("Character Skill")]
    public Image[] Image_SkillSprite;
    public TextMeshProUGUI[] Text_SkillName;
    public TextMeshProUGUI[] Text_SkillDescription;
    public TextMeshProUGUI[] Text_SkillLevel;
    public TextMeshProUGUI[] Text_SkillCost;
    public TextMeshProUGUI Text_SkillRefundName;
    public TextMeshProUGUI Text_SkillRefundDescription;
    public TextMeshProUGUI Text_SkillRefundCost;

    public float PassiveRefundValue;
    public float SkillRefundValue;

    public void SetPanel()
    {
        data = ResourcesData.Get_CharacterData(SaveData.SaveValueGame.CharacterId);
        if (data == null) return;

        SetCharacterDescription();
        SetPassiveRefund();

        SetAllSkillDescription();
        SetSkillRefund();
    }

    public void SetCharacterDescription()
    {
        if (data == null) return;

        Text_CharacterName.text = data.Character_Name[SaveData.SaveValuePlayer.LanguageValue];
        Text_CharacterDescription.text = data.Character_Description[SaveData.SaveValuePlayer.LanguageValue];
        Text_PassiveDescription.text = data.GetPassiveDescription(SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id]);
        Text_PassiveLevel.text = "Level " + (SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id] + 1);
        Text_PassiveCost.text = Support.Math.Get_UpgradeRate(data.Character_UpgradePrice, data.Character_UpgradePrice_Up, SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id]).ToString();
    }
    public void SetPassiveRefund()
    {
        Text_PassiveRefundName.text = LanguageData.Panel_RefundName[SaveData.SaveValuePlayer.LanguageValue];
        Text_PassiveRefundDescription.text = LanguageData.Panel_Passive_RefundDescription[SaveData.SaveValuePlayer.LanguageValue];

        float value = Support.Math.Get_UpgradeAllPrice(data.Character_UpgradePrice, data.Character_UpgradePrice_Up, SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id]);
        Text_PassiveRefundCost.text = LanguageData.Panel_RefundName[SaveData.SaveValuePlayer.LanguageValue] + " : " + value * 0.5f;
        PassiveRefundValue = value;
    }

    public void SetAllSkillDescription()
    {
        if (data == null) return;

        for (int i = 0; i < data.Skills.Length; i++)
        {
            SetSkillDescription(i);
        }
    }
    public void SetSkillDescription(int value)
    {
        if (data == null) return;

        Image_SkillSprite[value].sprite = data.Skills[value].Skill_Sprite;
        Text_SkillName[value].text = data.Skills[value].Skill_Name[SaveData.SaveValuePlayer.LanguageValue];
        Text_SkillDescription[value].text = data.Skills[value].GetDescriptionValue(SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, value]);
        Text_SkillLevel[value].text = "Level " + (SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, value] + 1);
        Text_SkillCost[value].text = Support.Math.Get_UpgradeRate(data.Skills[value].Skill_Price, data.Skills[value].Skill_Price_Upgrade, SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, value]).ToString();
    }
    public void SetSkillRefund()
    {
        Text_SkillRefundName.text = LanguageData.Panel_RefundName[SaveData.SaveValuePlayer.LanguageValue];
        Text_SkillRefundDescription.text = LanguageData.Panel_Skill_RefundDescription[SaveData.SaveValuePlayer.LanguageValue];

        float value = 0;
        
        for (int i = 0; i < data.Skills.Length; i++)
        {
            value += Support.Math.Get_UpgradeAllPrice(data.Skills[i].Skill_Price, data.Skills[i].Skill_Price_Upgrade, SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, i]);
        }

        Text_SkillRefundCost.text = LanguageData.Panel_RefundName[SaveData.SaveValuePlayer.LanguageValue] + " : " + value * 0.5f;
        SkillRefundValue = value;
    }
}
