using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveData;

public class UI_Fight_Game : MonoBehaviour
{
    public Button Button_Play;

    [Header("Clip")]
    public AudioClip Clip_Play;

    public void SetActivePlayButton(bool value)
    {
        Button_Play.gameObject.SetActive(value);
    }

    public void SetButton_Play()
    {
        SaveValueGame.Current_FightState = FightState.Fight;
        CoroutineSound.Start_Coroutine(Clip_Play, SaveValuePlayer.Volume_Effect);
    }
}
