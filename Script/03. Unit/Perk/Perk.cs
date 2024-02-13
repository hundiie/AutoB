using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    public static void SetPerk(Unit unit, int id)
    {
        PerkData data = ResourcesData.Get_PerkData(id);

        if (data != null)
            SetPerk(unit, data);
    }
    public static void SetPerk(Unit unit, PerkData data)
    {
        switch (data.Id)
        {
            case 0: Perk_00(unit); break;   // ưư�� ��
            case 1: Perk_01(unit); break;   // ���� ��  
            case 2: Perk_02(unit); break;   // ������ ��
            case 3: Perk_03(unit); break;   // ������ ��
            case 4: Perk_04(unit); break;   // �ȶ���
            case 5: Perk_05(unit); break;   // ��û��
            case 6: Perk_06(unit); break;   // ���� �ճ
            case 7: Perk_07(unit); break;   // ���� �ճ
            case 8: Perk_08(unit); break;   // ���� ��
            case 9: Perk_09(unit); break;   // ������ ��
            case 10: Perk_10(unit); break;  // ���� ���ŷ�
            case 11: Perk_11(unit); break;  // ���� ���ŷ�
            case 12: Perk_12(unit); break;  // ������ ��
            case 13: Perk_13(unit); break;  // ���ſ� ��
            case 14: Perk_14(unit); break;  // �� ��ȣ
            case 15: Perk_15(unit); break;  // �� ������
            case 16: Perk_16(unit); break;  // ������ ��
            case 17: Perk_17(unit); break;  // ���� �÷�
            case 18: Perk_18(unit); break;  // ������ ����
            case 19: Perk_19(unit); break;  // ����� ����
            case 20: Perk_20(unit); break;  // ����
            case 21: Perk_21(unit); break;  // ������ �밡
            case 22: Perk_22(unit); break;  // ���� �밡
            case 23: Perk_23(unit); break;  // �ð� ���
            case 24: Perk_24(unit); break;  // ����ٴ�
            case 25: Perk_25(unit); break;  // �ٶ��� �ູ
            case 26: Perk_26(unit); break;  // ������ ��
            case 27: Perk_27(unit); break;  // �ܷõ� ��ü
            case 28: Perk_28(unit); break;  // ������
            case 29: Perk_29(unit); break;  // �� �˷�����
            case 30: Perk_30(unit); break;  // �ο� ������
            case 31: Perk_31(unit); break;  // ���� ���
            case 32: Perk_32(unit); break;  // ��ġ�� ���
            case 33: Perk_33(unit); break;  // ������ ���
            case 34: Perk_34(unit); break;  // ǳ��
            case 35: Perk_35(unit); break;  // �糯�� ��
            default: break;
        }
    }

    public static void Perk_00(Unit unit)
    {
        unit.AddStatus_Dynamic.Hp += ((unit._UnitData.Status.Hp + unit.AddStatus_Static.Hp) / 100f) * 20f;
    }
    public static void Perk_01(Unit unit)
    {
        unit.AddStatus_Dynamic.Hp -= ((unit._UnitData.Status.Hp + unit.AddStatus_Static.Hp) / 100f) * 20f;
    }
    public static void Perk_02(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic += ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 20f;
    }
    public static void Perk_03(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic -= ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 20f;
    }
    public static void Perk_04(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Magic += ((unit._UnitData.Status.Attack_Magic + unit.AddStatus_Static.Attack_Magic) / 100f) * 20f;
    }
    public static void Perk_05(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Magic -= ((unit._UnitData.Status.Attack_Magic + unit.AddStatus_Static.Attack_Magic) / 100f) * 20f;
    }
    public static void Perk_06(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Speed += ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 20f;
    }
    public static void Perk_07(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Speed -= ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 20f;
    }
    public static void Perk_08(Unit unit)
    {
        unit.AddStatus_Dynamic.Defense_Armor += ((unit._UnitData.Status.Defense_Armor + unit.AddStatus_Static.Defense_Armor) / 100f) * 30f;
    }
    public static void Perk_09(Unit unit)
    {
        unit.AddStatus_Dynamic.Defense_Armor -= ((unit._UnitData.Status.Defense_Armor + unit.AddStatus_Static.Defense_Armor) / 100f) * 30f;
    }
    public static void Perk_10(Unit unit)
    {
        unit.AddStatus_Dynamic.Defense_Resist += ((unit._UnitData.Status.Defense_Resist + unit.AddStatus_Static.Defense_Resist) / 100f) * 30f;
    }
    public static void Perk_11(Unit unit)
    {
        unit.AddStatus_Dynamic.Defense_Resist -= ((unit._UnitData.Status.Defense_Resist + unit.AddStatus_Static.Defense_Resist) / 100f) * 30f;
    }
    public static void Perk_12(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_MoveSpeed += ((unit._UnitData.Status.Special_MoveSpeed + unit.AddStatus_Static.Special_MoveSpeed) / 100f) * 20f;
    }
    public static void Perk_13(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_MoveSpeed -= ((unit._UnitData.Status.Special_MoveSpeed + unit.AddStatus_Static.Special_MoveSpeed) / 100f) * 20f;
    }
    public static void Perk_14(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_Absorb += 10;
    }
    public static void Perk_15(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_Absorb -= 10;
    }
    public static void Perk_16(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_CriticalChance += 20;
    }
    public static void Perk_17(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_CriticalChance -= 20;
    }
    public static void Perk_18(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_CriticalDamage += 20;
    }
    public static void Perk_19(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_CriticalDamage -= 20;
    }
    public static void Perk_20(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic += ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 100f;
        unit.AddStatus_Dynamic.Attack_Speed += ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 100f;

        unit.AddStatus_Dynamic.Special_DamageReduction -= 200;
    }
    public static void Perk_21(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Magic += ((unit._UnitData.Status.Attack_Magic + unit.AddStatus_Static.Attack_Magic) / 100f) * 150f;

        unit.AddStatus_Dynamic.Attack_Physic -= 10000;
    }
    public static void Perk_22(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic += ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 250f;
        unit.AddStatus_Dynamic.Attack_Speed -= ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 33f;
        unit.AddStatus_Dynamic.Special_MissRate += 15;
    }
    public static void Perk_23(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_MissRate += 30;
    }
    public static void Perk_24(Unit unit)
    {
        unit.AddStatus_Dynamic.Hp += ((unit._UnitData.Status.Hp + unit.AddStatus_Static.Hp) / 100f) * 5f;
        unit.AddStatus_Dynamic.Attack_Physic += ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 5f;
        unit.AddStatus_Dynamic.Attack_Magic += ((unit._UnitData.Status.Attack_Magic + unit.AddStatus_Static.Attack_Magic) / 100f) * 5f;
        unit.AddStatus_Dynamic.Defense_Armor += ((unit._UnitData.Status.Defense_Armor + unit.AddStatus_Static.Defense_Armor) / 100f) * 5f;
        unit.AddStatus_Dynamic.Defense_Resist += ((unit._UnitData.Status.Defense_Resist + unit.AddStatus_Static.Defense_Resist) / 100f) * 5f;
    }
    public static void Perk_25(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic += ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 30f;
        unit.AddStatus_Dynamic.Attack_Speed += ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 30f;
    }
    public static void Perk_26(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Speed -= ((unit._UnitData.Status.Attack_Speed + unit.AddStatus_Static.Attack_Speed) / 100f) * 20f;
        unit.AddStatus_Dynamic.Special_MoveSpeed -= ((unit._UnitData.Status.Special_MoveSpeed + unit.AddStatus_Static.Special_MoveSpeed) / 100f) * 70f;
    }
    public static void Perk_27(Unit unit)
    {
        unit.AddStatus_Dynamic.Defense_Armor += ((unit._UnitData.Status.Defense_Armor + unit.AddStatus_Static.Defense_Armor) / 100f) * 30f;
        unit.AddStatus_Dynamic.Defense_Resist += ((unit._UnitData.Status.Defense_Resist + unit.AddStatus_Static.Defense_Resist) / 100f) * 30f;
    }
    public static void Perk_28(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_Absorb += 35;
        unit.AddStatus_Dynamic.Hp -= ((unit._UnitData.Status.Hp + unit.AddStatus_Static.Hp) / 100f) * 35f;
    }
    public static void Perk_29(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Physic -= ((unit._UnitData.Status.Attack_Physic + unit.AddStatus_Static.Attack_Physic) / 100f) * 15f;
        unit.AddStatus_Dynamic.Attack_Magic -= ((unit._UnitData.Status.Attack_Magic + unit.AddStatus_Static.Attack_Magic) / 100f) * 15f;
        unit.AddStatus_Dynamic.Special_Absorb -= 10000;
    }
    public static void Perk_30(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_DamageIncrease -= 20;
    }
    public static void Perk_31(Unit unit)
    {
        unit.AddStatus_Dynamic.Attack_Magic -= 10000;
    }
    public static void Perk_32(Unit unit)
    {
        unit.AddStatus_Dynamic.ExpRate += 20;
    }
    public static void Perk_33(Unit unit)
    {
        unit.AddStatus_Dynamic.ExpRate -= 20;
    }
    public static void Perk_34(Unit unit)
    {
        unit.AddStatus_Dynamic.Special_DamageIncrease += 25;
        unit.AddStatus_Dynamic.Special_DamageReduction -= 35;
    }
    public static void Perk_35(Unit unit)
    {

    }
}
