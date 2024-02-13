using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

[System.Serializable]
public struct UnitLimit
{
    public List<UnitStatus> Statuses;

    #region 스텟
    private float _Hp
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Hp;
            }
            return value;
        }
    }
    public float Hp
    {
        get
        {
            if (_Hp < 0)
                return 0;
            return _Hp;
        }
    }
    private float _HpRegen
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].HpRegen;
            }
            return value;
        }
    }
    public float HpRegen
    { get { return _HpRegen; } }

    private float _Shield
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Shield;
            }
            return value;
        }
    }
    public float Shield
    {
        get
        {
            if (_Shield < 0)
                return 0;
            return _Shield;
        }
    }

    private float _Mp
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Mp;
            }
            return value;
        }
    }
    public float Mp
    {
        get
        {
            if (_Mp < 0)
                return 0;
            return _Mp;
        }
    }
    private float _MpStart
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].MpStart;
            }
            return value;
        }
    }
    public float MpStart
    {
        get
        {
            if (_MpStart < 0)
                return 0;
            else if (_MpStart > _Mp)
                return _Mp;
            return _MpStart;
        }
    }
    private float _MpRegen
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].MpRegen;
            }
            return value;
        }
    }
    public float MpRegen
    { get { return _MpRegen; } }
    private float _MpRate
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].MpRate;
            }
            return value;
        }
    }
    public float MpRate
    { get { return _MpRate; } }

    private int _Attack_Range
    {
        get
        {
            int value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_Range;
            }
            return value;
        }
    }
    public int Attack_Range
    {
        get
        {
            if (_Attack_Range < 1)
                return 1;
            return _Attack_Range;
        }
    }
    private float _Attack_Speed
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_Speed;
            }
            return value;
        }
    }
    public float Attack_Speed
    {
        get
        {
            if (_Attack_Speed < 0.05f)
                return 0.05f;
            return _Attack_Speed;
        }
    }
    private float _Attack_Physic
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_Physic;
            }
            return value;
        }
    }
    public float Attack_Physic
    {
        get
        {
            if (_Attack_Physic < 0f)
                return 0f;
            return _Attack_Physic;
        }
    }
    private float _Attack_PhysicPiercing
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_PhysicPiercing;
            }
            return value;
        }
    }
    public float Attack_PhysicPiercing
    {
        get
        {
            if (_Attack_PhysicPiercing < 0f)
                return 0f;
            return _Attack_PhysicPiercing;
        }
    }
    private float _Attack_Magic
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_Magic;
            }
            return value;
        }
    }
    public float Attack_Magic
    {
        get
        {
            if (_Attack_Magic < 0f)
                return 0f;
            return _Attack_Magic;
        }
    }
    private float _Attack_MagicPiercing
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_MagicPiercing;
            }
            return value;
        }
    }
    public float Attack_MagicPiercing
    {
        get
        {
            if (_Attack_MagicPiercing < 0f)
                return 0f;
            return _Attack_MagicPiercing;
        }
    }
    private float _Attack_CriticalChance
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_CriticalChance;
            }
            return value;
        }
    }
    public float Attack_CriticalChance
    {
        get
        {
            if (_Attack_CriticalChance < 0f)
                return 0f;
            else if (_Attack_CriticalChance > 100f)
                return 100f;
            return _Attack_CriticalChance;
        }
    }
    private float _Attack_CriticalDamage
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Attack_CriticalDamage;
            }
            return value;
        }
    }
    public float Attack_CriticalDamage
    {
        get
        {
            if (_Attack_CriticalDamage < 0f)
                return 0f;
            return _Attack_CriticalDamage;
        }
    }

    private float _Defense_Armor
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Defense_Armor;
            }
            return value;
        }
    }
    public float Defense_Armor
    {
        get
        {
            if (_Defense_Armor < 0f)
                return 0;
            return _Defense_Armor;
        }
    }
    private float _Defense_Resist
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Defense_Resist;
            }
            return value;
        }
    }
    public float Defense_Resist
    {
        get
        {
            if (_Defense_Resist < 0f)
                return 0;
            return _Defense_Resist;
        }
    }

    private float _Special_MissRate
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_MissRate;
            }
            return value;
        }
    }           // 공격 실패율 (%)
    public float Special_MissRate
    {
        get
        {
            if (_Special_MissRate < 0f)
                return 0;
            else if (_Special_MissRate > 100f)
                return 100;
            return _Special_MissRate;
        }
    }
    private float _Special_Evasion
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_Evasion;
            }
            return value;
        }
    }
    public float Special_Evasion
    {
        get
        {
            if (_Special_Evasion < 0f)
                return 0;
            else if (_Special_Evasion > 90f)
                return 90;
            return _Special_Evasion;
        }
    }
    private float _Special_MoveSpeed
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_MoveSpeed;
            }
            return value;
        }
    }
    public float Special_MoveSpeed
    {
        get
        {
            if (_Special_Evasion < 0f)
                return 0;
            else if (_Special_Evasion > 90f)
                return 90;
            return _Special_MoveSpeed;
        }
    }
    private float _Special_Absorb
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_Absorb;
            }
            return value;
        }
    }             // 흡혈 (%)
    public float Special_Absorb
    {
        get
        {
            if (_Special_Absorb < 0f)
                return 0;
            return _Special_Absorb;
        }
    }
    private float _Special_DamageReduction
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_DamageReduction;
            }
            return value;
        }
    }    // 받는 피해 감소(%)
    public float Special_DamageReduction
    {
        get
        {
            if (_Special_DamageReduction > 90f)
                return 90;
            return _Special_DamageReduction;
        }
    }
    private float _Special_DamageIncrease
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].Special_DamageIncrease;
            }
            return value;
        }
    }     // 주는 피해 증가(%)
    public float Special_DamageIncrease
    { get { return _Special_DamageIncrease; } }

    private float _ExpRate
    {
        get
        {
            float value = 0;

            for (int i = 0; i < Statuses.Count; i++)
            {
                value += Statuses[i].ExpRate;
            }
            return value;
        }
    }     // 주는 피해 증가(%)
    public float ExpRate
    { get { return _ExpRate; } }

    #endregion
}

