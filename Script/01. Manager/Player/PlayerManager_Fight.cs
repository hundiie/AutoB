using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_Fight : IState
{
    private PlayerManager Owner;

    public PlayerManager_Fight(PlayerManager manager)
    {
        Owner = manager;
    }

    public void Enter()
    {
        Owner.EnterUnit(null);
    }
    public void Stay()
    {
        if (UnitManager.instance.Units_Player.Count == 0 || UnitManager.instance.Units_Enamy.Count == 0)
        {
            // 패배
            if (UnitManager.instance.Units_Player.Count == 0)
            {
                SaveData.SaveValueGame.Current_GameState = GameState.Gameover;
            }
            // 승리
            else
            {
                SaveData.SaveValueGame.Current_FightState = FightState.Result;
                CoroutineSound.Start_Coroutine(Owner.Clip_Result, SaveData.SaveValuePlayer.Volume_Effect);
            }

            return;
        }

        if (!Owner.OnCharacterSkill)
        {
            if (Input.GetMouseButtonDown(0))
                Owner.EnterUnit(Support.Mouse.GetMouse_PointToLayer("Unit"));
            if (Input.GetMouseButtonDown(1))
                Owner.EnterUnit(null);
        }
        // 캐릭터 스킬
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Skill_Character.SetSkill(Owner.OnCharacterSkill_Id, Owner.CurrentUnit);

                Owner.OnCharacterSkill = false;
                Owner.UpdateMode[0] = false;
                Owner.EnterUnit(null);
            }
            if (Input.GetMouseButtonDown(1))
            {
                Owner.OnCharacterSkill = false;
                Owner.UpdateMode[0] = false;
                Owner.EnterUnit(null);

                Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, "", SaveData.ColorData.BlueSky, 0.2f);
            }
        }
    }

    public void Exit()
    {
    }

    public void Set()
    {
    }
}
