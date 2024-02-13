using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_SkillState : IState
{
    private Unit Owner;

    float StartDelay;
    float EndDelay;

    bool IsSkill;

    public Unit_SkillState(Unit unit)
    {
        Owner = unit;
    }

    public void Enter()
    {
        Owner.CurrentMp = 0;

        if (Owner._SkillData == null)
        {
            Owner.state = Unit.State.Idle;
            return;
        }

        Owner.SetAnimator(Unit.State.Skill);

        IsSkill = false;
        StartDelay = Owner._SkillData.StartDelay;
        EndDelay = Owner._SkillData.EndDelay;
    }
    public void Stay()
    {
        if (!IsSkill)
            StartDelay -= Time.deltaTime;
        else
            EndDelay -= Time.deltaTime;

        if (StartDelay <= 0 && !IsSkill)
        {
            Skill.SetSkill(Owner._SkillData, Owner);

            // ÀÌÆåÆ® ½ÇÇà
            if (Owner.UnitEffect[(int)EffectTrigger.Skill_Self].Count != 0)
                Owner.SetEffect(EffectTrigger.Immediate_Self);

            IsSkill = true;
        }

        if (EndDelay <= 0 && IsSkill)
        {
            if (Owner.Target_Attack == null)
                Owner.state = Unit.State.Idle;
            else
                Owner.state = Unit.State.Attack;
        }
    }

    public void Exit()
    {
    }

    public void Set()
    {
    }
}
