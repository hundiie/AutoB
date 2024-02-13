using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;
using Ricimi;

public class UI_Gameover : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject Prefab_Dead;
    
    [Header("UI")]
    public TextMeshProUGUI Text_Head_Dead;
    public TextMeshProUGUI[] Text_Info_Name;
    public TextMeshProUGUI[] Text_Info_Value;
    public TextMeshProUGUI[] Text_Character_Name;
    public TextMeshProUGUI[] Text_Character_Value;
    public TextMeshProUGUI[] Text_Result_Name;
    public TextMeshProUGUI[] Text_Result_Value;

    [Header("Content")]
    public GameObject Content_Dead;

    [Header("Data")]
    public float[] Data_info = new float[7];
    public int[] Data_Stage = new int[6];

    public void Init()
    {
        SetDead();
        SetInfo();
        SetCharacter();
        SetResult();
    }

    public void SetDead()
    {
        Text_Head_Dead.text = LanguageData.Gameover_Dead[SaveValuePlayer.LanguageValue] + " (" + PlayerManager.instance.DeadUnit.Count + ")";

        int deadcount = PlayerManager.instance.DeadUnit.Count;
        if (deadcount > 25) deadcount = 25;

        for (int i = 0; i < deadcount; i++)
        {
            GameObject ins = Instantiate(Prefab_Dead, Content_Dead.transform);
            ins.GetComponent<TextMeshProUGUI>().text = PlayerManager.instance.DeadUnit[i];
        }
    }
    public void SetInfo()
    {
        for (int i = 0; i < Text_Info_Name.Length; i++)
        {
            Text_Info_Name[i].text = LanguageData.Gameover_Info[i, SaveValuePlayer.LanguageValue];

            if (1 <= i && i <= 7)
                Text_Info_Value[i].text = Data_info[i - 1].ToString();
            
            if (8 <= i && i <= 13)
                Text_Info_Value[i].text = Data_Stage[i - 8].ToString();
        }

        float floorRate = SaveValueGame.Floor / SaveValue.StageFloor[SaveValueGame.Stage] * 100;
        Text_Info_Value[0].text = Mathf.RoundToInt(floorRate) + " %";
    }
    public void SetCharacter()
    {
        for (int i = 0; i < Text_Character_Name.Length; i++)
        {
            Text_Character_Name[i].text = LanguageData.Gameover_Character[i, SaveValuePlayer.LanguageValue];
        }
        
        Text_Character_Value[0].text = ResourcesData.Get_CharacterData(SaveValueGame.CharacterId).Character_Name[SaveValuePlayer.LanguageValue];
        Text_Character_Value[1].text = SaveValueOutPlayer.Character_PassiveLevel[SaveValueGame.CharacterId].ToString();
        
        for (int i = 0; i < 3; i++)
        {
            Text_Character_Value[i + 2].text = SaveValueOutPlayer.Character_SkillLevel[SaveValueGame.CharacterId, i].ToString();
        }

    }
    public void SetResult()
    {
        for (int i = 0; i < 3; i++)
        {
            Text_Result_Name[i].text = LanguageData.Gameover_ResultName[i, SaveValuePlayer.LanguageValue];
        }
        
        Text_Result_Value[0].text = LanguageData.Gameover_ResultValue[(SaveValueGame.Floor / SaveValue.StageFloor[SaveValueGame.Stage] * 100 >= 100)? 0 : 1, SaveValuePlayer.LanguageValue];
        AddResult();
    }
    public void AddResult()
    {
        int exp =
            ((Data_Stage[0] - 1) * 10) +  // 일반 스테이지 경험치
            (Data_Stage[1] * 30) +  // 엘리트 스테이지 경험치
            (Data_Stage[2] * 100) + // 보스 스테이지 경험치
            (Data_Stage[3] * 3) +   // 상점 스테이지 경험치
            (Data_Stage[4] * 3) +   // 휴식 스테이지 경험치
            (Data_Stage[5] * 5);    // 물음표 스테이지 경험치

        Text_Result_Value[1].text = exp.ToString();
        SaveValueOutPlayer.Character_Exp[SaveValueGame.CharacterId] += exp;
        SaveValueOutPlayer.SetExp(SaveValueGame.CharacterId);

        int gem = (SaveValueGame.Floor * 10 * (1 + (SaveValueGame.Stage / 10))) + ((SaveValueGame.Floor / 10) * 50);
        gem -= 10;

        SaveValueOutPlayer.Player_Gem += gem;

        Text_Result_Value[2].text = gem.ToString();
    }

    public void SetButton_Back()
    {
        SaveValueGame.Init();
        Transition.LoadLevel("Title", 2, Color.black);
    }
}

public class GameoverData : MonoBehaviour
{
    public static GameoverData instance;


    private void Awake()
    {
        instance = this;
    }
}
