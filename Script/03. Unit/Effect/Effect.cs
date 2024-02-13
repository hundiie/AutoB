using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectTrigger
{
    /// <summary>
    /// 즉시 본인에게
    /// </summary>
    Immediate_Self = 0,
    /// <summary>
    /// 이동 시 본인에게
    /// </summary>
    Move_Self = 1,
    /// <summary>
    /// 이동 시 상대에게
    /// </summary>
    Move_Other = 2,
    /// <summary>
    /// 공격 시 본인에게
    /// </summary>
    Attack_Self = 3,
    /// <summary>
    /// 공격 시 상대에게
    /// </summary>
    Attack_Other = 4,
    /// <summary>
    /// 맞을 시 본인에게
    /// </summary>
    Hit_Self = 5,
    /// <summary>
    /// 맞을 시 상대에게
    /// </summary>
    Hit_Other = 6,
    /// <summary>
    /// 스킬 사용 시 본인에게
    /// </summary>
    Skill_Self = 5,
    /// <summary>
    /// 스킬 사용 시 상대에게
    /// </summary>
    Skill_Other = 6,
    /// <summary>
    /// 죽을 시 본인에게
    /// </summary>
    Death_Self = 7,
    /// <summary>
    /// 죽을 시 상대에게
    /// </summary>
    Death_Other = 8,
}

public class Effect
{
    protected bool IsData = false;
    public bool IsUse { get; private set; }

    protected Unit Owner;
    protected float Delay;
    protected int Count;

    // 영구적?
    protected bool Infinity;

    // 확률?
    protected bool IsChance;
    protected float Chance;

