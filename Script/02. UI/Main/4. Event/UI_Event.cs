using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Event : MonoBehaviour
{
    public UI_Event_Data _EventCheck;

    [Header("Prefab")]
    public GameObject Prefab_ButtonItem;

    [Header("UI")]
    public GameObject Content_Choice;
    public Image Sprite_Event;
    
    public TextMeshProUGUI Text_Head;
    public TextMeshProUGUI Text_Body;
    public TextMeshProUGUI Text_End;

    public Button Button_Back;
    public TextMeshProUGUI Text_BackButton;

    [Header("Clip")]
    public AudioClip Clip_Button;
    public AudioClip Clip_Back;

    List<GameObject> List_Choice = new List<GameObject>();

    public void SetButton_Back()
    {
        SaveValueGame.Current_GameState = GameState.Stage;
        CoroutineSound.Start_Coroutine(Clip_Back, SaveValuePlayer.Volume_Effect, false);
        SetActiveButton(false);
    }
    public void SetActiveButton(bool value)
    {
        Button_Back.gameObject.SetActive(value);
    }
    public void SetEvent(int id)
    {
        EventData data = ResourcesData.Get_EventData(id);
        
        if (data != null)
            SetEvent(data);
    }
    public void SetEvent(EventData data)
    {
        Text_BackButton.text = LanguageData.Event_BackButton[SaveValuePlayer.LanguageValue];
        SetActiveButton(false);

        SetValue(data.Sprite, data.Name[SaveValuePlayer.LanguageValue], data.Description[SaveValuePlayer.LanguageValue], "");
        CreateEventButton(data);
    }

    public void SetValue(Sprite sprite, string head, string body, string end)
    {
        if (sprite != null)
            Sprite_Event.sprite = sprite;
        if (head != null)
            Text_Head.text = head;
        if (body != null)
            Text_Body.text = body;
        if (end != null)
            Text_End.text = end;
    }
    public void CreateEventButton(EventData data)
    {
        for (int i = 0; i < data.Choice.Length; i++)
        {
            GameObject ins = Instantiate(Prefab_ButtonItem, Content_Choice.transform);
            List_Choice.Add(ins);

            UI_Event_Item item = ins.GetComponent<UI_Event_Item>();
            item.Init(data, i);
        }
    }
    public void ClearEventButton()
    {
        for (int i = List_Choice.Count - 1; i >= 0; i--)
        {
            Destroy(List_Choice[i]);
        }
        List_Choice.Clear();
    }
}