public interface IState
{
    void Enter();   // 상태 진입 시 한 번 실행
    void Stay();    // 상태 진입 후 업데이트에서 지속 실행
    void Exit();    // 상태 끝난 후 한 번 실행
    void Set();
}

public class Unit : MonoBehaviour
{
    #region 유한 상태 머신
    public enum State
    {
        Idle,
        Move,
        Attack,
        Skill,
        Death,
    }

    private IState[] _IStates;
    [SerializeField] private State _state;
    public State state
    {
        get => _state;
        set
        {
            _IStates[(int)_state].Exit();
            _state = value;
            _IStates[(int)_state].Enter();
        }
    }

    private void Awake()
    {
        _IStates = new IState[System.Enum.GetValues(typeof(State)).Length];
        _IStates[(int)State.Idle] = new Unit_IdleState(this);
        _IStates[(int)State.Move] = new Unit_MoveState(this);
        _IStates[(int)State.Attack] = new Unit_AttackState(this);
        _IStates[(int)State.Skill] = new Unit_SkillState(this);
        _IStates[(int)State.Death] = new Unit_DeathState(this);
        _Animator = GetComponent<Animator>();
    }

    #endregion
    
    private void Update()
    {
        if (CurrentHp <= 0 && state != State.Death) state = State.Death;

        if (SaveData.SaveValueGame.Current_FightState == FightState.Fight)
        {
            if (_SkillData != null && !Lock_Skill)
            {
                if (!_SkillData.Passive && CurrentMp >= Stat.Mp && state != State.Skill)
                    state = State.Skill;
            }
            if (UnitEffect[(int)EffectTrigger.Immediate_Self].Count != 0)
                SetEffect(EffectTrigger.Immediate_Self);

            _IStates[(int)_state].Stay();

            // Regen();
        }
        else if (state != State.Idle)
            state = State.Idle;
    }

    // Static 값
    public UnitRenderer _UnitRenderer { get; private set; }
    public Animator _Animator { get; private set; }
    public Faction _Faction { get; private set; }
    public UnitData _UnitData { get; private set; }
    public SkillData _SkillData { get; private set; }

    public string Name { get; private set; }
    public List<PerkData> _PerkData { get; private set; } = new List<PerkData>();

    //Bool
    public bool IsDeath;

    // Stat
    public UnitLimit Stat;
    public UnitStatus AddStatus_Static = new UnitStatus();
    public UnitStatus AddStatus_Dynamic;

    public int Level;

