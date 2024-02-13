using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Unit_MoveState : IState
{
    private Unit Owner;

    float MoveDelay;
    bool sub;
    int count;

    public Unit_MoveState(Unit unit)
    {
        Owner = unit;
    }

    public void Enter()
    {
        Owner.SetAnimator(Unit.State.Move);
        sub = (Random.Range(0, 2) == 1) ? true : false;
        count = 0;
    }
    public void Stay()
    {
        if (Owner.state != Unit.State.Move) return;
        MoveDelay -= Time.deltaTime;

        if (Owner.Target_Attack == null || Owner.Target_Attack.IsDeath)
        {
            Owner.state = Unit.State.Idle;
            return;
        }
        else if (MoveDelay <= 0 && !Owner.Lock_Move)
        {
            int distance = Support.Math.Get_Distance(Owner.transform.position, Owner.Target_Attack.transform.position);
            if (count > 8)
            {
                count = 0;
                Owner.Target_Attack = null;
                return;
            }
            if (distance > Owner.Stat.Attack_Range)
            {
                int dir = Support.Math.Get_MoveDirection_int(Owner.transform.position, Owner.Target_Attack.transform.position);
                bool check = false;
                for (int i = 0; i < 8; i++)
                {
                    Vector3 moveDir = Owner.transform.position + Support.Vector.Get_MoveDirection((MoveDirection)dir);

                    TileData tile = MapManager.instance.Get_Tile(moveDir);

                    if (tile != null)
                    {
                        if (tile.Unit_Object == null)
                        {
                            float delay = 1 / Owner.Stat.Special_MoveSpeed;
                            // 이동 가능
                            MapManager.instance.SetTileUnit(Owner.transform.position, null);
                            MapManager.instance.SetTileUnit(moveDir, Owner);

                            Owner.transform.DOKill();
                            Owner.transform.DOLookAt(moveDir, 0.2f);
                            Owner.transform.DOMove(moveDir, delay);

                            MoveDelay = delay;
                            check = true;

                            break;
                        }
                    }

                    if (sub)
                        dir = (dir + 1) % 8;
                    else
                        dir = dir - 1 < 0 ? dir = 7 : dir -= 1;
                }

                // 이펙트 실행
                if (Owner.UnitEffect[(int)EffectTrigger.Move_Self].Count != 0)
                    Owner.SetEffect(EffectTrigger.Move_Self);

                if (check)
                    count += 1;
                else
                    Owner.Target_Attack = null;
            }
            else
            {
                Owner.state = Unit.State.Attack;
            }
        }
    }

    public void Exit()
    {
        Owner.SetAnimator(Unit.State.Idle);
    }

    public void Set()
    {
    }
}
