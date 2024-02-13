using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_Wait : IState
{
    private PlayerManager Owner;

    public PlayerManager_Wait(PlayerManager manager)
    {
        Owner = manager;
    }

    public void Enter()
    {
        Owner.EnterUnit(null);
        Owner.EnterTile(null);
        // 버튼 생성
        Canvas_Main.instance._Fight._Game.SetActivePlayButton(true);
    }
    public void Stay()
    {
        if (Owner.CurrentInventoryItem == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Owner.EnterTile(Support.Mouse.GetMouse_PointToLayer("Tile"));

                // Owner.PrevTileData == null
                // Owner.PrevTileData != null && Owner.PrevTileData.Unit_Object._Faction == Faction.Enamy
                // Owner.CurrentTileData != null && Owner.CurrentTileData.Unit_Object._Faction == Faction.Enamy
                

                if (Owner.PrevTileData != null)
                {
                    bool check = true;
                    
                    if (Owner.PrevTileData.Unit_Object == null)
                        check = false;
                    else
                    {
                        if (Owner.PrevTileData.Unit_Object._Faction == Faction.Enamy)
                            check = false;

                        if (Owner.CurrentTileData == null)
                            check = false;
                        else
                        {
                            if (Owner.CurrentTileData.Unit_Object != null)
                            {
                                if (Owner.CurrentTileData.Unit_Object._Faction == Faction.Enamy)
                                    check = false;
                            }
                        }
                    }

                    if (check)
                    {
                        Owner.ChangeTileUnit(Owner.CurrentTileData, Owner.PrevTileData);
                        CoroutineSound.Start_Coroutine(Owner.Clip_UnitChange, SaveData.SaveValuePlayer.Volume_Effect);
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
                Owner.EnterTile(null);
        }
        else
        {
            // 사용
            if (Input.GetMouseButtonDown(0))
            {
                bool OnUse = false;

                switch (Owner.CurrentInventoryItem._ItemData.Tag)
                {
                    case ItemTag.Item:
                        {
                            if (Owner.CurrentUnit != null)
                            {
                                if (Owner.CurrentUnit._Faction == Owner.CurrentInventoryItem._ItemData.UseFaction)
                                {
                                    OnUse = true;
                                    Item.SetItem(Owner.CurrentUnit, Owner.CurrentInventoryItem._ItemData);
                                    
                                    Canvas_Main.instance._GameOver.Data_info[4] += 1;
                                    CoroutineSound.Start_Coroutine(Owner.Clip_UseItem, SaveData.SaveValuePlayer.Volume_Effect);
                                }
                            }
                        }
                        break;
                    case ItemTag.Unit:
                        {
                            if (Owner.CurrentTileData != null)
                            {
                                if (Owner.CurrentTileData.Unit_Object == null)
                                {
                                    OnUse = UnitManager.instance.CreateUnit(Owner.CurrentTileData.transform.position, Faction.Player, Owner.CurrentInventoryItem._ItemData.Unit_Value);
                                    CoroutineSound.Start_Coroutine(Owner.Clip_UseItem, SaveData.SaveValuePlayer.Volume_Effect);
                                }
                            }
                        }
                        break;
                    default: break;
                }

                if (OnUse)
                    Owner.OffInventoryItem(true);
                else
                    Owner.OffInventoryItem(false, false);
            }
            // 선택 취소    
            if (Input.GetMouseButtonDown(1))
                Owner.OffInventoryItem(false);
        }
    }

    public void Exit()
    {
        Owner.EnterTile(null);
        Owner.EnterUnit(null);
        Owner.CurrentInventoryItem = null;

        foreach (var unit in UnitManager.instance.Units_AllPlayer)
        {
            unit.StartPos = unit.transform.position;
        }
        // 버튼 제거
        Canvas_Main.instance._Fight._Game.SetActivePlayButton(false);
    }

    public void Set()
    {
    }
}
