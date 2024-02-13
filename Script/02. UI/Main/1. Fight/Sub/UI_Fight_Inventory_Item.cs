using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Fight_Inventory_Item : MonoBehaviour
{
    public ItemData _ItemData;

    public Image Icon;
    public TextMeshProUGUI Tooltip_Head;
    public TextMeshProUGUI Tooltip_Body;

    private Button _Button;

    public void Init(ItemData data)
    {
        if (data == null)
            return;

        _Button = GetComponent<Button>();


       _ItemData = data;
        
        Icon.sprite = _ItemData.Sprite;
        
        Tooltip_Head.text = _ItemData.Name[SaveData.SaveValuePlayer.LanguageValue];
        Tooltip_Head.color = SaveData.SaveValue.ItemColor[(int)_ItemData.Type];

        Tooltip_Body.text = _ItemData.GetItemDescription();

        ColorBlock colorBlock = _Button.colors;
        colorBlock.normalColor = SaveData.SaveValue.ItemColor[(int)_ItemData.Type];
        colorBlock.highlightedColor = SaveData.SaveValue.ItemColor[(int)_ItemData.Type] * 0.8f;

        _Button.colors = colorBlock;
        _Button.onClick.AddListener(() => SetButton());
    }
    public void SetButton()
    {
        if (SaveData.SaveValueGame.Current_FightState != FightState.Wait)
            return;
        
        PlayerManager.instance.OnInventoryItem(this);
        OnItem();
    }

    public void OnItem()
    {
        Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, $"<color=#ffffff>[ </color>{_ItemData.Name[SaveData.SaveValuePlayer.LanguageValue]}<color=#ffffff> ] {SaveData.LanguageData.Inventory_UseText[(int)_ItemData.Tag, SaveData.SaveValuePlayer.LanguageValue]}</color>", SaveData.SaveValue.ItemColor[(int)_ItemData.Type], 5);
    }
    // true "" flase Text
    public void OffItem(bool value)
    {
        if (value)
            Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, "", Color.white, 0);
        else    
            Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, $"<color=#ffffff>[ </color>{_ItemData.Name[SaveData.SaveValuePlayer.LanguageValue]}<color=#ffffff> ] {SaveData.LanguageData.Inventory_UseFalseText[(int)_ItemData.Tag, SaveData.SaveValuePlayer.LanguageValue]}</color>", SaveData.SaveValue.ItemColor[(int)_ItemData.Type], 2f);
    }
    
    public void Exit()
    {
        OffItem(true);

        int remove = PlayerManager.instance.ItemList.IndexOf(gameObject);
        PlayerManager.instance.ItemList.RemoveAt(remove);
        
        Destroy(this.gameObject);
    }
}
