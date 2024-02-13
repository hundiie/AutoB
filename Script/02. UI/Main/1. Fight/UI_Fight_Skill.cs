using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Fight_Skill : MonoBehaviour
{
    [Header("Cost")]
    public TextMeshProUGUI Cost_Value;
    public TextMeshProUGUI Cost_Description;
    

    [Header("Skill")]
    public Button[] Skill_Button;
    public Image[] Skill_Icon;
    public Image[] Skill_Cooltime;
    public TextMeshProUGUI[] Skill_Cost;
    public TextMeshProUGUI[] Skill_Delay;

    public TextMeshProUGUI[] Tooltip_Name;
    public TextMeshProUGUI[] Tooltip_Description;
    public TextMeshProUGUI[] Tooltip_Cost;
    public TextMeshProUGUI[] Tooltip_Delay;

    private void Awake()
    {
        for (int i = 0; i < Skill_Cooltime.Length; i++)
        {
            Skill_Cooltime[i].gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (SaveValueGame.Current_GameState == GameState.Fight)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SetButton_Skill(0);
            if (Input.GetKeyDown(KeyCode.W))
                SetButton_Skill(1);
            if (Input.GetKeyDown(KeyCode.E))
                SetButton_Skill(2);
        }
    }
    public void SetPlayerCost()
    {
        Cost_Value.text = LanguageData.Skill_CostText[SaveValuePlayer.LanguageValue] + " : " + SaveValueGame.Cost;
        Cost_Description.text = LanguageData.Skill_CostDescription[SaveValuePlayer.LanguageValue];
    }

    public void SetSkill(int value)
    {
        Skill_Icon[value].sprite = Canvas_Main.instance._CharacterData.Skills[value].Skill_Sprite;
        Skill_Cost[value].text = Canvas_Main.instance._CharacterData.Skills[value].Skill_Cost.ToString();
        Skill_Delay[value].text = Canvas_Main.instance._CharacterData.Skills[value].Skill_Delay.ToString();
        
        Tooltip_Name[value].text = Canvas_Main.instance._CharacterData.Skills[value].Skill_Name[SaveValuePlayer.LanguageValue];
        Tooltip_Description[value].text = Canvas_Main.instance._CharacterData.Skills[value].GetDescriptionValue(SaveValueOutPlayer.Character_SkillLevel[SaveData.SaveValueGame.CharacterId, value]);
        Tooltip_Cost[value].text = LanguageData.Skill_CostText[SaveValuePlayer.LanguageValue] + " : " + Canvas_Main.instance._CharacterData.Skills[value].Skill_Cost;
        Tooltip_Delay[value].text = LanguageData.Skill_DelayText[SaveValuePlayer.LanguageValue] + " : " + Canvas_Main.instance._CharacterData.Skills[value].Skill_Delay;
    }

    public void SetButton_Skill(int value)
    {
        int falseText = 0;

        if (SaveValueGame.Current_FightState != FightState.Fight)
            falseText = 0 + 1;
        else if(Skill_Cooltime[value].gameObject.activeSelf)
            falseText = 1 + 1;
        else if (SaveValueGame.Cost < Canvas_Main.instance._CharacterData.Skills[value].Skill_Cost)
            falseText = 2 + 1;

        if (falseText != 0)
            Skill_Failed(value, LanguageData.Skill_FailedText[falseText - 1, SaveValuePlayer.LanguageValue]);

        PlayerManager.instance.SetCharacterSkill(value, falseText != 0 ? false : true);
    }

    public void Skill_Success(int value)
    {
        StartCoroutine(SetCooltime(value, Canvas_Main.instance._CharacterData.Skills[value].Skill_Delay));
        SaveValueGame.Cost -= Canvas_Main.instance._CharacterData.Skills[value].Skill_Cost;
        SetPlayerCost();
        Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, "", ColorData.Gray_Light, 0.2f);
    }
    public void Skill_Failed(int value, string text)
    {
        Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, text, ColorData.Gray_Light, 2f);
    }

    public IEnumerator SetCooltime(int value, float delay)
    {
        Skill_Cooltime[value].gameObject.SetActive(true);
        
        for (float i = 1; i >= 0; i -= Time.deltaTime / delay)
        {
            Skill_Cooltime[value].fillAmount = i;

            yield return new WaitForEndOfFrame();
        }

        Skill_Cooltime[value].gameObject.SetActive(false);
    }
}
