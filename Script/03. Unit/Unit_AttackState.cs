using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit_AttackState : IState
{
    private Unit Owner;
    
    public float AttackDelay = 0.2f;

    public Unit_AttackState(Unit unit)
    {
        Owner = unit;
    }

    public void Enter()
    {
        Owner.transform.DOLookAt(Owner.Target_Attack.transform.position, 0.2f);
        Owner._Animator.SetBool("IsAttack", true);
    }
    public void Stay()
    {
        if (Owner.state != Unit.State.Attack) return;
        if (Owner.Target_Attack == null || Owner.Target_Attack.IsDeath)
        {
            Owner.state = Unit.State.Idle;
            return;
        }

        int distance = Support.Math.Get_Distance(Owner.transform.position, Owner.Target_Attack.transform.position);

        if (distance > Owner.Stat.Attack_Range)
            Owner.state = Unit.State.Move;
        else if (AttackDelay <= 0 && !Owner.Lock_Attack)
        {
            float delay = 1 / Owner.Stat.Attack_Speed;
            Owner.transform.DOLookAt(Owner.Target_Attack.transform.position, 0.2f);

            if (Owner.Stat.Attack_Speed < 1.5f)
                Owner._Animator.SetFloat("AttackSpeed", 1.5f);
            else
                Owner._Animator.SetFloat("AttackSpeed", Owner.Stat.Attack_Speed * 1.5f);

            Owner.SetAnimator(Unit.State.Attack);

            if (Random.Range(0f, 100f) > Owner.Stat.Special_MissRate ? true : false)
            {
                // 크리체크
                bool cri_Chance = Random.Range(0f, 100f) < Owner.Stat.Attack_CriticalChance ? true : false;
                float damage = cri_Chance ? Owner.Stat.Attack_Physic * (Owner.Stat.Attack_CriticalDamage / 100) : Owner.Stat.Attack_Physic;

                float attackDelay = Owner._UnitData.Prefab_Projectile == null ? delay * Owner._UnitData.Projectile_StartDelay : Owner._UnitData.Projectile_Speed + (delay * Owner._UnitData.Projectile_StartDelay);
                EffectDamage ef_damage = new EffectDamage(DamageType.Physic, damage, Owner.Stat.Attack_PhysicPiercing);
                ef_damage.setting(Owner, attackDelay, 1);
                Owner.Target_Attack.AddEffect(ef_damage, EffectTrigger.Immediate_Self);

                if (Owner._UnitData.Prefab_Projectile != null)
                    Support.Unit.AttackProjectile(Owner.Projectile_Start.transform.position, Owner.Target_Attack.transform.position, Owner._UnitData.Prefab_Projectile, Owner._UnitData.Projectile_Power, attackDelay, delay * Owner._UnitData.Projectile_StartDelay);

                // 이펙트 실행
                // (본인)
                if (Owner.UnitEffect[(int)EffectTrigger.Attack_Self].Count != 0)
                    Owner.SetEffect(EffectTrigger.Attack_Self);
                // (상대)
                if (Owner.UnitEffect[(int)EffectTrigger.Attack_Other].Count != 0)
                    Owner.Target_Attack.AddEffect(Owner.UnitEffect[(int)EffectTrigger.Attack_Other], EffectTrigger.Immediate_Self);

                Owner.Target_Attack.CurrentMp += 2;
                Owner.CurrentMp += 10;
                
                CoroutineSound.Start_Coroutine(Owner._UnitData.Sound.Clip_Attack, SaveData.SaveValuePlayer.Volume_Effect, delay * Owner._UnitData.Projectile_StartDelay);
                CoroutineSound.Start_Coroutine(Owner._UnitData.Sound.Clip_Damage, SaveData.SaveValuePlayer.Volume_Effect, attackDelay);
            }
            else
                Canvas_Main.instance._Fight._Damage.SetDamageText(Owner, "Miss", SaveData.ColorData.Magenta_Dark, 1f, 1f);

            AttackDelay = delay;
        }
        else
            AttackDelay -= Time.deltaTime;
    }

    public void Exit()
    {
        Owner._Animator.SetBool("IsAttack", false);
    }

    public void Set()
    {
        AttackDelay = 0.2f;
    }
}
