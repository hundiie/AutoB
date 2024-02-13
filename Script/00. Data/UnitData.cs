using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitStatus
{
    #region 함수
    public UnitStatus Copy_Data() { return (UnitStatus)this.MemberwiseClone(); }

    public void AddStatus(UnitStatus status, bool value)
    {
        if (status.Hp != 0)                         Hp +=                       value ? status.Hp : -status.Hp;
        if (status.HpRegen != 0)                    HpRegen +=                  value ? status.HpRegen : -status.HpRegen;
        
        if (status.Shield != 0)                     Shield +=                   value ? status.Shield : -status.Shield;

        if (status.Mp != 0)                         Mp +=                       value ? status.Mp : -status.Mp;
        if (status.MpStart != 0)                    MpStart +=                  value ? status.MpStart : -status.MpStart;
        if (status.MpRegen != 0)                    MpRegen +=                  value ? status.MpRegen : -status.MpRegen;
        if (status.MpRate != 0)                     MpRate +=                   value ? status.MpRate : -status.MpRate;

        if (status.Attack_Range != 0)               Attack_Range +=             value ? status.Attack_Range : -status.Attack_Range;
        if (status.Attack_Speed != 0)               Attack_Speed +=             value ? status.Attack_Speed : -status.Attack_Speed;
        if (status.Attack_Physic != 0)              Attack_Physic +=            value ? status.Attack_Physic : -status.Attack_Physic;
        if (status.Attack_PhysicPiercing != 0)      Attack_PhysicPiercing +=    value ? status.Attack_PhysicPiercing : -status.Attack_PhysicPiercing;
        if (status.Attack_Magic != 0)               Attack_Magic +=             value ? status.Attack_Magic : -status.Attack_Magic;
        if (status.Attack_MagicPiercing != 0)       Attack_MagicPiercing +=     value ? status.Attack_MagicPiercing : -status.Attack_MagicPiercing;
        if (status.Attack_CriticalChance != 0)      Attack_CriticalChance +=    value ? status.Attack_CriticalChance : -status.Attack_CriticalChance;
        if (status.Attack_CriticalDamage != 0)      Attack_CriticalDamage +=    value ? status.Attack_CriticalDamage : -status.Attack_CriticalDamage;

        if (status.Defense_Armor != 0)              Defense_Armor +=            value ? status.Defense_Armor : -status.Defense_Armor;
        if (status.Defense_Resist != 0)             Defense_Resist +=           value ? status.Defense_Resist : -status.Defense_Resist;

        if (status.Special_MissRate != 0)           Special_MissRate +=         value ? status.Special_MissRate : -status.Special_MissRate;
        if (status.Special_Evasion != 0)            Special_Evasion +=          value ? status.Special_Evasion : -status.Special_Evasion;
        if (status.Special_MoveSpeed != 0)          Special_MoveSpeed +=        value ? status.Special_MoveSpeed : -status.Special_MoveSpeed;
        if (status.Special_Absorb != 0)             Special_Absorb +=           value ? status.Special_Absorb : -status.Special_Absorb;
        if (status.Special_DamageReduction != 0)    Special_DamageReduction +=  value ? status.Special_DamageReduction : -status.Special_DamageReduction;
        if (status.Special_DamageIncrease != 0)     Special_DamageIncrease +=   value ? status.Special_DamageIncrease : -status.Special_DamageIncrease;
        
        if (status.ExpRate != 0)                    ExpRate +=                  value ? status.ExpRate : -status.ExpRate;
    }

    #endregion

    #region 스텟
    [Header("체력")]
    [SerializeField] private float _Hp;
    [SerializeField] private float _HpRegen;
    public float Hp { get { return _Hp; } set { _Hp = value; } }
    public float HpRegen { get { return _HpRegen; } set { _HpRegen = value; } }

    [Header("쉴드")]
    [SerializeField] private float _Shield;
    public float Shield { get { return _Shield; } set { _Shield = value; } }

    [Header("마나")]
    [SerializeField] private float _Mp;
    [SerializeField] private float _MpStart;
    [SerializeField] private float _MpRegen;
    [SerializeField] private float _MpRate;
    public float Mp { get { return _Mp; } set { _Mp = value; } }
    public float MpStart { get { return _MpStart; } set { _MpStart = value; } }
    public float MpRegen { get { return _MpRegen; } set { _MpRegen = value; } }
    public float MpRate { get { return _MpRate; } set { _MpRate = value; } }

    [Header("공격")]
    [SerializeField] private int _Attack_Range;
    [SerializeField] private float _Attack_Speed;
    [SerializeField] private float _Attack_Physic;
    [SerializeField] private float _Attack_PhysicPiercing;
    [SerializeField] private float _Attack_Magic;
    [SerializeField] private float _Attack_MagicPiercing;
    [SerializeField] private float _Attack_CriticalChance;
    [SerializeField] private float _Attack_CriticalDamage;
    public int Attack_Range { get { return _Attack_Range; } set { _Attack_Range = value; } }
    public float Attack_Speed { get { return _Attack_Speed; } set { _Attack_Speed = value; } }
    public float Attack_Physic { get { return _Attack_Physic; } set { _Attack_Physic = value; } }
    public float Attack_PhysicPiercing { get { return _Attack_PhysicPiercing; } set { _Attack_PhysicPiercing = value; } }
    public float Attack_Magic { get { return _Attack_Magic; } set { _Attack_Magic = value; } }
    public float Attack_MagicPiercing { get { return _Attack_MagicPiercing; } set { _Attack_MagicPiercing = value; } }
    public float Attack_CriticalChance { get { return _Attack_CriticalChance; } set { _Attack_CriticalChance = value; } }
    public float Attack_CriticalDamage { get { return _Attack_CriticalDamage; } set { _Attack_CriticalDamage = value; } }

    [Header("방어")]
    [SerializeField] private float _Defense_Armor;
    [SerializeField] private float _Defense_Resist;
    public float Defense_Armor { get { return _Defense_Armor; } set { _Defense_Armor = value; } }
    public float Defense_Resist { get { return _Defense_Resist; } set { _Defense_Resist = value; } }

    [Header("특수")]
    [SerializeField] private float _Special_MissRate;            // 공격 실패율 (%)
    [SerializeField] private float _Special_Evasion;
    [SerializeField] private float _Special_MoveSpeed;
    [SerializeField] private float _Special_Absorb;             // 흡혈 (%)
    [SerializeField] private float _Special_DamageReduction;    // 받는 피해 감소(%)
    [SerializeField] private float _Special_DamageIncrease;     // 주는 피해 증가(%)
    public float Special_MissRate { get { return _Special_MissRate; } set { _Special_MissRate = value; } }
    public float Special_Evasion { get { return _Special_Evasion; } set { _Special_Evasion = value; } }
    public float Special_MoveSpeed { get { return _Special_MoveSpeed; } set { _Special_MoveSpeed = value; } }
    public float Special_Absorb { get { return _Special_Absorb; } set { _Special_Absorb = value; } }
    public float Special_DamageReduction { get { return _Special_DamageReduction; } set { _Special_DamageReduction = value; } }
    public float Special_DamageIncrease { get { return _Special_DamageIncrease; } set { _Special_DamageIncrease = value; } }

    [Header("Exp")]
    [SerializeField] private float _ExpRate;
    public float ExpRate { get { return _ExpRate; } set { _ExpRate = value; } }

    #endregion
}

