using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Main : MonoBehaviour
{
    public static Sound_Main instance;

    public AudioClip[] Clip_Background;
    public float[] Clip_Delay;

    public CoroutineSound CurrentSound;

    GameState state;
    private void Awake()
    {
        instance = this;
    }
    public void SetBackgroundSound()
    {
        StopAllCoroutines();
        StartCoroutine(Background());
    }
    public void ChangeBackgroundSound()
    {
        StopAllCoroutines();

        if (CurrentSound != null)
            CurrentSound.Source.volume = SaveData.SaveValuePlayer.Volume_Background;
    }

    public IEnumerator Background()
    {
        if (CurrentSound != null)
        {
            yield return StartCoroutine(VolumeDown(CurrentSound.Source, 0, 0.5f));
            
            CurrentSound.Stop();
            CurrentSound = null;
        }
        
        if (Clip_Background[(int)SaveData.SaveValueGame.Current_GameState] != null)
            CurrentSound = CoroutineSound.Start_Coroutine(Clip_Background[(int)SaveData.SaveValueGame.Current_GameState], 0);
        
        state = SaveData.SaveValueGame.Current_GameState;
        
        float Delay = Clip_Delay[(int)SaveData.SaveValueGame.Current_GameState];
        
        if (CurrentSound != null)
            yield return StartCoroutine(VolumeUp(CurrentSound.Source, SaveData.SaveValuePlayer.Volume_Background, Delay));
    }

    public IEnumerator VolumeDown(AudioSource source, float value, float delay)
    {
        if (source == null)
            yield break;
        
        float gap = source.volume - value;
        
        while (source.volume >= value)
        {
            source.volume -= Time.deltaTime * gap / delay;
            yield return new WaitForEndOfFrame();
            
            if (source == null)
                break;
        }

        if (source != null)
            source.volume = value;
    }
    public IEnumerator VolumeUp(AudioSource source, float value, float delay)
    {
        if (source == null)
            yield break;

        float gap = value - source.volume;

        while (source.volume <= value)
        {
            source.volume += Time.deltaTime * gap / delay;
            yield return new WaitForEndOfFrame();
            
            if (source == null)
                break;
        }
        
        if (source != null)
            source.volume = value;
    }
}
