using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;
using System.Linq;

public class EventSetting : MonoBehaviour
{
    public void SetEvent(EventData data, int value, int rand)
    {
        // data.Id = 이벤트 아이디
        // value = 누른 선택지
        // rand = 선택의 결과

        string endText = "";
        Color endCOlor = Color.white;
        bool setEvent = true;

        switch (data.Id)
        {
            case 0:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                switch (rand)
                                {
                                    case 0:
                                        {
                                            endText = SaveData.LanguageData.Event_00[0, SaveData.SaveValuePlayer.LanguageValue];
                                            endCOlor = SaveData.ColorData.Green_Light;
                                            
                                            PlayerManager.instance.AddItem(10);
                                        }
                                        break;
                                    case 1:
                                        {
                                            endText = SaveData.LanguageData.Event_00[2, SaveData.SaveValuePlayer.LanguageValue];
                                            endCOlor = SaveData.ColorData.Red_Light;

                                            if (UnitManager.instance.Units_Player.Count != 0)
                                                UnitManager.instance.Units_Player[Random.Range(0, UnitManager.instance.Units_Player.Count)].Exit();
                                        }
                                        break;
                                    default: break;
                                }
                            } break;
                        case 1:
                            {
                                switch (rand)
                                {
                                    case 0:
                                        {
                                            endText = SaveData.LanguageData.Event_00[1, SaveData.SaveValuePlayer.LanguageValue];
                                            endCOlor = SaveData.ColorData.Green_Light;
                                            
                                            PlayerManager.instance.AddItem(11);
                                        }
                                        break;
                                    case 1:
                                        {
                                            endText = SaveData.LanguageData.Event_00[2, SaveData.SaveValuePlayer.LanguageValue];
                                            endCOlor = SaveData.ColorData.Red_Light;
                                            
                                            if (UnitManager.instance.Units_Player.Count != 0)
                                                UnitManager.instance.Units_Player[Random.Range(0, UnitManager.instance.Units_Player.Count)].Exit();
                                        }
                                        break;
                                    default: break;
                                }
                            } break;
                        default: break;
                    }

                } break;
            case 1:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                if (SaveValueGame.Gold >= 300)
                                {
                                    SaveValueGame.Gold -= 300;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[2, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[4, SaveValuePlayer.LanguageValue], null);
                                    for (int i = 0; i < 3; i++)
                                    {
                                        PlayerManager.instance.AddItem(Random.Range(100, 107));
                                    }
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[3, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[5, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        case 1:
                            {
                                if (SaveValueGame.Gold >= 200)
                                {
                                    SaveValueGame.Gold -= 200;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[1, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[4, SaveValuePlayer.LanguageValue], null);
                                    for (int i = 0; i < 2; i++)
                                    {
                                        PlayerManager.instance.AddItem(Random.Range(100, 107));
                                    }
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[3, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[5, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        case 2:
                            {
                                if (SaveValueGame.Gold >= 100)
                                {
                                    SaveValueGame.Gold -= 100;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[0, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[4, SaveValuePlayer.LanguageValue], null);
                                    
                                    PlayerManager.instance.AddItem(Random.Range(100, 107));
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_01[3, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_01[5, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        default: break;
                    }
                } break;
            case 2:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                setEvent = false;
                                
                                float result = Random.Range(0f, 100f);
                                if (result > 100f - 10f)
                                {
                                    int currentGold = SaveValueGame.Gold;
                                    SaveValueGame.Gold = currentGold * 10;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[0, SaveValuePlayer.LanguageValue] + " x10 (" + ((currentGold *10) - currentGold) + ")";
                                    endCOlor = ColorData.Green_Light;
                                    
                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[2, SaveValuePlayer.LanguageValue], null);
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[1, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[3, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        case 1:
                            {
                                setEvent = false;
                                
                                float result = Random.Range(0f, 100f);
                                if (result > 100f - 18f)
                                {
                                    int currentGold = SaveValueGame.Gold;
                                    
                                    SaveValueGame.Gold = currentGold * 5;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[0, SaveValuePlayer.LanguageValue] + " x5 (" + ((currentGold * 5) - currentGold) + ")";
                                    endCOlor = ColorData.Green_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[2, SaveValuePlayer.LanguageValue], null);
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[1, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[3, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        case 2:
                            {
                                setEvent = false;
                                
                                float result = Random.Range(0f, 100f);
                                if (result > 100f - 40f)
                                {
                                    int currentGold = SaveValueGame.Gold;
                                    
                                    SaveValueGame.Gold = currentGold * 2;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[0, SaveValuePlayer.LanguageValue] + " x2 (" + ((currentGold * 2) - currentGold) + ")";
                                    endCOlor = ColorData.Green_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[2, SaveValuePlayer.LanguageValue], null);
                                }
                                else
                                {
                                    SaveValueGame.Gold = 0;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    endText = LanguageData.Event_02[1, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Red_Light;

                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_02[3, SaveValuePlayer.LanguageValue], null);
                                }
                            } break;
                        default: break;
                    }
                } break;
            case 3:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                int count = Random.Range(2, 7);

                                for (int i = 0; i < count; i++)
                                {
                                    int herb = Random.Range(12, 19);
                                    PlayerManager.instance.AddItem(herb);
                                }

                                endText = LanguageData.Event_03[0, SaveValuePlayer.LanguageValue] + $" + {count}";
                                endCOlor = ColorData.Green_Light;
                            } break;
                        default: break;
                    }
                }break;
            case 4:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                PlayerManager.instance.AddItem(19);

                                endText = LanguageData.Event_04[0, SaveValuePlayer.LanguageValue];
                                endCOlor = ColorData.Yellow_Light;
                            }
                            break;
                        default: break;
                    }
                } break;
            case 5:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                switch (rand)
                                {
                                    case 0:
                                        {
                                            int get = Random.Range(0, 3);

                                            switch (get)
                                            {
                                                case 0:
                                                    {
                                                        int coin = Random.Range(50, 201);
                                                        SaveValueGame.Gold += coin;
                                                        Canvas_Main.instance._UI_TopCategory.SetGold();
                                                        
                                                        endText = LanguageData.Event_05[get, SaveValuePlayer.LanguageValue] + " + " + coin;
                                                    } break;
                                                case 1:
                                                    {
                                                        int count = Random.Range(1, 5);

                                                        for (int i = 0; i < count; i++)
                                                        {
                                                            int herb = Random.Range(12, 19);
                                                            PlayerManager.instance.AddItem(herb);
                                                        }
                                                        
                                                        endText = LanguageData.Event_05[get, SaveValuePlayer.LanguageValue] + " + " + count;
                                                    } break;
                                                case 2:
                                                    {
                                                        int item = Random.Range(0, 10);
                                                        PlayerManager.instance.AddItem(item);
                                                        
                                                        endText = LanguageData.Event_05[get, SaveValuePlayer.LanguageValue];
                                                    }
                                                    break;
                                                default: break;
                                            }

                                            endCOlor = ColorData.Green_Light;
                                        }
                                        break;
                                    case 1:
                                        {
                                            endText = LanguageData.Event_05[3, SaveValuePlayer.LanguageValue];
                                            endCOlor = ColorData.Red_Light;

                                            if (UnitManager.instance.Units_Player.Count != 0)
                                                UnitManager.instance.Units_Player[Random.Range(0, UnitManager.instance.Units_Player.Count)].Exit();
                                        }
                                        break;
                                    default: break;
                                }
                            }
                            break;
                        default: break;
                    }
                } break;
            case 6:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                if (SaveValueGame.Gold >= 500)
                                {
                                    SaveValueGame.Gold -= 500;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    float Sale = 20;
                                    PlayerManager.instance.Shop_Sale += Sale;

                                    endText = Sale + " " + LanguageData.Event_06[0, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;
                                }
                                else
                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_06[1, SaveValuePlayer.LanguageValue], null);
                            } break;
                        case 1:
                            {
                                if (SaveValueGame.Gold >= 300)
                                {
                                    SaveValueGame.Gold -= 300;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    float Sale = 10;
                                    PlayerManager.instance.Shop_Sale += Sale;

                                    endText = Sale + " " + LanguageData.Event_06[0, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;
                                }
                                else
                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_06[1, SaveValuePlayer.LanguageValue], null);
                            } break;
                        case 2:
                            {
                                if (SaveValueGame.Gold >= 100)
                                {
                                    SaveValueGame.Gold -= 100;
                                    Canvas_Main.instance._UI_TopCategory.SetGold();

                                    float Sale = 2;
                                    PlayerManager.instance.Shop_Sale += Sale;

                                    endText = Sale + " " + LanguageData.Event_06[0, SaveValuePlayer.LanguageValue];
                                    endCOlor = ColorData.Green_Light;
                                }
                                else
                                    Canvas_Main.instance._Event.SetValue(null, null, LanguageData.Event_06[1, SaveValuePlayer.LanguageValue], null);
                            } break;
                        default: break;
                    }
                } break;
            case 7:
                {
                    switch (value)
                    {
                        case 0:
                            {
                                List<Unit> units = UnitManager.instance.Units_Player.ToList();

                                while (units.Count > 2)
                                {
                                    int random = Random.Range(0, units.Count);
                                    units[random].AddStatus_Static.Attack_Physic += units[random]._UnitData.Status.Attack_Physic;
                                    units.RemoveAt(random);
                                }
                                for (int i = 0; i < units.Count; i++)
                                {
                                    units[i].Exit();
                                }

                            } break;
                            
                        case 1:
                            {
                                List<Unit> units = UnitManager.instance.Units_Player.ToList();

                                while (units.Count > 2)
                                {
                                    int random = Random.Range(0, units.Count);
                                    units[random].AddStatus_Static.Attack_Magic += units[random]._UnitData.Status.Attack_Magic;
                                    units.RemoveAt(random);
                                }

                                for (int i = 0; i < units.Count; i++)
                                {
                                    units[i].Exit();
                                }

                            } break;
                        default: break;
                    }
                } break;
            default: break;
        }
        
        // True로 만들어서 중복으로 나오지 않게 하는 용도
        Canvas_Main.instance._Event._EventCheck.SetEvent(data.Id, setEvent);
        // 결과창 텍스트 수정
        Canvas_Main.instance._Event.SetValue(null, null, null, endText);
        Canvas_Main.instance._Event.Text_End.color = endCOlor;
    }
}