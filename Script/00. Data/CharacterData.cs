using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterClass
{
    Warrior,
    Wizard,
    Support,
}

[System.Serializable]
public struct CharacterSkill
{
    [Header("In")]
    public Sprite Skill_Sprite;

    public string[] Skill_Name;
    [Multiline(3)] public string[] Skill_Description;
    public float[] DescriptionValue;
    public float[] DescriptionValue_Upgrade;

    public int Skill_Delay;
    public int Skill_Cost;

    [Header("Out")]
    public int Skill_Price;
    public int Skill_Price_Upgrade;

    [Header("Sound")]
    public AudioClip SkillClip;

    [Header("FX")]
    public GameObject FX;

    public string GetDescriptionValue(int level)
    {
        string ret = Skill_Description[SaveData.SaveValuePlayer.LanguageValue];
        for (int i = 0; i < DescriptionValue.Length; i++)
        {
            ret = ret.Replace($"({i})", $"{DescriptionValue[i] + (level * DescriptionValue_Upgrade[i])}");
        }
        return ret;
    }
}

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Character", order = int.MaxValue)]
public class CharacterData : ScriptableObject
{
    // 정보
    [SerializeField] private int _Id;
    [SerializeField] private string [] _Character_Name;
    [SerializeField] private string [] _Character_Description;
    [SerializeField] private CharacterClass _Class;
    public int Id { get { return _Id; } }
    public string [] Character_Name { get { return _Character_Name; } }
    public string [] Character_Description { get { return _Character_Description; } }
    public CharacterClass Class { get { return _Class; } }
    
    // 패시브
    [Multiline(3)][SerializeField] private string [] _Character_PassiveDescription;
    [SerializeField] private float[] _PassiveValue;
    [SerializeField] private float[] _PassiveValue_Upgrade;
    public string [] Character_PassiveDescription
    { get { return _Character_PassiveDescription; } }
    public float[] PassiveValue { get { return _PassiveValue; } }
    public float[] PassiveValue_Upgrade { get { return _PassiveValue_Upgrade; } }
    
    // 업그레이드
    [SerializeField] private int _Character_UpgradePrice;
    [SerializeField] private int _Character_UpgradePrice_Up;

    [SerializeField] private CharacterSkill[] _Skills;
    public int Character_UpgradePrice { get { return _Character_UpgradePrice; } }
    public int Character_UpgradePrice_Up { get { return _Character_UpgradePrice_Up; } }
    
    // 스킬
    public CharacterSkill[] Skills { get { return _Skills; } }

    public string GetPassiveDescription(int level)
    {
        string ret = _Character_PassiveDescription[SaveData.SaveValuePlayer.LanguageValue];
        for (int i = 0; i < PassiveValue.Length; i++)
        {
            ret = ret.Replace($"({i})", $"{PassiveValue[i] + (level * PassiveValue_Upgrade[i])}");
        }
        return ret;
    }
}
