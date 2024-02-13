using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Skill", order = int.MaxValue)]
public class SkillData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private int _Id;
    [SerializeField] private string[] _Name;
    [Multiline(3)][SerializeField] private string[] _Description;
    [SerializeField] private Sprite _Sprite;
    
    public int Id { get { return _Id; } }
    public string[] Name { get { return _Name; } }
    public string[] Description { get { return _Description; } }
    public Sprite Sprite { get { return _Sprite; } }

    [Header("딜레이")]
    [SerializeField] private float _StartDelay;
    [SerializeField] private float _EndDelay;
    
    public float StartDelay { get { return _StartDelay; } }
    public float EndDelay { get { return _EndDelay; } }

    [Header("Value")]
    [SerializeField] private float _Mp;
    [SerializeField] private bool _Passive;
    [SerializeField] private float [] _Values;

    public float Mp { get { return _Mp; } }
    public bool Passive { get { return _Passive; } }
    public float [] Values { get { return _Values; } }

    [Header("오브젝트")]
    [SerializeField] GameObject [] _Prefab;
    public GameObject [] Prefab { get { return _Prefab; } }
    
    [Header("FX")]
    [SerializeField] GameObject _FX_Start;
    [SerializeField] GameObject _FX;
    [SerializeField] GameObject _FX_End;
    
    public GameObject FX_Start { get { return _FX_Start; } }
    public GameObject FX { get { return _FX; } }
    public GameObject FX_End { get { return _FX_End; } }

    public string GetDescriptionValue()
    {
        string ret = Description[SaveData.SaveValuePlayer.LanguageValue];
        for (int i = 0; i < Values.Length; i++)
        {
            ret = ret.Replace($"({i})", $"{Values[i]}");
        }
        return ret;
    }
    public string GetDescriptionValue(float magic)
    {
        string ret = Description[SaveData.SaveValuePlayer.LanguageValue];
        for (int i = 0; i < Values.Length; i++)
        {
            ret = ret.Replace($"({i})", $"{Values[i] * (magic / 100)}");
        }
        return ret;
    }
    //[Header("타겟")]
    //[SerializeField] private Manager.TargetFaction _Faction;
    //[SerializeField] private Manager.TargetMode _Mode;

    //public Manager.TargetFaction Faction { get { return _Faction; } }
    //public Manager.TargetMode Mode { get { return _Mode; } }
}
