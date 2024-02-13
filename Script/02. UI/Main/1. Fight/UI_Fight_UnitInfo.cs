using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Fight_UnitInfo : MonoBehaviour
{
    private CanvasGroup _CanvasGroup;
    public Unit _Unit;

    [Header("Skill")]
    public Image Skill_Icon;
    public TextMeshProUGUI Skill_TooltipHead;
    public TextMeshProUGUI Skill_TooltipBody;

    [Header("Head")]
    public Image Head_Icon;
    public TextMeshProUGUI Head_Name;
    public TextMeshProUGUI Head_Level;
    public TextMeshProUGUI Head_LevelTooltipHead;
    public TextMeshProUGUI Head_LevelTooltipBody;


    [Header("Life")]
    public Slider Slider_Hp;
    public Slider Slider_Mp;
    public Slider Slider_Shield;
    public TextMeshProUGUI[] Lift_Text;

    [Header("Stat")]
    public TextMeshProUGUI[] Stat_Value;
    public TextMeshProUGUI[] Stat_TooltipHead;
    public TextMeshProUGUI[] Stat_TooltipBody;

    [Header("Perk")]
    public GameObject Perk_ItemObject;
    public TextMeshProUGUI Perk_HeadText;
    public GameObject[] Perk_Item;
    public TextMeshProUGUI[] Perk_ToolTipHead;
    public TextMeshProUGUI[] Perk_ToolTipBody;
    
    private void Awake()
    {
        _CanvasGroup = GetComponent<CanvasGroup>();
        SetLifeColor();
    }

    private void Update()
    {
        if (_Unit != null)
        {
            if (_Unit.IsDeath)
                _Unit = null;
        }

        if (_Unit == null && _CanvasGroup.alpha == 1f)
            _CanvasGroup.alpha = 0f;
        if (_Unit != null && _CanvasGroup.alpha == 0f)
            _CanvasGroup.alpha = 1f;
        
        if (_Unit != null)
            Stay();
    }

    public void SetUnit(Unit unit)
    {
        if (unit == null)
        {
            _Unit = null;
            return;
        }
        _Unit = unit;
        Enter();
    }

    public void Enter()
    {
        SetHead();
        SetLifeColor();
        SetSkill();
        SetStat();
        SetPerk();
        Delay = 0.5f;

        if (_Unit._SkillData.Passive)
        {
            Slider_Mp.value = 100;
            Lift_Text[1].text = "Passive";
        }
    }
    float Delay = 0.5f;
    public void Stay()
    {
        SetLife();
        
        Delay -= Time.deltaTime;
        if (Delay <= 0)
        {
            Delay = 0.5f;
            SetSkill();
            SetStat();
        }
    }

    public void SetTooltip()
    {
        for (int i = 0; i < Stat_TooltipHead.Length; i++)
        {
            Stat_TooltipHead[i].text = LanguageData.Stat_Tooltip_HeadText[i, SaveData.SaveValuePlayer.LanguageValue];
            Stat_TooltipBody[i].text = LanguageData.Stat_Tooltip_BodyText[i, SaveData.SaveValuePlayer.LanguageValue];
        }
    }
    public void SetHead()
    {
        Head_Icon.sprite = _Unit._UnitData.Sprite;
        Head_Name.text = _Unit.Name;
        
        Head_Level.text = "Lv : " + _Unit.Level;
        Head_LevelTooltipHead.text = LanguageData.Head_LevelTooltip_HeadTeXT[SaveData.SaveValuePlayer.LanguageValue];
        Head_LevelTooltipBody.text = LanguageData.Head_LevelTooltip_BodyTeXT[SaveData.SaveValuePlayer.LanguageValue];
    }
    public void SetSkill()
    {
        Skill_Icon.sprite = _Unit._SkillData.Sprite;
        Skill_TooltipHead.text = _Unit._SkillData.Name[SaveData.SaveValuePlayer.LanguageValue];
        Skill_TooltipBody.text = _Unit._SkillData.GetDescriptionValue(_Unit.Stat.Attack_Magic);
    }
    public void SetLife()
    {
        float hp = _Unit.Stat.Hp;
        float mp = _Unit.Stat.Mp;

        Slider_Hp.value = Support.Math.Get_ValueRate(_Unit.CurrentHp, hp, Slider_Hp.maxValue);
        Slider_Shield.value = Support.Math.Get_ValueRate(_Unit.CurrentShield, hp, Slider_Shield.maxValue);

        if (_Unit.CurrentShield <= 0)
            Lift_Text[0].text = $"{(int)_Unit.CurrentHp} / {(int)hp}";
        else
            Lift_Text[0].text = $"{(int)_Unit.CurrentHp} / {(int)hp} [{(int)_Unit.CurrentShield}]";

        if (!_Unit._SkillData.Passive)
        {
            Slider_Mp.value = Support.Math.Get_ValueRate(_Unit.CurrentMp, mp, Slider_Mp.maxValue);
            Lift_Text[1].text = $"{(int)_Unit.CurrentMp} / {(int)_Unit.Stat.Mp}";
        }

    }
    public void SetLifeColor()
    {
        Slider_Hp.fillRect.GetComponent<Image>().color = SaveData.SaveValuePlayer.Life_HpColor;
        Slider_Mp.fillRect.GetComponent<Image>().color = SaveData.SaveValuePlayer.Life_MpColor;
        Slider_Shield.fillRect.GetComponent<Image>().color = SaveData.SaveValuePlayer.Life_ShieldColor;
    }
    public void SetStat()
    {
        if (_Unit == null) return;

        Stat_Value[0].text = (Mathf.Floor(_Unit.Stat.Attack_Physic * 100f) / 100f).ToString();
        Stat_Value[1].text = (Mathf.Floor(_Unit.Stat.Attack_Magic * 100f) / 100f).ToString();
        Stat_Value[2].text = (Mathf.Floor(_Unit.Stat.Attack_Speed * 100f) / 100f).ToString();
        Stat_Value[3].text = (Mathf.Floor(_Unit.Stat.Defense_Armor * 100f) / 100f).ToString();
        Stat_Value[4].text = (Mathf.Floor(_Unit.Stat.Defense_Resist * 100f) / 100f).ToString();

        Stat_Value[5].text = (Mathf.Floor(_Unit.Stat.Attack_CriticalChance * 100f) / 100f).ToString();
        Stat_Value[6].text = (Mathf.Floor(_Unit.Stat.Attack_CriticalDamage * 100f) / 100f).ToString();
        Stat_Value[7].text = (Mathf.Floor(_Unit.Stat.Special_Absorb * 100f) / 100f).ToString();
        Stat_Value[8].text = (Mathf.Floor(_Unit.Stat.Attack_Range * 100f) / 100f).ToString();
        Stat_Value[9].text = (Mathf.Floor(_Unit.Stat.Special_MoveSpeed * 100f) / 100f).ToString();
    }
    public void SetPerk()
    {
        Perk_HeadText.text = LanguageData.Head_Perk_Text[SaveData.SaveValuePlayer.LanguageValue];
        
        for (int i = 0; i < 5; i++)
        {
            if (_Unit._PerkData.Count > i)
            {
                Perk_Item[i].SetActive(true);

                Perk_ToolTipHead[i].color = SaveData.SaveValue.PerkColor[_Unit._PerkData[i].Color];
                Perk_ToolTipHead[i].text = _Unit._PerkData[i].Name[SaveData.SaveValuePlayer.LanguageValue];
                Perk_ToolTipBody[i].text = _Unit._PerkData[i].Description[SaveData.SaveValuePlayer.LanguageValue];
            }
            else
            {

                if (i == 0 && _Unit._PerkData.Count == 0)
                {
                    Perk_ToolTipHead[0].color = Color.white;
                    Perk_ToolTipHead[0].text = LanguageData.Head_PerkTooltip_NonTextHead[SaveData.SaveValuePlayer.LanguageValue];
                    Perk_ToolTipBody[0].text = LanguageData.Head_PerkTooltip_NonTextBody[SaveData.SaveValuePlayer.LanguageValue];
                }
                else
                {
                    Perk_Item[i].SetActive(false);
                }
            }
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(Perk_ItemObject.GetComponent<RectTransform>());
    }
}
