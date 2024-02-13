using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_DeathState : IState
{
    private Unit Owner;
    
    private float DeathDelay;

    public Unit_DeathState(Unit unit)
    {
        Owner = unit;
    }

    public void Enter()
    {
        Owner.SetAnimator(Unit.State.Death);
        DeathDelay = 2f;

        Owner.Target_Attack = null;
        Owner.Target_Skill = null;

        // ¿Ã∆Â∆Æ Ω««‡
        if (Owner.UnitEffect[(int)EffectTrigger.Death_Self].Count != 0)
            Owner.SetEffect(EffectTrigger.Death_Self);

        if (Owner.CurrentHp <= 0)
        {
            Owner.IsDeath = true;
            MapManager.instance.SetTileUnit(Owner.transform.position, null);
        }
        else
            Owner.state = Unit.State.Idle;
    }
    public void Stay()
    {
        DeathDelay -= Time.deltaTime;
        if (DeathDelay < 0 && Owner.gameObject.activeSelf)
        {
            UnitManager.instance.Remove_FactionUnit(Owner);
            Owner.gameObject.SetActive(false);
        }
    }

    public void Exit()
    {
    }

    public void Set()
    {
    }
}