    private float _Exp;
    public float Exp
    {
        get { return _Exp; }
        set
        {
            // 경험치를 얻었을 때
            if (_Exp - value < 0)
            {
                float rate = (_Exp - value) * -1f;
                rate *= 1f + (Stat.ExpRate / 100f);
                
                _Exp += rate;
                return;
            }

            _Exp = value;
        }
    }

    // Life
    private float _CurrentHp;
    public float CurrentHp
    {
        get => _CurrentHp;
        set
        {
            // 데미지 받았을 때
            if (_CurrentHp - value > 0)
            {
                float reduction = Stat.Special_DamageReduction;

                if (reduction != 0)
                    reduction = 1f - (reduction / 100f);
                else
                    reduction = 1f;

                float damage = (_CurrentHp - value) * reduction;
                // 쉴드가 있으면 쉴드를 먼저 깎음
                if (CurrentShield > 0)
                {
                    CurrentShield -= damage;
                    return;
                }

                GetDamage = damage;
                _CurrentHp -= damage;
                return;
            }

            float Max = Stat.Hp;
            _CurrentHp = value > Max ? Max : value;
        }
    }

    private float _CurrentShield;
    public float CurrentShield
    {
        get => _CurrentShield;
        set
        {
            _CurrentShield = value;
            // 쉴드 이상의 데미지는 체력을 깎음
            if (_CurrentShield < 0)
            {
                CurrentHp += _CurrentShield;
                _CurrentShield = 0;
            }
        }
    }

    private float _CurrentMp;
    public float CurrentMp
    {
        get => _CurrentMp;
        set
        {
            if (_SkillData == null)
            {
                _CurrentMp = 0;
                return;
            }
            else
            {
                if (_SkillData.Passive)
                {
                    _CurrentMp = 0;
                    return;
                }
            }
            if (value - _CurrentMp > 0)
            {
                float add = (value - _CurrentMp) * (1 + (Stat.MpRate / 100));
                _CurrentMp += add;
            }
            else
                _CurrentMp = value;
        }
    }
    public float GetDamage { get; private set; }

    // 타겟
    public Unit Target_Attack;
    public Unit Target_Skill;

    // 이펙트
    public List<Effect>[] UnitEffect = new List<Effect>[System.Enum.GetValues(typeof(EffectTrigger)).Length];

    // 넣은 데미지
    public float[] Damage_Deal = new float[3];
    public Vector3 StartPos;

    // Lock
    public bool Lock_Attack;
    public bool Lock_Skill;
    public bool Lock_Move;

    // Projectile
    public GameObject Projectile_Start = null;

    public void Init(Faction faction, UnitData unitData)
    {
        _UnitRenderer = GetComponent<UnitRenderer>();

        if (_UnitRenderer != null)
            Projectile_Start = _UnitRenderer.Projectile_Start;
        
        if (Projectile_Start == null)
            Projectile_Start = gameObject;

        _Faction = faction;
        _UnitData = unitData;

        Stat.Statuses = new List<UnitStatus>();

        for (int i = 0; i < UnitEffect.Length; i++)
        { UnitEffect[i] = new List<Effect>(); }
        for (int i = 0; i < Damage_Deal.Length; i++)
        { Damage_Deal[i] = 0; }

        // 스킬 추가
        if (_UnitData.Skilll_Id.Count != 0)
        {
            int RandomSkill = Random.Range(0, _UnitData.Skilll_Id.Count);
            _SkillData = ResourcesData.Get_SkillData(_UnitData.Skilll_Id[RandomSkill]);
        }

        if (_SkillData == null)
            _SkillData = ResourcesData.Get_SkillData(0);

        if (!_SkillData.Passive)
            AddStatus_Static.Mp += _SkillData.Mp;
        else
            AddStatus_Static.Mp -= _UnitData.Status.Mp;

        // 퍽 추가
        int perkCount = Random.Range(0, 6);
        for (int i = 0; i < perkCount; i++)
        {
            int perkId = Random.Range(0, ResourcesData._PerkData.Count);
            bool redup = false;

            foreach (var item in _PerkData)
            {
                if (perkId == item.Id)
                {
                    redup = true;
                    break;
                }
            }
            // 중복 체크
            if (!redup)
            {
                _PerkData.Add(ResourcesData.Get_PerkData(perkId));
            }
            else
            {
                i--;
                continue;
            }
        }

        // 이름 추가
        switch (_Faction)
        {
            case Faction.Player:
                {
                    Name = Support.Unit.GetRandomName();
                }
                break;
            case Faction.Enamy:
                {
                    Name = _UnitData.Name[SaveData.SaveValuePlayer.LanguageValue];
                }
                break;
            default: break;
        }
        name = Name;

        StartPos = transform.position;

        InitData();
    }