    public void setting(Unit owner, float delay, int count)
    {
        IsData = true;
        IsUse = true;

        Owner = owner;
        Delay = delay;
        Count = count;

        Infinity = count <= 0 ? true : false;
        IsChance = false;
    }
    public void setting(Unit owner, float delay, int count, float chance)
    {
        IsData = true;
        IsUse = true;

        Owner = owner;
        Delay = delay;
        Count = count;
        Chance = chance;

        Infinity = count <= 0 ? true : false;
        IsChance = true;
    }
    public virtual void Play(Unit Target)
    { Count -= Infinity ? 0 : 1; }
    protected IEnumerator PlayEffect(EffectDamage value, Unit Target)
    {
        if (Count <= 0 && !Infinity)
            IsUse = false;

        yield return new WaitForSeconds(Delay);
        if (Owner != null)
        {
            if (Owner._UnitData.Prefab_Projectile == null && Owner.IsDeath)
            {
                yield return null;
                yield break;
            }
        }
        if (value.Damage == 0)
        {
            yield return null;
            yield break;
        }

        float damage = value.Damage;
        if (Owner != null) damage *= (1 + (Owner.Stat.Special_DamageIncrease / 100));

        switch (value.Type)
        {
            case DamageType.Physic:
                {
                    damage = Support.Math.Get_DefenseRate(damage, Target.Stat.Defense_Armor - value.Pierce);
                }
                break;
            case DamageType.Magic:
                {
                    damage = Support.Math.Get_DefenseRate(damage, Target.Stat.Defense_Resist - value.Pierce);
                }
                break;
            case DamageType.Pure:
                {
                    damage = Support.Math.Get_DefenseRate(damage, 0);
                }
                break;
        }

        Target.CurrentHp -= damage;
        float add = Target.GetDamage;
        if (Owner != null) Owner.Damage_Deal[(int)value.Type] += add;

        if (!Target.IsDeath)
        {
            // (본인) 맞을 시 본인에게
            if (Target.UnitEffect[(int)EffectTrigger.Hit_Self].Count != 0)
                Target.SetEffect(EffectTrigger.Hit_Self);
        }
        if (Owner != null)
        {
            if (!Owner.IsDeath)
            {
                // (상대) 맞을 시 상대에게
                if (Target.UnitEffect[(int)EffectTrigger.Hit_Other].Count != 0)
                    Owner.Target_Attack.AddEffect(Target.UnitEffect[(int)EffectTrigger.Hit_Other], EffectTrigger.Immediate_Self);
            }
        }

        if (Owner != null) Owner.CurrentHp += (add / 100) * Owner.Stat.Special_Absorb;

        Canvas_Main.instance._Fight._Damage.SetDamageText(Target, add, SaveData.SaveValuePlayer.DamageColor[(int)value.Type], 1f, 1f);

        yield return null;
    }
    protected IEnumerator PlayEffect(EffectDamageOverTime value, Unit Target)
    {
        if (Count <= 0 && !Infinity)
            IsUse = false;

        yield return new WaitForSeconds(Delay);
        
        if (Owner != null)
        {
            if (Owner._UnitData.Prefab_Projectile == null && Owner.IsDeath)
            {
                yield return null;
                yield break;
            }
        }
        if (value.Damage == 0)
        {
            yield return null;
            yield break;
        }

        float damage = value.Damage;
        if (Owner != null) damage *= (1 + (Owner.Stat.Special_DamageIncrease / 100));

        switch (value.Type)
        {
            case DamageType.Physic: { damage = Support.Math.Get_DefenseRate(damage, Target.Stat.Defense_Armor - value.Pierce); } break;
            case DamageType.Magic: { damage = Support.Math.Get_DefenseRate(damage, Target.Stat.Defense_Resist - value.Pierce); } break;
            case DamageType.Pure: { damage = Support.Math.Get_DefenseRate(damage, 0); } break;
        }

        float tickDamage = damage / (value.Time / value.TickDelay);

        for (float i = 0; i < value.Time; i += value.TickDelay)
        {
            if (Target.IsDeath || SaveData.SaveValueGame.Current_FightState != FightState.Fight) break;

            Target.CurrentHp -= tickDamage;
            float add = Target.GetDamage;
            if (Owner != null) Owner.Damage_Deal[(int)value.Type] += add;

            if (Owner != null) Owner.CurrentHp += (add / 100) * Owner.Stat.Special_Absorb;

            Canvas_Main.instance._Fight._Damage.SetDamageText(Target, add, SaveData.SaveValuePlayer.DamageColor[(int)value.Type], 1, 1f);

            yield return new WaitForSeconds(value.TickDelay);
        }

        yield return null;
    }
    protected IEnumerator PlayEffect(EffectAddStatus value, Unit Target)
    {
        if (Count <= 0 && !Infinity)
            IsUse = false;

        yield return new WaitForSeconds(Delay);

        Target.AddStatus_Dynamic.AddStatus(value.Status, true);

        float delay = 0;
        while (value.Time > delay && SaveData.SaveValueGame.Current_GameState == GameState.Fight)
        {
            delay += Time.deltaTime;
            yield return 0;
        }
        
        if (SaveData.SaveValueGame.Current_GameState == GameState.Fight)
            Target.AddStatus_Dynamic.AddStatus(value.Status, false);

        yield return null;
    }
    protected IEnumerator PlayEffect(EffectAddLife value, Unit Target)
    {
        if (Count <= 0 && !Infinity)
            IsUse = false;

        yield return new WaitForSeconds(Delay);

        Target.CurrentHp += value.Hp;
        Target.CurrentShield += value.Shield;
        Target.CurrentMp += value.Mp;

        if (value.Hp != 0)
            Canvas_Main.instance._Fight._Damage.SetDamageText(Target, value.Hp, SaveData.SaveValuePlayer.Life_HpColor, 1, 1);
        else if (value.Shield != 0)
            Canvas_Main.instance._Fight._Damage.SetDamageText(Target, value.Shield, SaveData.SaveValuePlayer.Life_ShieldColor, 1, 1);
        else if (value.Mp != 0)
            Canvas_Main.instance._Fight._Damage.SetDamageText(Target, value.Mp, SaveData.SaveValuePlayer.Life_MpColor, 1, 1);

        yield return null;
    }
    protected IEnumerator PlayEffect(EffectSetLock value, Unit Target)
    {
        if (Count <= 0 && !Infinity)
            IsUse = false;

        yield return new WaitForSeconds(Delay);

        bool attack, skill, move;

        attack = Target.Lock_Attack;
        skill = Target.Lock_Skill;
        move = Target.Lock_Move;

        Target.Lock_Attack = value.IsAttack;
        Target.Lock_Skill = value.IsSkill;
        Target.Lock_Move = value.IsMove;

        yield return new WaitForSeconds(value.Time);

        Target.Lock_Attack = attack;
        Target.Lock_Skill = skill;
        Target.Lock_Move = move;
    }
}
[System.Serializable]
public class EffectDamage : Effect
{
    public DamageType Type;
    public float Damage;
    public float Pierce;

