using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_IdleState : IState
{
    private Unit Owner;

    public Unit_IdleState(Unit unit)
    {
        Owner = unit;
    }

    public void Enter()
    {
        Owner.SetAnimator(Unit.State.Idle);
    }
    public void Stay()
    {
        if (Owner.state != Unit.State.Idle) return;
        if (Owner.Target_Attack == null || Owner.Target_Attack.IsDeath)
        {
            Owner.Target_Attack = null;
            Owner.GetAttackTarget();
        }

        if (Owner.Target_Attack != null)
            Owner.state = Unit.State.Attack;
    }

    public void Exit()
    {
    }

    public void Set()
    {
    }
}
