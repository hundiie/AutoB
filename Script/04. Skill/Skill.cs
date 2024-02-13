using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Skill : MonoBehaviour
{
    public static void SetSkill(int id, Unit owner)
    {
        SkillData data = ResourcesData.Get_SkillData(id);

        if (data != null) SetSkill(data, owner);
    }
    public static void SetSkill(SkillData data, Unit owner)
    {
        switch (data.Id)
        {
            case 1: Skill_01(data, owner); break;   // 보호막
            case 2: Skill_02(data, owner); break;   // 박살
            case 3: Skill_03(data, owner); break;   // 방어 자세
            case 4: Skill_04(data, owner); break;   // 독 화살
            case 5: Skill_05(data, owner); break;   // 다중 공격
            case 6: Skill_06(data, owner); break;   // 속사
            case 7: Skill_07(data, owner); break;   // 저격
            case 8: Skill_08(data, owner); break;   // 폭발 화살
            case 9: Skill_09(data, owner); break;   // 기절 화살
            case 10: Skill_10(data, owner); break;  // 담금질
            case 11: Skill_11(data, owner); break;  // 용기의 함성
            case 12: Skill_12(data, owner); break;  // 도발
            default: break;
        }
    }

    public static void TestSkill_01(SkillData data, Unit owner)  // 본인에게 보호막
    {
        EffectAddLife ef = new EffectAddLife(0, 100 * (1 + (owner.Stat.Attack_Magic / 100)), 0);
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Immediate_Self);
    }
    public static void TestSkill_02(SkillData data, Unit owner)  // 다음 평타 독 데미지
    {
        EffectDamageOverTime ef = new EffectDamageOverTime(DamageType.Magic, 100 * (1 + (owner.Stat.Attack_Magic / 100)), owner.Stat.Attack_MagicPiercing, 10, 0.2f);
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Attack_Other);
    }
    public static void TestSkill_03(SkillData data, Unit owner)  // 대상에게 강한 데미지
    {
        Unit target = data != null ? UnitManager.instance.GetTarget(owner, TargetFaction.Enemies, TargetMode.Random)[0] : null;
        if (target == null) return;

        EffectDamage ef = new EffectDamage(DamageType.Magic, 100 * (1 + (owner.Stat.Attack_Magic / 100)), owner.Stat.Attack_MagicPiercing);
        ef.setting(owner, 0, 1);
        target.AddEffect(ef, EffectTrigger.Immediate_Self);
    }
    public static void TestSkill_04(SkillData data, Unit owner)  // 대상에게 스텟 디버프
    {
        Unit target = data != null ? UnitManager.instance.GetTarget(owner, TargetFaction.Allies, TargetMode.MostNear)[0] : null;
        if (target == null) return;

        UnitStatus status = new UnitStatus();
        status.Attack_Physic += 20;
        // 지속 시간
        EffectAddStatus ef = new EffectAddStatus(status, 10);
        ef.setting(null, 0, 1);
        target.AddEffect(ef, EffectTrigger.Immediate_Self);
    }

    public static void Skill_01(SkillData data, Unit owner)
    {
        EffectAddLife ef = new EffectAddLife(0, data.Values[0] * (owner.Stat.Attack_Magic / 100), 0);
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Immediate_Self);

        CoroutineVFX.Start_Coroutine(owner, owner._SkillData.FX, true, true);
    }
    public static void Skill_02(SkillData data, Unit owner)
    {
        UnitStatus status = new UnitStatus();
        status.Defense_Armor -= data.Values[1] * (owner.Stat.Attack_Magic / 100);

        EffectAddStatus ef = new EffectAddStatus(status, data.Values[0] * (owner.Stat.Attack_Magic / 100));
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Attack_Other);

        CoroutineVFX.Start_Coroutine(owner, data.FX, true, true);
    }
    public static void Skill_03(SkillData data, Unit owner)
    {
        UnitStatus status = new UnitStatus();
        status.Special_DamageReduction += data.Values[1] * (owner.Stat.Attack_Magic / 100);

        EffectAddStatus ef = new EffectAddStatus(status, data.Values[0] * (owner.Stat.Attack_Magic / 100));
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Immediate_Self);

        CoroutineVFX.Start_Coroutine(owner, owner._SkillData.FX, true, true);
    }
    public static void Skill_04(SkillData data, Unit owner)
    {
        EffectDamageOverTime ef = new EffectDamageOverTime(DamageType.Magic, data.Values[0] * (owner.Stat.Attack_Magic / 100), owner.Stat.Attack_MagicPiercing, 7, 0.5f);
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Attack_Other);
    }
    public static void Skill_05(SkillData data, Unit owner)
    {
        List<Unit> units = UnitManager.instance.Units_Enamy.ToList();

        while (units.Count > 3)
        {
            units.RemoveAt(Random.Range(0, units.Count));
        }

        for (int i = 0; i < units.Count; i++)
        {
            EffectDamage ef = new EffectDamage(DamageType.Physic, data.Values[0] * (owner.Stat.Attack_Magic / 100), owner.Stat.Attack_PhysicPiercing);
            ef.setting(owner, 0.5f, 1);
            units[i].AddEffect(ef, EffectTrigger.Immediate_Self);

            owner.transform.DOLookAt(units[i].transform.position, 0.1f);
            Support.Unit.AttackProjectile(owner.Projectile_Start.transform.position, units[i].transform.position, data.Prefab[0], 0.3f, 0.5f);
        }
    }
    public static void Skill_06(SkillData data, Unit owner)
    {
        UnitStatus status = new UnitStatus();
        status.Attack_Speed += ((owner._UnitData.Status.Attack_Speed + owner.AddStatus_Static.Attack_Speed) / 100f) * (data.Values[1] * (owner.Stat.Attack_Magic / 100));

        EffectAddStatus ef = new EffectAddStatus(status, data.Values[0] * (owner.Stat.Attack_Magic / 100));
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Immediate_Self);
    }
    public static void Skill_07(SkillData data, Unit owner)
    {
        List<Unit> units = UnitManager.instance.GetTarget(owner, TargetFaction.Enemies, TargetMode.MostFar);
        if (units.Count == 0) return;

        EffectDamage ef = new EffectDamage(DamageType.Physic, data.Values[0] * (owner.Stat.Attack_Magic / 100), owner.Stat.Attack_PhysicPiercing);
        ef.setting(owner, 0.3f, 1);
        units[0].AddEffect(ef, EffectTrigger.Immediate_Self);

        owner.transform.DOLookAt(units[0].transform.position, 0.1f);
        Support.Unit.AttackProjectile(owner.Projectile_Start.transform.position, units[0].transform.position, data.Prefab[0], 0, 0.3f);
        owner.SetAnimator(Unit.State.Attack);
    }
    public static void Skill_08(SkillData data, Unit owner)
    {
        List<Unit> targets = UnitManager.instance.GetTarget(owner, TargetFaction.Enemies, TargetMode.MostNear);
        if (targets.Count == 0) return;

        Unit target = targets[0];

        float damage = data.Values[0] * (owner.Stat.Attack_Magic / 100);

        EffectDamage ef = new EffectDamage(DamageType.Physic, damage, owner.Stat.Attack_PhysicPiercing);
        ef.setting(owner, 0.7f, 1);
        target.AddEffect(ef, EffectTrigger.Immediate_Self);

        owner.transform.DOLookAt(target.transform.position, 0.1f);
        Support.Unit.AttackProjectile(owner.Projectile_Start.transform.position, target.transform.position, data.Prefab[0], 0f, 0.7f);

        List<Unit> units = UnitManager.instance.GetRangeTarget(target, 1f);
        units.Remove(target);

        for (int i = 0; i < units.Count; i++)
        {
            if (units[i] == null || owner == null)
                continue;
            
            if (units[i]._Faction != owner._Faction)
            {
                EffectDamage nef = new EffectDamage(DamageType.Physic, damage * 0.5f, owner.Stat.Attack_PhysicPiercing);
                nef.setting(owner, 0.7f, 1);
                units[i].AddEffect(nef, EffectTrigger.Immediate_Self);
            }
        }
        owner.SetAnimator(Unit.State.Attack);
    }
    public static void Skill_09(SkillData data, Unit owner)
    {
        List<Unit> targets = UnitManager.instance.GetTarget(owner, TargetFaction.Enemies, TargetMode.MostNear);
        if (targets.Count == 0) return;

        Unit target = targets[0];

        EffectSetLock ef = new EffectSetLock(true, true, true, data.Values[0] * (owner.Stat.Attack_Magic / 100));
        ef.setting(owner, 0.4f, 1);
        target.AddEffect(ef, EffectTrigger.Immediate_Self);

        EffectDamage ef2 = new EffectDamage(DamageType.Physic, data.Values[1] * (owner.Stat.Attack_Magic / 100), owner.Stat.Attack_PhysicPiercing);
        ef2.setting(owner, 0.4f, 1);
        target.AddEffect(ef2, EffectTrigger.Immediate_Self);

        owner.transform.DOLookAt(target.transform.position, 0.1f);
        Support.Unit.AttackProjectile(owner.Projectile_Start.transform.position, target.transform.position, data.Prefab[0], 0f, 0.4f);
        owner.SetAnimator(Unit.State.Attack);
    }

    public static void Skill_10(SkillData data, Unit owner)
    {
        UnitStatus status = new UnitStatus();
        float val = data.Values[0] * (owner.Stat.Attack_Magic / 100);
        status.Defense_Armor += val;
        status.Defense_Resist += val;

        EffectAddStatus ef = new EffectAddStatus(status, 0);
        ef.setting(null, 0, 0, 50);
        owner.AddEffect(ef, EffectTrigger.Hit_Self);

        EffectAddLife ef2 = new EffectAddLife(data.Values[1] * (owner.Stat.Attack_Magic / 100), 0, 0);
        ef2.setting(owner, 0, 0, 50);
        owner.AddEffect(ef2, EffectTrigger.Hit_Self);
    }
    public static void Skill_11(SkillData data, Unit owner)
    {
        List<Unit> units = UnitManager.instance.GetRangeTarget(owner, 1f);

        for (int i = 0; i < units.Count; i++)
        {
            if (units[i]._Faction == owner._Faction)
            {
                UnitStatus status = new UnitStatus();
                status.Special_DamageReduction += data.Values[1] * (owner.Stat.Attack_Magic / 100);

                EffectAddStatus ef = new EffectAddStatus(status, data.Values[0] * (owner.Stat.Attack_Magic / 100));
                ef.setting(owner, 0, 1);
                units[i].AddEffect(ef, EffectTrigger.Immediate_Self);
            }
        }
    }
    public static void Skill_12(SkillData data, Unit owner)
    {
        UnitStatus status = new UnitStatus();
        float val = data.Values[1] * (owner.Stat.Attack_Magic / 100);
        status.Defense_Armor += val;
        status.Defense_Resist += val;

        EffectAddStatus ef = new EffectAddStatus(status, data.Values[0] * (owner.Stat.Attack_Magic / 100));
        ef.setting(owner, 0, 1);
        owner.AddEffect(ef, EffectTrigger.Immediate_Self);
        
        List<Unit> units = UnitManager.instance.GetRangeTarget(owner, 2f);

        for (int i = 0; i < units.Count; i++)
        {
            if (units[i]._Faction != owner._Faction)
                units[i].Target_Attack = owner;
        }
    }

    public static void Skill_13(SkillData data, Unit owner)
    {

    }
    public static void Skill_14(SkillData data, Unit owner)
    {

    }
    public static void Skill_15(SkillData data, Unit owner)
    {

    }
}
