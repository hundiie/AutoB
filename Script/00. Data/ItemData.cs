using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTag
{
    Unit,
    Item,
}
public enum ItemType
{
    Nomal,
    Good,
    VeryGood,
    Bad,
}

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Item", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private int _Id;
    public int Id { get { return _Id; } }
    [SerializeField] private ItemTag _Tag;
    public ItemTag Tag { get { return _Tag; } }
    
    [Header("데이터")]
    [SerializeField] private string[] _Name;
    public string[] Name { get { return _Name; } }
    
    [Multiline(3)][SerializeField] private string[] _Description;
    
    [SerializeField] private ItemType _Type;
    public ItemType Type { get { return _Type; } }
    public string[] Description { get { return _Description; } }
    
    [SerializeField] private Sprite _Sprite;
    public Sprite Sprite { get { return _Sprite; } }
    
    [SerializeField] private float[] _Item_DescriptionValue;
    public float[] Item_DescriptionValue { get { return _Item_DescriptionValue; } }

    [Header("Item")]
    [SerializeField] private Faction _UseFaction;
    public Faction UseFaction { get { return _UseFaction; } }

    [Header("Unit")]

    [SerializeField] private int _Unit_Value;
    public int Unit_Value { get { return _Unit_Value; } }

    [Header("Shop")]
    [SerializeField] private int _GoldCost;
    public int GoldCost { get { return _GoldCost; } }

    public string GetItemDescription()
    {
        string ret = Description[SaveData.SaveValuePlayer.LanguageValue];
        for (int i = 0; i < Item_DescriptionValue.Length; i++)
        {
            ret = ret.Replace($"({i})", $"{Item_DescriptionValue[i]}");
        }
        return ret;
    }
}
