using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Fight_Inventory : MonoBehaviour
{
    private Animator _Animator_UpDown;

    [Header("Prefab")]
    public GameObject Prefab_Item;
    
    [Header("Up Down")]
    public Button Inven_Button_UpDown;

    [Header("Scroll")]
    public TextMeshProUGUI[] Text_Count;
    public Button[] Inven_Button;
    public ScrollRect[] Inven_Scroll;

    private int PrevSelection, CurrentSelection;

    private void Start()
    {
        _Animator_UpDown = GetComponent<Animator>();

        for (int i = 0; i < Inven_Scroll.Length; i++)
        {
            Inven_Scroll[i].gameObject.SetActive(false);
        }

        SetButton(0);
    }
    public void SetButton_UpDown()
    {
        _Animator_UpDown.SetBool("On", !_Animator_UpDown.GetBool("On"));
    }
    public void SetButton(int value)
    {
        PrevSelection = CurrentSelection;
        CurrentSelection = value;

        SetInventory();
    }
    public void SetInventory()
    {
        if (PrevSelection != CurrentSelection)
        {
            Inven_Button[PrevSelection].interactable = true;
            Inven_Scroll[PrevSelection].gameObject.SetActive(false);
        }
        
        Inven_Button[CurrentSelection].interactable = false;
        Inven_Scroll[CurrentSelection].gameObject.SetActive(true);
        Text_Count[CurrentSelection].text = Inven_Scroll[CurrentSelection].content.transform.childCount.ToString();
    }

    public void AddItem(int id)
    {
        ItemData data = ResourcesData.Get_ItemData(id);

        if (data != null)
            AddItem(data);
    }

    public void AddItem(ItemData data)
    {
        GameObject ins = Instantiate(Prefab_Item, Inven_Scroll[(int)data.Tag].content.transform);
        PlayerManager.instance.ItemList.Add(ins);

        if (Inven_Scroll[(int)data.Tag].gameObject.activeSelf)
            Text_Count[(int)data.Tag].text = Inven_Scroll[(int)data.Tag].content.transform.childCount.ToString();
        
        if (data.Tag == ItemTag.Unit)
            Canvas_Main.instance._GameOver.Data_info[0] += 1;
        else
            Canvas_Main.instance._GameOver.Data_info[3] += 1;

        ins.GetComponent<UI_Fight_Inventory_Item>().Init(data);
    }
}