    public void InitData()
    {
        transform.DOKill();
        // 위치 초기화
        MapManager.instance.SetTileUnit(transform.position, null);
        MapManager.instance.SetTileUnit(StartPos, this);
        transform.position = StartPos;

        transform.rotation = Quaternion.Euler(0, 180, 0);

        // 이펙트 초기화
        for (int i = 0; i < UnitEffect.Length; i++)
        { UnitEffect[i].Clear(); }

        // 스텟 초기화
        Stat.Statuses.Clear();
        AddStatus_Dynamic = new UnitStatus();

        Stat.Statuses.Add(_UnitData.Status);
        Stat.Statuses.Add(AddStatus_Static);
        Stat.Statuses.Add(AddStatus_Dynamic);

        // 퍽 초기화
        for (int i = 0; i < _PerkData.Count; i++)
        { Perk.SetPerk(this, _PerkData[i]); }

        // 패시브 초기화
        if (_SkillData.Passive)
            Skill.SetSkill(_SkillData.Id, this);

        // 라이프 초기화
        CurrentHp = Stat.Hp;
        CurrentShield = Stat.Shield;
        CurrentMp = Stat.MpStart;

        // 데미지 초기화
        for (int i = 0; i < Damage_Deal.Length; i++) { Damage_Deal[i] = 0; }

        _IStates[(int)State.Attack].Set();

        Target_Attack = null;
        Target_Skill = null;
    }

    public void Exit()
    {
        transform.DOKill();
        
        if (!IsDeath)
            UnitManager.instance.Remove_FactionUnit(this);

        UnitManager.instance.Remove_FactionAllUnit(this);


        if (_Faction == Faction.Player)
        {
            PlayerManager.instance.DeadUnit.Add(Name);
            Canvas_Main.instance._GameOver.Data_info[1] += 1;
        }
        else
        {
            Canvas_Main.instance._GameOver.Data_info[2] += 1;
        }

        Destroy(gameObject);
    }

    public void SetAnimator(State state)
    {
        if (state != State.Idle)
            _Animator.SetBool("Idle", false);

        switch (state)
        {
            case State.Idle:
                {
                    _Animator.SetBool("Idle", true);
                }
                break;
            case State.Move:
                {
                    _Animator.SetBool("Idle", false);
                }
                break;
            case State.Attack:
                {
                    _Animator.SetTrigger("Attack");
                }
                break;
            case State.Skill:
                {
                    _Animator.SetTrigger("Skill");
                }
                break;
            case State.Death:
                {
                    _Animator.SetTrigger("Death");
                }
                break;
            default: break;
        }
    }
    public void Regen()
    {
        if (!IsDeath)
        {
            float mp, hp;

            hp = Stat.HpRegen;
            if (hp != 0) CurrentHp += hp * Time.deltaTime;

            mp = Stat.MpRegen;
            if (mp != 0) CurrentMp += mp * Time.deltaTime;
        }
    }
    public void GetAttackTarget()
    {
        List<Unit> units = UnitManager.instance.GetTarget(this, TargetFaction.Enemies, TargetMode.MostNear);

        if (units.Count != 0)
        {
            Target_Attack = units[0];
            state = State.Attack;
        }
        else
            Target_Attack = null;
    }

    public void AddEffect(Effect effect, EffectTrigger trigger)
    {
        if (effect.IsUse)
            UnitEffect[(int)trigger].Add(effect);
    }
    public void AddEffect(List<Effect> effect, EffectTrigger trigger)
    {
        for (int i = effect.Count - 1; i >= 0; i--)
        {
            if (effect[i].IsUse)
                UnitEffect[(int)trigger].Add(effect[i]);
            else
                effect.RemoveAt(i);
        }
    }

    public void SetEffect(EffectTrigger trigger)
    {
        for (int i = UnitEffect[(int)trigger].Count - 1; i >= 0; i--)
        {
            if (UnitEffect[(int)trigger][i].IsUse)
                UnitEffect[(int)trigger][i].Play(this);
            else
                UnitEffect[(int)trigger].RemoveAt(i);
        }
        // UnitEffect[(int)trigger].Clear();
    }
}
