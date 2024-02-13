using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Shop_Item : MonoBehaviour
{
    ItemData _ItemData;

    public GameObject Sold;

    public Image Icon;
    public TextMeshProUGUI Tooltip_Head;
    public TextMeshProUGUI Tooltip_Body;
    public TextMeshProUGUI Text_Cost;
    public Button Button_Sell;

    int Cost;
    
    public void Init(ItemData data)
    {
        _ItemData = data;

        Sold.SetActive(false);
        
        Icon.sprite = data.Sprite;
        Tooltip_Head.text = data.Name[SaveValuePlayer.LanguageValue];
        Tooltip_Body.text = data.GetItemDescription();

        // 스테이지 진행에 따른 가격 가중치
        float stageRate = (SaveValueGame.Stage * 1.5f) + SaveValueGame.Floor * 0.05f;

        float cost = data.GoldCost * (1 + stageRate);

        cost *= 1f - (PlayerManager.instance.Shop_Sale / 100f);
        cost += Random.Range(data.GoldCost * -0.5f, data.GoldCost * 0.5f);
        
        Cost = Mathf.RoundToInt(cost);
            
        Text_Cost.text = Cost.ToString();
        Button_Sell.onClick.AddListener(() => SetButton());
    }

    public void SetButton()
    {
        if (Cost <= SaveValueGame.Gold)
        {
            SaveValueGame.Gold -= Cost;
            Canvas_Main.instance._UI_TopCategory.SetGold();

            PlayerManager.instance.AddItem(_ItemData);
            Sold.SetActive(true);
            Button_Sell.interactable = false;

            int rand = Random.Range(0, 3);
            Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, LanguageData.Shop_True[rand,SaveValuePlayer.LanguageValue], Color.white, 2);
            CoroutineSound.Start_Coroutine(Canvas_Main.instance._Shop.Clip_Sell_True, SaveValuePlayer.Volume_Effect, false);
        }
        else
        {
            int rand = Random.Range(0, 3);
            Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, LanguageData.Shop_False[rand, SaveValuePlayer.LanguageValue], Color.white, 2);
            CoroutineSound.Start_Coroutine(Canvas_Main.instance._Shop.Clip_Sell_False, SaveValuePlayer.Volume_Effect, false);
        }
    }
}
