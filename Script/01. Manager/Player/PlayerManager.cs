using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private IState[] _IStates;
    [SerializeField] private FightState _state;
    public FightState state
    {
        get => _state;
        set
        {
            _IStates[(int)_state].Exit();
            _state = value;
            _IStates[(int)_state].Enter();
        }
    }

    public List<GameObject> ItemList { get; set; } = new List<GameObject>();

    private void Awake()
    {
        instance = this;

        _IStates = new IState[System.Enum.GetValues(typeof(FightState)).Length];
        _IStates[(int)FightState.Wait] = new PlayerManager_Wait(this);
        _IStates[(int)FightState.Fight] = new PlayerManager_Fight(this);
        _IStates[(int)FightState.Result] = new PlayerManager_Result(this);
    }
    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddItem(Random.Range(100, 107));
        }
    }

    private void Update()
    {
        if (state != SaveData.SaveValueGame.Current_FightState)
            state = SaveData.SaveValueGame.Current_FightState;

        _IStates[(int)_state].Stay();

        if (UpdateMode[0])
            EnterUnit(Support.Mouse.GetMouse_PointToLayer("Unit"));
        if (UpdateMode[1])
            EnterTile(Support.Mouse.GetMouse_PointToLayer("Tile"));
    }

    // bool
    /// <summary>
    /// 0 유닛 1 타일
    /// </summary>
    public bool[] UpdateMode = new bool[2];

    // Tile
    public TileData PrevTileData;
    public TileData CurrentTileData;

    // Unit
    public List<string> DeadUnit = new List<string>();
    public Unit PrevUnit;
    public Unit CurrentUnit;

    // Item
    public UI_Fight_Inventory_Item CurrentInventoryItem;

    // Skill
    public bool OnCharacterSkill = false;
    public int OnCharacterSkill_Id;
    // Game
    public float Shop_Sale;

    [Header("Clip")]
    public AudioClip Clip_UseItem;
    public AudioClip Clip_UnitChange;
    public AudioClip Clip_Result;

    // Enter
    public void EnterTile(GameObject tile)
    {
        TileData get = tile != null ? tile.GetComponent<TileData>() : null;
        if (get == CurrentTileData) return;

        PrevTileData = CurrentTileData;
        CurrentTileData = get;

        Canvas_Main.instance._Fight._UnitInfo.SetUnit(CurrentTileData != null ? CurrentTileData.Unit_Object : null);

        if (PrevTileData != null) PrevTileData.ChangeColor(Color.white);
        if (CurrentTileData != null) CurrentTileData.ChangeColor(SaveData.ColorData.Green);
    }
    public void EnterUnit(GameObject unit)
    {
        Unit get = unit != null ? unit.GetComponent<Unit>() : null;
        if (get == CurrentUnit) return;

        PrevUnit = CurrentUnit;
        CurrentUnit = get;

        Canvas_Main.instance._Fight._UnitInfo.SetUnit(CurrentUnit != null ? CurrentUnit : null);

        // 색 바꾸기
        if (PrevUnit != null)
        {
            UnitRenderer ren = PrevUnit.GetComponent<UnitRenderer>();

            for (int i = 0; i < ren.Render.Count; i++)
            {
                Outline ol = ren.Render[i].GetComponent<Outline>();

                if (ol != null)
                    Destroy(ol);
            }
        }

        if (CurrentUnit != null)
        {
            UnitRenderer ren = CurrentUnit.GetComponent<UnitRenderer>();

            for (int i = 0; i < ren.Render.Count; i++)
            {
                Outline ol = ren.Render[i].GetComponent<Outline>();

                if (ol == null)
                    ol = ren.Render[i].AddComponent<Outline>();

                ol.color = CurrentUnit._Faction == Faction.Player ? 0 : 1;
            }
        }
    }

    // 타일교체
    public void ChangeTileUnit(TileData A, TileData B)
    {
        if (A == null || B == null) return;

        // 교환
        Unit C = A.Unit_Object;
        A.Unit_Object = B.Unit_Object;
        B.Unit_Object = C;
        // 유닛 위치이동
        if (A.Unit_Object != null) A.Unit_Object.transform.position = A.transform.position;
        if (B.Unit_Object != null) B.Unit_Object.transform.position = B.transform.position;
        // 맵에 이동 값 반영
        MapManager.instance.SetTileUnit(A.transform.position, A.Unit_Object);
        MapManager.instance.SetTileUnit(B.transform.position, B.Unit_Object);

        EnterTile(null);
    }

    // 아이템 사용
    public void OnInventoryItem(UI_Fight_Inventory_Item item)
    {
        if (item == null) return;
        
        CurrentInventoryItem = item;
        UpdateMode[CurrentInventoryItem._ItemData.Tag == ItemTag.Unit? 1 : 0] = true;
    }
    public void AddItem(int id)
    {
        ItemData data = ResourcesData.Get_ItemData(id);
        AddItem(data);
    }
    public void AddItem(ItemData data)
    {
        Canvas_Main.instance._Fight._Inventory.AddItem(data);
    }

    // Inventory Item
    public void OffInventoryItem(bool result)
    {
        UpdateMode[CurrentInventoryItem._ItemData.Tag == ItemTag.Unit ? 1 : 0] = false;
        
        // true 사용 성공, false 사용 취소
        if (result)
            CurrentInventoryItem.Exit();
        else
            CurrentInventoryItem.OffItem(true);
        
        CurrentInventoryItem = null;

        EnterUnit(null);
        EnterTile(null);
    }
    public void OffInventoryItem(bool result,bool off)
    {
        UpdateMode[CurrentInventoryItem._ItemData.Tag == ItemTag.Unit ? 1 : 0] = false;

        // true 사용 성공, false 사용 취소
        if (result)
            CurrentInventoryItem.Exit();
        else
            CurrentInventoryItem.OffItem(off);

        CurrentInventoryItem = null;

        EnterUnit(null);
        EnterTile(null);
    }
    
    // Character Skill
    public void SetCharacterSkill(int value, bool check)
    {
        if (state == FightState.Fight)
        {
            EnterUnit(Support.Mouse.GetMouse_PointToLayer("Unit"));
            OnCharacterSkill = check;
            UpdateMode[0] = check;
        }

        if (value < 0 || value > ResourcesData._CharacterData.Count - 1 || !check)
            return;

        OnCharacterSkill_Id = value;

        // 마법사의 첫 스킬은 예외
        if (SaveData.SaveValueGame.CharacterId == 1 && OnCharacterSkill_Id == 0)
        {
            Skill_Character.SetSkill(value, null);
            OnCharacterSkill = false;
            UpdateMode[0] = false;
        }

        SetText_CharacterSkill(value);
    }

    public void SetText_CharacterSkill(int value)
    {
        string skillname = ResourcesData._CharacterData[SaveData.SaveValueGame.CharacterId].Skills[value].Skill_Name[SaveData.SaveValuePlayer.LanguageValue];
        string skilltext = "";
        switch (SaveData.SaveValueGame.CharacterId)
        {
            case 0:
                {
                    switch (value)
                    {
                        case 0: skilltext = SaveData.LanguageData.Skill_SetText[1, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 1: skilltext = SaveData.LanguageData.Skill_SetText[0, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 2: skilltext = SaveData.LanguageData.Skill_SetText[1, SaveData.SaveValuePlayer.LanguageValue]; break;
                        default: break;
                    }
                }
                break;
            case 1:
                {
                    switch (value)
                    {
                        case 0: skilltext = SaveData.LanguageData.Skill_SetText[2, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 1: skilltext = SaveData.LanguageData.Skill_SetText[0, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 2: skilltext = SaveData.LanguageData.Skill_SetText[1, SaveData.SaveValuePlayer.LanguageValue]; break;
                        default: break;
                    }
                }
                break;
            case 2:
                {
                    switch (value)
                    {
                        case 0: skilltext = SaveData.LanguageData.Skill_SetText[0, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 1: skilltext = SaveData.LanguageData.Skill_SetText[0, SaveData.SaveValuePlayer.LanguageValue]; break;
                        case 2: skilltext = SaveData.LanguageData.Skill_SetText[0, SaveData.SaveValuePlayer.LanguageValue]; break;
                        default: break;
                    }
                }
                break;
            default: break;
        }
        Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, $"<color=#ffffff>[</color> {skillname} <color=#ffffff>] {skilltext}</color>", SaveData.ColorData.BlueSky, 5);
    }
}
