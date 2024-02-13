using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Fight_Reward_Item_Damage : MonoBehaviour
{
    public Image Icon_Sprite;
    public Image Icon_Death;
    public TextMeshProUGUI Text_Name;
    public TextMeshProUGUI[] Text_Damage;

    public void Init(Unit unit)
    {
        for (int i = 0; i < Text_Damage.Length; i++)
        {
            Text_Damage[i].color = SaveData.SaveValuePlayer.DamageColor[i];
        }

        SetItem(unit);
    }

    public void SetItem(Unit unit)
    {
        Icon_Sprite.sprite = unit._UnitData.Sprite;
        Icon_Death.gameObject.SetActive(unit.IsDeath);

        Text_Name.text = unit.Name;

        for (int i = 0; i < Text_Damage.Length; i++)
        {
            Text_Damage[i].text = ((int)unit.Damage_Deal[i]).ToString();
        }
    }
}
