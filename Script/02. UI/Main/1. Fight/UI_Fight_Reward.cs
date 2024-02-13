using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;
using UnityEngine.UI;
using TMPro;

public class UI_Fight_Reward : MonoBehaviour
{
    public GameObject RewardPage;

    [Header("Prefab")]
    public GameObject Pufab_ItemDamage;
    public GameObject Pufab_ItemStage;

    [Header("Scroll")]
    public ScrollRect Scroll_Damage;
    public ScrollRect Scroll_Stage;

    [Header("Clip")]
    public AudioClip Clip_Next;

    private List<GameObject> List_Damage = new List<GameObject>();
    private List<GameObject> List_Stage = new List<GameObject>();

    private void Start()
    {
        RewardPage.SetActive(false);
    }
    public void SetReward()
    {
        RewardPage.SetActive(true);
    }
    
    public void SetReward(List<Unit> units)
    {
        RewardPage.SetActive(true);

        SetRewardUnit(units);

        float coin = MapManager.instance._StageData.Coin * Random.Range(0.6f, 1.4f);
        float exp = MapManager.instance._StageData.Exp;
        
        AddStage().SetCoin((int)coin);
        AddStage().SetExp((int)exp);
        
        int item_count = Random.Range(0, 4);
        if (item_count != 0)
        {
            for (int i = 1; i < item_count; i++)
            {
                int herb = Random.Range(12, 19);
                AddStage().SetItem(herb);
                PlayerManager.instance.AddItem(herb);
            }
        }
    }
    public void SetRewardUnit(List<Unit> units)
    {
        foreach (var item in units)
        { AddDamage(item); }
    }

    public void SetButton_Next()
    {
        ClearDamage();
        ClearStage();

        RewardPage.SetActive(false);
        SaveValueGame.Current_FightState = FightState.Wait;
        SaveValueGame.Current_GameState = GameState.Stage;

        CoroutineSound.Start_Coroutine(Clip_Next, SaveValuePlayer.Volume_Effect, false);
    }

    public void AddDamage(Unit unit)
    {
        GameObject ins = Instantiate(Pufab_ItemDamage, Scroll_Damage.content);
        List_Damage.Add(ins);

        UI_Fight_Reward_Item_Damage item = ins.GetComponent<UI_Fight_Reward_Item_Damage>();
        item.Init(unit);
    }
    public UI_Fight_Reward_Item_Stage AddStage()
    {
        GameObject ins = Instantiate(Pufab_ItemStage, Scroll_Stage.content);
        List_Stage.Add(ins);

        UI_Fight_Reward_Item_Stage item = ins.GetComponent<UI_Fight_Reward_Item_Stage>();
        return item;
    }

    public void ClearDamage()
    {
        for (int i = List_Damage.Count - 1; i >= 0; i--)
        {
            Destroy(List_Damage[i]);
        }
        List_Damage.Clear();
    }
    public void ClearStage()
    {
        for (int i = List_Stage.Count - 1; i >= 0; i--)
        {
            Destroy(List_Stage[i]);
        }
        List_Stage.Clear();
    }
}
