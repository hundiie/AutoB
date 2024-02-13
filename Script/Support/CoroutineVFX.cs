using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineVFX : MonoBehaviour
{
    public ParticleSystem _Particle;
    public float Delay;
    public bool IsDelay;

    private void SetParticle(bool unit ,bool calibration)
    {
        if (calibration)
        {
            Vector3 vector = transform.position;

            if (!unit)
            {
                vector.y += 1f;
                vector.z -= 0.5f;
            }
            else
            {
                vector.y += 0.5f;
            }

            transform.position = vector;
        }

        _Particle = GetComponent<ParticleSystem>();
        _Particle.Play();
    }

    private void Update()
    {
        if (IsDelay)
        {
            Delay -= Time.deltaTime;

            if (Delay <= 0)
            {
                Stop();
            }
        }
        
        if (SaveData.SaveValueGame.Current_GameState != GameState.Fight)
            Stop();
    }
    public void Stop()
    {
        _Particle.Clear();
        Destroy(gameObject);
    }

    // 특정 위치에서 FX
    public static CoroutineVFX Start_Coroutine(Vector3 vector, int id)
    {
        GameObject par = ResourcesData.Get_Particle(id);
        if (par == null) return null;

        GameObject obj = Instantiate(par, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(false, false);

        return handler;
    }
    public static CoroutineVFX Start_Coroutine(Vector3 vector, int id, bool calibration)
    {
        GameObject par = ResourcesData.Get_Particle(id);
        if (par == null) return null;

        GameObject obj = Instantiate(par, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(false, calibration);

        return handler;
    }
    // 특정 유닛에게 FX
    public static CoroutineVFX Start_Coroutine(Unit target, int id)
    {
        GameObject par = ResourcesData.Get_Particle(id);
        if (par == null) return null;

        GameObject obj = Instantiate(par, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(true, false);

        return handler;
    }
    // 특정 위치에서 FX 딜레이 주기
    public static CoroutineVFX Start_Coroutine(Vector3 vector, int id, float delay)
    {
        GameObject par = ResourcesData.Get_Particle(id);
        if (par == null) return null;

        GameObject obj = Instantiate(par, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.IsDelay = true;
        handler.Delay = delay;
        handler.SetParticle(false, false);

        return handler;
    }
    // 특정 유닛에게 FX 딜레이 주기
    public static CoroutineVFX Start_Coroutine(Unit target, int id, float delay)
    {
        GameObject par = ResourcesData.Get_Particle(id);
        if (par == null) return null;
        
        GameObject obj = Instantiate(par, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.IsDelay = true;
        handler.Delay = delay;
        handler.SetParticle(true, false);

        return handler;
    }
    // fx로 특정 위치에서 FX
    public static CoroutineVFX Start_Coroutine(Vector3 vector, GameObject fx)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(false, false);

        return handler;
    }
    public static CoroutineVFX Start_Coroutine(Vector3 vector, GameObject fx, bool calibration)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(false, calibration);

        return handler;
    }

    // fx로 특정 위치에서 FX 딜레이
    public static CoroutineVFX Start_Coroutine(Vector3 vector, GameObject fx, float delay)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, vector, Quaternion.identity);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.IsDelay = true;
        handler.Delay = delay;
        handler.SetParticle(false, false);

        return handler;
    }
    // fx로 특정 유닛에게 FX
    public static CoroutineVFX Start_Coroutine(Unit target, GameObject fx, bool calibration)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(true, calibration);

        return handler;
    }
    public static CoroutineVFX Start_Coroutine(Unit target, GameObject fx, bool unit, bool calibration)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(unit, calibration);

        return handler;
    }
    public static CoroutineVFX Start_Coroutine(Unit target, GameObject fx)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.SetParticle(true, false);

        return handler;
    }
    // fx로 특정 유닛에게 FX 딜레이
    public static CoroutineVFX Start_Coroutine(Unit target, GameObject fx, float delay)
    {
        if (fx == null) return null;

        GameObject obj = Instantiate(fx, target.transform.position, Quaternion.identity, target.transform);
        CoroutineVFX handler = obj.AddComponent<CoroutineVFX>();

        handler.IsDelay = true;
        handler.Delay = delay;
        handler.SetParticle(true, false);

        return handler;
    }
}