[System.Serializable]
public class UnitSound
{
    public AudioClip Clip_Attack;
    public AudioClip Clip_Damage;
    public AudioClip Clip_Death;
}

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Unit", order = int.MaxValue)]
public class UnitData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private int _Id;
    [SerializeField] private string[] _Name;
    [SerializeField] private Sprite _Sprite;
    [SerializeField][Multiline(3)] private string[] _Description;
    public int Id { get { return _Id; } }
    public string[] Name { get { return _Name; } }
    public Sprite Sprite { get { return _Sprite; } }
    public string[] Description { get { return _Description; } }
    
    [Header("사운드")]
    [SerializeField] private UnitSound _Sound;
    public UnitSound Sound { get { return _Sound; } }

    [Header("오브젝트")]
    [SerializeField] private GameObject _Prefab_Unit;
    [SerializeField] private GameObject _Prefab_Projectile;
    public GameObject Prefab_Unit { get { return _Prefab_Unit; } }
    public GameObject Prefab_Projectile { get { return _Prefab_Projectile; } }

    [Header("투사체")]
    [SerializeField] private float _Projectile_StartDelay;
    [SerializeField] private float _Projectile_Power;
    [SerializeField] private float _Projectile_Speed;
    public float Projectile_StartDelay { get { return _Projectile_StartDelay; } }
    public float Projectile_Power { get { return _Projectile_Power; } }
    public float Projectile_Speed { get { return _Projectile_Speed; } }

    [Header("스탯")]
    [SerializeField] private UnitStatus _Status;
    public UnitStatus Status { get { return _Status; } }

    [Header("스킬")]
    [SerializeField] private List<int> _Skilll_Id;
    public List<int> Skilll_Id { get { return _Skilll_Id; } }
}
