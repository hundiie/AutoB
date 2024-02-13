using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;

public enum GameState
{
    Stage,
    Fight,
    Shop,
    Rest,
    Event,
    Gameover,
}

public enum FightState
{
    Wait,
    Fight,
    Result
}

public enum DamageType
{
    Physic,
    Magic,
    Pure
}

public class GameManager : MonoBehaviour
{
    public static void Init()
    {
        // 세팅 초기화
        SaveValueSetting.Init();
        SaveValueOutPlayer.Init();
    }
    public static void InitGame()
    {
        SaveValueGame.Current_FightState = FightState.Wait;
        SaveValueGame.Current_GameState = GameState.Stage;
        SaveValueGame.Stage = 0;
        SaveValueGame.Floor = 0;
        SaveValueGame.Cost = 0;
        SaveValueGame.Gold = 0;
    }

    public static void SetScreenResolution(int x, int y,bool full)
    {
        Screen.SetResolution(x, y, full);
    }
}
