using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Event_Item : MonoBehaviour
{
    private EventSetting _EventSetting;
    private Button Button_Item;

    public TextMeshProUGUI Text_Item;

    private void Awake()
    {
        _EventSetting = GetComponent<EventSetting>();
        Button_Item = GetComponent<Button>();
    }
    public void Init(EventData data, int value)
    {
        Text_Item.text = data.Choice[value].Text[SaveData.SaveValuePlayer.LanguageValue];
        Button_Item.onClick.AddListener(() => SetButton(data, value));
    }

    public void SetButton(EventData data, int value)
    {
        Canvas_Main.instance._Event.ClearEventButton();
        Canvas_Main.instance._Event.SetActiveButton(true);
        CoroutineSound.Start_Coroutine(Canvas_Main.instance._Event.Clip_Button, SaveValuePlayer.Volume_Effect, false);
        
        if (data.Choice[value].Chance.Length != 0)
        {
            int rand = RandChoice(data.Choice[value]);
            
            Canvas_Main.instance._Event.SetValue(null, null, data.Choice[value].Description[rand].Array[SaveValuePlayer.LanguageValue], null);

            _EventSetting.SetEvent(data, value, rand);
        }
    }

    public int RandChoice(Event_Choice choice)
    {
        float value = 0;
        for (int i = 0; i < choice.Chance.Length; i++)
        {
            value += choice.Chance[i];
        }

        float rand = Random.Range(0f, value);
        // Debug.Log("value : " + value +" rand : " + rand);
        for (int i = 0; i < choice.Chance.Length; i++)
        {
            rand -= choice.Chance[i];
            
            if (rand < 0f)
                return i;
        }

        Debug.Log("제대로 이벤트 버튼 확률 선택이 안됨");
        return 0;
    }
}
