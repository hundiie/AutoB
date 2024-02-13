using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static void SetItem(Unit unit, int id)
    {
        ItemData data = ResourcesData.Get_ItemData(id);

        if (data != null)
            SetItem(unit, data);
    }
    public static void SetItem(Unit unit, ItemData data)
    {
        switch (data.Id)
        {
            case 0: Item_00(unit, data); break;
            case 1: Item_01(unit, data); break;
            case 2: Item_02(unit, data); break;
            case 3: Item_03(unit, data); break;
            case 4: Item_04(unit, data); break;
            case 5: Item_05(unit, data); break;
            case 6: Item_06(unit, data); break;
            case 7: Item_07(unit, data); break;
            case 8: Item_08(unit, data); break;
            case 9: Item_09(unit, data); break;
            case 10: Item_10(unit, data); break;
            case 11: Item_11(unit, data); break;
            case 12: Item_12(unit, data); break;
            case 13: Item_13(unit, data); break;
            case 14: Item_14(unit, data); break;
            case 15: Item_15(unit, data); break;
            case 16: Item_16(unit, data); break;
            case 17: Item_17(unit, data); break;
            case 18: Item_18(unit, data); break;
            case 19: Item_19(unit, data); break;
            default: break;
        }
    }
    public static void Item_00(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Hp / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Hp += value;
        unit.CurrentHp = unit.Stat.Hp;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[0, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_01(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Physic / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_Physic += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[1, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_02(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Magic / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_Magic += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[3, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_03(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Speed / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_Speed += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[5, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_04(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Defense_Armor / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Defense_Armor += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[6, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_05(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Defense_Resist / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Defense_Resist += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[7, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_06(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_CriticalChance += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[8, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_07(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_CriticalDamage += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[9, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_08(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Special_Absorb += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[10, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_09(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Special_MoveSpeed / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Special_MoveSpeed += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[12, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_10(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Attack_CriticalChance += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[8, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan, 1f, 1f);
    }
    public static void Item_11(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Attack_CriticalDamage += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[9, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan, 1f, 1f);
    }
    public static void Item_12(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Hp / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Hp += value;
        unit.CurrentHp = unit.Stat.Hp;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[0, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_13(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Physic / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Attack_Physic += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[1, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_14(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Magic / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Attack_Magic += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[3, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_15(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Attack_Speed / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Attack_Speed += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[5, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_16(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Defense_Armor / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Defense_Armor += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[6, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_17(Unit unit, ItemData data)
    {
        float value = (unit._UnitData.Status.Defense_Resist / 100f) * data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Defense_Resist += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[7, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_18(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Dynamic.Special_Absorb += value;
        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[10, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }
    public static void Item_19(Unit unit, ItemData data)
    {
        float value = data.Item_DescriptionValue[0];
        unit.AddStatus_Static.Attack_Magic += value;
        unit.AddStatus_Static.Special_DamageReduction -= 10000;

        Canvas_Main.instance._Fight._Damage.SetDamageText(unit, SaveData.LanguageData.Stat[3, SaveData.SaveValuePlayer.LanguageValue] + " + " + value, SaveData.ColorData.cyan_Light, 1f, 1f);
    }


    //public static string[,] Stat =
    //    {
    //        {"최대 체력","Max Health" },           // 0
    //        {"공격력", "Physic" },                 // 1
    //        {"물리 관통력", "PhysicPiercing" },    // 2
    //        {"마법력", "Magic" },                  // 3
    //        {"마법 관통력", "MagicPiercing" },     // 4
    //        {"공격 속도", "Attack Speed" },        // 5
    //        {"방어력", "Armor" },                  // 6
    //        {"마법 저항력", "Resist" },            // 7
    //        {"치명타 확률", "CriticalChance" },    // 8
    //        {"치명타 피해", "CriticalDamage" },    // 9
    //        {"체력 흡수", "Absorb" },              // 10
    //        {"공격 사거리", "Attack Range" },      // 11
    //        {"이동 속도", "Move Speed" },          // 12
    //        {"피해 감소", "DamageReduction" },     // 13
    //        {"피해 증가", "DamageIncrease" }       // 14
    //    };
}
