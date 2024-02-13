using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Main : MonoBehaviour
{
    public static Canvas_Main instance;
    public CharacterData _CharacterData;

    [Header("Top")]
    public UI_TopCategory _UI_TopCategory;

    [Header("UI")]
    public UI_Stage _Stage;
    public UI_Fight _Fight;
    public UI_Shop _Shop;
    public UI_Rest _Rest;
    public UI_Event _Event;
    public UI_Gameover _GameOver;

    public UI_Effect _Effect;

    private CanvasGroup[] _CanvasGroup;

    private GameState _State;
    public GameState State
    {
        get { return _State; }
        set
        {
            Sound_Main.instance.SetBackgroundSound();
            
            if (value == GameState.Gameover)
                _GameOver.Init();
            
            StartCoroutine(SetState(_State, value));
            _State = value;
        }
    }

    private void Awake()
    {
        instance = this;

        _CanvasGroup = new CanvasGroup[System.Enum.GetValues(typeof(GameState)).Length];
        _CanvasGroup[(int)GameState.Stage] = _Stage.GetComponent<CanvasGroup>();
        _CanvasGroup[(int)GameState.Fight] = _Fight.GetComponent<CanvasGroup>();
        _CanvasGroup[(int)GameState.Shop] = _Shop.GetComponent<CanvasGroup>();
        _CanvasGroup[(int)GameState.Rest] = _Rest.GetComponent<CanvasGroup>();
        _CanvasGroup[(int)GameState.Event] = _Event.GetComponent<CanvasGroup>();
        _CanvasGroup[(int)GameState.Gameover] = _GameOver.GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        _CharacterData = ResourcesData.Get_CharacterData(SaveData.SaveValueGame.CharacterId);
        Init();

        // ½ºÅ¸Æ® UI
        State = SaveData.SaveValueGame.Current_GameState;
        GameManager.Init();
    }

    private void Update()
    {
        if (SaveData.SaveValueGame.Current_GameState != State)
            State = SaveData.SaveValueGame.Current_GameState;
    }

    public void Init()
    {
        // Top
        _UI_TopCategory.SetSubText(_CharacterData.Character_Name[SaveData.SaveValuePlayer.LanguageValue]);
        // Main
        for (int i = 0; i < _CanvasGroup.Length; i++)
        { SetCanvasGroupValue(_CanvasGroup[i], i == 0 ? true : false); }

        // Fight
        for (int i = 0; i < _CharacterData.Skills.Length; i++)
        { _Fight._Skill.SetSkill(i); }
        _Fight._Skill.SetPlayerCost();

        _Fight._UnitInfo.SetTooltip();
    }

    public void SetCanvasGroupValue(CanvasGroup group, bool value)
    {
        group.alpha = value ? 1 : 0;
        group.interactable = value;
        group.blocksRaycasts = value;
    }

    public IEnumerator SetState(GameState currentState, GameState nextState)
    {
        if (currentState != nextState)
        {
            yield return StartCoroutine(_Effect.FadeInBlack(0.8f));
            SetCanvasGroupValue(_CanvasGroup[(int)currentState], false);
        }

        SetCanvasGroupValue(_CanvasGroup[(int)nextState], true);
        yield return StartCoroutine(_Effect.FadeOutBlack(0.8f));
    }
}
