using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSound : MonoBehaviour
{
    public AudioSource Source = null;

    public float Delay;

    public bool IsPlay;
    
    private void SoundEffect(AudioClip clip, float volume)
    {
        Source = gameObject.AddComponent<AudioSource>();

        Source.volume = volume;
        Source.clip = clip;
        
        if (Delay != 0)
            StartCoroutine(SoundDelay());
        else
        {
            Source.Play();
            IsPlay = true;
        }
    }

    private IEnumerator SoundDelay()
    {
        yield return new WaitForSeconds(Delay);

        Source.Play();
        IsPlay = true;
    }

    void Update()
    {
        if (Source != null)
        {
            if (!Source.isPlaying && IsPlay)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Stop()
    {
        if (Source != null)
            Source.Stop();
        
        if (gameObject != null)
            Destroy(gameObject);
    }
    public static CoroutineSound Start_Coroutine(AudioClip clip, float volume)
    {
        GameObject obj = new GameObject("CoroutineHandler");
        CoroutineSound sound = obj.AddComponent<CoroutineSound>();

        if (sound)
            sound.SoundEffect(clip, volume);
        return sound;
    }
    public static CoroutineSound Start_Coroutine(AudioClip clip, float volume, bool destroy)
    {
        if (clip == null)
            return null;
        
        GameObject obj = new GameObject("CoroutineHandler");
        CoroutineSound sound = obj.AddComponent<CoroutineSound>();
        
        if (!destroy)
            DontDestroyOnLoad(obj);

        if (sound)
            sound.SoundEffect(clip, volume);
        return sound;
    }
    public static CoroutineSound Start_Coroutine(AudioClip clip, float volume, float delay)
    {
        GameObject obj = new GameObject("CoroutineHandler");
        CoroutineSound sound = obj.AddComponent<CoroutineSound>();
        sound.Delay = delay;

        if (sound)
            sound.SoundEffect(clip, volume);
        return sound;
    }
    public static CoroutineSound Start_Coroutine(AudioClip clip, float volume, float delay, bool destroy)
    {
        if (clip == null)
            return null;

        GameObject obj = new GameObject("CoroutineHandler");
        CoroutineSound sound = obj.AddComponent<CoroutineSound>();
        sound.Delay = delay;

        if (!destroy)
            DontDestroyOnLoad(obj);

        if (sound)
            sound.SoundEffect(clip, volume);
        return sound;
    }
}
