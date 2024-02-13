using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Fight_Damage : MonoBehaviour
{
    public GameObject Prefab_Damage;

    public void SetDamageText(Unit unit, string text, Color color, float delay, float speed)
    {
        GameObject ins = Instantiate(Prefab_Damage, transform);

        TextMeshProUGUI tmp = ins.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.color = color;

        ins.AddComponent<DamageScript>().Init(unit, delay, speed);
    }
    public void SetDamageText(Unit unit, float text, Color color, float delay, float speed)
    {
        GameObject ins = Instantiate(Prefab_Damage, transform);

        TextMeshProUGUI tmp = ins.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = Mathf.RoundToInt(text).ToString();
        tmp.color = color;

        ins.AddComponent<DamageScript>().Init(unit, delay, speed);
    }
    public void SetDamageText(Unit unit, int deci, float text, Color color, float delay, float speed)
    {
        GameObject ins = Instantiate(Prefab_Damage, transform);
        
        TextMeshProUGUI tmp = ins.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        
        float dec = Mathf.Pow(10, deci);
        tmp.text = (Mathf.Floor(text * dec) / dec).ToString();
        tmp.color = color;

        ins.AddComponent<DamageScript>().Init(unit, delay, speed);
    }
}

class DamageScript : MonoBehaviour
{
    Vector3 _Vector;

    CanvasGroup _CanvasGroup;
    Unit _Unit;

    float Delay, Speed, PosY, Alpha;

    private void Update()
    {
        PosY += Time.deltaTime * Speed;
        Alpha -= Time.deltaTime / Delay;

        transform.position = Camera.main.WorldToScreenPoint(_Vector + new Vector3(0, PosY, 0));

        if (Alpha <= 0.5f) _CanvasGroup.alpha = Alpha * 2;
    }
    public void Init(Unit unit, float delay, float speed)
    {
        _Vector = unit.transform.position;

        _CanvasGroup = GetComponent<CanvasGroup>();
        _Unit = unit;

        Delay = delay;
        Speed = speed;

        PosY = 1;
        Alpha = 1;

        transform.position = Camera.main.WorldToScreenPoint(_Vector + new Vector3(0, PosY, 0));
        Destroy(gameObject, delay);
    }
}