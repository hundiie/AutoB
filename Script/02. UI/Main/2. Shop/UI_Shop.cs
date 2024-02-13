using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SaveData;

public enum ShopTag
{
    All,
    Item_Nomal,
    Item_High,
    Unit,
}
public class UI_Shop : MonoBehaviour
{
    public GameObject Prefab_Item;
    public GameObject Content;

    [Header("Clip")]
    public AudioClip Clip_Sell_True;
    public AudioClip Clip_Sell_False;
    public AudioClip Clip_Back;

    List<GameObject> items = new List<GameObject>();

    int[] Tag_All = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 15, 16, 17, 18, 100, 101, 102, 103, 104, 105, 106 };
    int[] Tag_Item_Nomal = { 12, 13, 14, 15, 16, 17, 18 };
    int[] Tag_Item_High = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 15, 16, 17, 18 };
    int[] Tag_Unit = { 100, 101, 102, 103, 104, 105, 106 };

    public void Init()
    {
        int rand = Random.Range(0, System.Enum.GetValues(typeof(ShopTag)).Length);
        Canvas_Main.instance._Shop.SetShop((ShopTag)rand, 8);
    }
    public void Exit()
    {
        ClearItem();
        Canvas_Main.instance._Effect.SetEffect_Text(UI_Effect.EffectText.Sub, "", Color.white, 0.05f);
    }

    public void SetButton_Back()
    {
        Exit();
        SaveValueGame.Current_GameState = GameState.Stage;
        CoroutineSound.Start_Coroutine(Clip_Back, SaveValuePlayer.Volume_Effect, false);
    }

    public void CreateItem(int id)
    {
        ItemData data = ResourcesData.Get_ItemData(id);
        if (data != null)
            CreateItem(data);
    }
    public void CreateItem(ItemData data)
    {
        GameObject ins = Instantiate(Prefab_Item, Content.transform);
        items.Add(ins);

        UI_Shop_Item item = ins.GetComponent<UI_Shop_Item>();
        item.Init(data);
    }

    public void ClearItem()
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            Destroy(items[i]);
        }
        items.Clear();
    }

    public void SetShop(ShopTag tag, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int id = 0;
            switch (tag)
            {
                case ShopTag.All: id = Tag_All[Random.Range(0, Tag_All.Length)]; break;
                case ShopTag.Item_Nomal: id = Tag_Item_Nomal[Random.Range(0, Tag_Item_Nomal.Length)]; break;
                case ShopTag.Item_High: id = Tag_Item_High[Random.Range(0, Tag_Item_High.Length)]; break;
                case ShopTag.Unit: id = Tag_Unit[Random.Range(0, Tag_Unit.Length)]; break;
                default: break;
            }
            CreateItem(id);
        }
    }
}
