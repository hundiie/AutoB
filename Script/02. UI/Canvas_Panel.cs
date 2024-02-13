using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ricimi;

public class Canvas_Panel : MonoBehaviour
{
    public Image Don;

    [Header("Top")]
    public UI_TopCategory _UI_TopCategory;

    [Header("Selection")]
    public UI_CharacterPanel _CharacterPanel;
    public List<GameObject> Selection;

    private CanvasGroup[] CanvasGroup_Selection;
    private int PrevSelection, CurrentSelection;

    [Header("Clip")]
    public AudioClip Clip_Change;
    public AudioClip Clip_Play;
    public AudioClip Clip_Back;
    
    public AudioClip Clip_Refund;
    public AudioClip Clip_True;
    public AudioClip Clip_False;


    private void Start()
    {
        Init();
    }
    public void Init()
    {
        StartCoroutine(DonRaycastTarget());
        CanvasGroup_Selection = new CanvasGroup[Selection.Count];

        for (int i = 0; i < Selection.Count; i++)
        {
            CanvasGroup_Selection[i] = Selection[i].GetComponent<CanvasGroup>();
            CanvasGroup_Selection[i].alpha = 0;
        }

        CharacterSelection();
    }
    public IEnumerator DonRaycastTarget()
    {
        Don.raycastTarget = true;

        yield return new WaitForSeconds(1);

        Don.raycastTarget = false;
    }

    // Selection
    public void SetButton_Play()
    {
        Don.raycastTarget = true;
        GameManager.InitGame();
        Transition.LoadLevel("Main", 2, Color.black);
        CoroutineSound.Start_Coroutine(Clip_Play, SaveData.SaveValuePlayer.Volume_Effect, false);
    }
    public void SetButton_Back()
    {
        Don.raycastTarget = true;
        Transition.LoadLevel("Title", 2, Color.black);
        CoroutineSound.Start_Coroutine(Clip_Back, SaveData.SaveValuePlayer.Volume_Effect);
    }
    public void SetButton_Difficulty()
    {

    }
    public void SetButton_Left()
    {
        PrevSelection = CurrentSelection;
        CurrentSelection--;
        if (CurrentSelection < 0)
            CurrentSelection = Selection.Count - 1;
        
        CharacterSelection();
        CoroutineSound.Start_Coroutine(Clip_Change, SaveData.SaveValuePlayer.Volume_Effect);
    }
    public void SetButton_Right()
    {
        PrevSelection = CurrentSelection;
        CurrentSelection = (CurrentSelection + 1) % Selection.Count;

        CharacterSelection();
        CoroutineSound.Start_Coroutine(Clip_Change, SaveData.SaveValuePlayer.Volume_Effect);
    }

    public void CharacterSelection()
    {
        if (PrevSelection != CurrentSelection)
            StartCoroutine(Utils.FadeOut(CanvasGroup_Selection[PrevSelection], 0.0f, 0.1f));

        StartCoroutine(Utils.FadeIn(CanvasGroup_Selection[CurrentSelection], 1.0f, 0.1f));

        SaveData.SaveValueGame.CharacterId = CurrentSelection;
        _CharacterPanel.SetPanel();
    }
    public IEnumerator SetAlpha(CanvasGroup canvas, float value, float delay)
    {
        bool upper = canvas.alpha >= value ? true : false;
        while (true)
        {
            if (upper)
            {
                canvas.alpha -= Time.deltaTime / delay;
                if (canvas.alpha < value || canvas.alpha == 0)
                    break;
            }
            else
            {
                canvas.alpha += Time.deltaTime / delay;
                if (canvas.alpha > value || canvas.alpha == 1)
                    break;
            }
            
            yield return new WaitForSeconds(0);
        }
        
    }
    
    // Passive
    public void SetButton_PassiveUpgrade()
    {
        CharacterData data = _CharacterPanel.data;
        float cost = Support.Math.Get_UpgradeRate(data.Character_UpgradePrice, data.Character_UpgradePrice_Up, SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id]);
        
        if (SaveData.SaveValueOutPlayer.Player_Gem >= cost)
        {
            SaveData.SaveValueOutPlayer.Player_Gem -= (int)cost;
            SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id] += 1;

            _CharacterPanel.SetCharacterDescription();
            _CharacterPanel.SetPassiveRefund();

            _UI_TopCategory.SetGem();

            CoroutineSound.Start_Coroutine(Clip_True, SaveData.SaveValuePlayer.Volume_Effect);
        }
        else
            CoroutineSound.Start_Coroutine(Clip_False, SaveData.SaveValuePlayer.Volume_Effect);

    }
    public void SetButton_PassiveRefund()
    {
        CharacterData data = _CharacterPanel.data;

        if (_CharacterPanel.PassiveRefundValue > 0)
        {
            SaveData.SaveValueOutPlayer.Player_Gem += (int)(_CharacterPanel.PassiveRefundValue * 0.5f);
            SaveData.SaveValueOutPlayer.Character_PassiveLevel[data.Id] = 0;

            _CharacterPanel.SetCharacterDescription();
            _CharacterPanel.SetPassiveRefund();

            _UI_TopCategory.SetGem();

            CoroutineSound.Start_Coroutine(Clip_Refund, SaveData.SaveValuePlayer.Volume_Effect);
        }
        else
            CoroutineSound.Start_Coroutine(Clip_False, SaveData.SaveValuePlayer.Volume_Effect);
    }

    // Skill
    public void SetButton_SkillUpgrade(int value)
    {
        CharacterData data = _CharacterPanel.data;
        float cost = Support.Math.Get_UpgradeRate(data.Skills[value].Skill_Price, data.Skills[value].Skill_Price_Upgrade, SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, value]);
        Debug.Log(value + " : " + cost);
        if (SaveData.SaveValueOutPlayer.Player_Gem >= cost)
        {
            SaveData.SaveValueOutPlayer.Player_Gem -= (int)cost;
            SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id, value] += 1;

            _CharacterPanel.SetSkillDescription(value);
            _CharacterPanel.SetSkillRefund();

            _UI_TopCategory.SetGem();
     
            CoroutineSound.Start_Coroutine(Clip_True, SaveData.SaveValuePlayer.Volume_Effect);
        }
        else
            CoroutineSound.Start_Coroutine(Clip_False, SaveData.SaveValuePlayer.Volume_Effect);
    }
    public void SetButton_SkillRefund()
    {
        CharacterData data = _CharacterPanel.data;

        if (_CharacterPanel.SkillRefundValue > 0)
        {
            SaveData.SaveValueOutPlayer.Player_Gem += (int)(_CharacterPanel.SkillRefundValue * 0.5f);
            
            for (int i = 0; i < data.Skills.Length; i++)
            {
                SaveData.SaveValueOutPlayer.Character_SkillLevel[data.Id,i] = 0;
            }

            _CharacterPanel.SetAllSkillDescription();
            _CharacterPanel.SetSkillRefund();

            _UI_TopCategory.SetGem();
            
            CoroutineSound.Start_Coroutine(Clip_Refund, SaveData.SaveValuePlayer.Volume_Effect);
        }
        else
            CoroutineSound.Start_Coroutine(Clip_False, SaveData.SaveValuePlayer.Volume_Effect);
    }

}