    public EffectDamage(DamageType type, float damage, float pierce)
    {
        Type = type;
        Damage = damage;
        Pierce = pierce;
    }
    public override void Play(Unit Target)
    {
        if (!IsData || !IsUse) return;
        base.Play(Target);

        bool check = true;
        if (IsChance)
            check = UnityEngine.Random.Range(0f, 100f) <= Chance ? true : false;

        if (check)
            CoroutineHandler.Start_Coroutine(PlayEffect(this, Target));
    }
}
public class EffectDamageOverTime : Effect
{
    public DamageType Type;
    public float Damage;
    public float Pierce;
    public float Time;
    public float TickDelay;

    public EffectDamageOverTime(DamageType type, float damage, float pierce, float time, float tickdelay)
    {
        Type = type;
        Damage = damage;
        Pierce = pierce;
        Time = time;
        TickDelay = tickdelay;
    }

    public override void Play(Unit Target)
    {
        if (!IsData || !IsUse) return;
        base.Play(Target);

        bool check = true;
        if (IsChance)
            check = UnityEngine.Random.Range(0f, 100f) <= Chance ? true : false;

        if (check)
            CoroutineHandler.Start_Coroutine(PlayEffect(this, Target));
    }
}
public class EffectAddStatus : Effect
{
    public UnitStatus Status;

    public float Time;

    public EffectAddStatus(UnitStatus status, float time)
    {
        Status = status;
        Time = time;
    }
    public override void Play(Unit Target)
    {
        if (!IsData || !IsUse) return;
        base.Play(Target);

        bool check = true;
        if (IsChance)
            check = UnityEngine.Random.Range(0f, 100f) <= Chance ? true : false;

        if (check)
            CoroutineHandler.Start_Coroutine(PlayEffect(this, Target));
    }
}
public class EffectAddLife : Effect
{
    public float Hp, Shield, Mp;

    public EffectAddLife(float hp, float shield, float mp)
    {
        Hp = hp;
        Shield = shield;
        Mp = mp;
    }
    public override void Play(Unit Target)
    {
        if (!IsData || !IsUse) return;
        base.Play(Target);

        bool check = true;
        if (IsChance)
            check = UnityEngine.Random.Range(0f, 100f) <= Chance ? true : false;

        if (check)
            CoroutineHandler.Start_Coroutine(PlayEffect(this, Target));
    }
}

public class EffectSetLock : Effect
{
    public bool IsAttack, IsSkill, IsMove;
    public float Time;

    public EffectSetLock(bool attack, bool skill, bool move, float time)
    {
        IsAttack = attack;
        IsSkill = skill;
        IsMove = move;

        Time = time;
    }
    public override void Play(Unit Target)
    {
        if (!IsData || !IsUse) return;
        base.Play(Target);

        bool check = true;
        if (IsChance)
            check = UnityEngine.Random.Range(0f, 100f) <= Chance ? true : false;

        if (check)
            CoroutineHandler.Start_Coroutine(PlayEffect(this, Target));
    }
}