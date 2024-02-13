using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_Result : IState
{
    private PlayerManager Owner;

    public PlayerManager_Result(PlayerManager manager)
    {
        Owner = manager;
    }

    public void Enter()
    {
        Canvas_Main.instance._Fight._Reward.SetReward(UnitManager.instance.Units_AllPlayer);
    }
    public void Stay()
    {
    }

    public void Exit()
    {
        UnitManager.instance.Fight_Reward();
    }

    public void Set()
    {
    }
}
