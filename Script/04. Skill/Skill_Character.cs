using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;
using System.Linq;

public class Skill_Character : MonoBehaviour
{
    public static void SetSkill(int value, Unit target)
    {
        // ��ų ��� ��������
        CharacterData data = ResourcesData._CharacterData[SaveValueGame.CharacterId];

        bool Check = false;
        string errorText = "";

        float[] skill_value = new float[data.Skills[value].DescriptionValue.Length];
        for (int i = 0; i < skill_value.Length; i++)
        { skill_value[i] = data.Skills[value].DescriptionValue[i] + (data.Skills[value].DescriptionValue_Upgrade[i] * SaveValueOutPlayer.Character_SkillLevel[data.Id, value]); }
        
        switch (data.Id)
        {
            case 0: // Warrior
                {
                    switch (value)
                    {
                        case 0:
                            {
                                if (target == null || target._Faction == Faction.Player)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;
                                
                                EffectDamage ef = new EffectDamage(DamageType.Physic, skill_value[0], 0);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                // ����Ʈ
                                CoroutineVFX.Start_Coroutine(target, data.Skills[value].FX, false, true);

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        case 1:
                            {
                                if (target == null || target._Faction == Faction.Enamy)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                EffectAddLife ef = new EffectAddLife(0, skill_value[0], 0);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                // ����Ʈ
                                CoroutineVFX.Start_Coroutine(target, data.Skills[value].FX, true);

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        case 2:
                            {
                                if (target == null || target._Faction == Faction.Player)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;
                                
                                // ���� �� ���ݷ�
                                UnitStatus status = new UnitStatus();
                                status.Attack_Physic -= skill_value[1];
                                // ���� �ð�
                                EffectAddStatus ef = new EffectAddStatus(status, skill_value[0]);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                // ����Ʈ
                                CoroutineVFX.Start_Coroutine(target, data.Skills[value].FX, false, true);

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        default: break;
                    }
                }
                break;
            case 1: // Wizard
                {
                    switch (value)
                    {
                        case 0:
                            {
                                Check = true;

                                List<Unit> units = UnitManager.instance.Units_Enamy.ToList();

                                while (units.Count > 3)
                                {
                                    units.RemoveAt(Random.Range(0, units.Count));
                                }

                                for (int i = 0; i < units.Count; i++)
                                {
                                    EffectDamageOverTime ef = new EffectDamageOverTime(DamageType.Magic, skill_value[1], 0, skill_value[0], 1);
                                    ef.setting(null, 0, 1);
                                    units[i].AddEffect(ef, EffectTrigger.Immediate_Self);

                                    CoroutineVFX.Start_Coroutine(units[i], data.Skills[value].FX, true);
                                }

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);

                            }
                            break;
                        case 1:
                            {
                                if (target == null || target._Faction == Faction.Enamy)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                // �ø� ����
                                EffectAddLife ef = new EffectAddLife(0, 0, skill_value[0]);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                                
                                // ����Ʈ
                                CoroutineVFX.Start_Coroutine(target, data.Skills[value].FX, true);

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        case 2:
                            {
                                if (target == null || target._Faction == Faction.Player)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                // ���� ����
                                EffectAddLife ef = new EffectAddLife(0, 0, -skill_value[0]);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);

                                // ����Ʈ
                                CoroutineVFX.Start_Coroutine(target, data.Skills[value].FX, true);

                                // ����
                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);

                            }
                            break;
                        default: break;
                    }
                }
                break;
            case 2: // Support
                {
                    switch (value)
                    {
                        case 0:
                            {
                                if (target == null || target._Faction == Faction.Enamy)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                // ���� ü��
                                EffectAddLife ef = new EffectAddLife(skill_value[0], 0, 0);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        case 1:
                            {
                                if (target == null || target._Faction == Faction.Enamy)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                // ���ݷ� ����
                                UnitStatus status = new UnitStatus();
                                status.Attack_Physic += skill_value[1];
                                // ���� �ð�
                                EffectAddStatus ef = new EffectAddStatus(status, skill_value[0]);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        case 2:
                            {
                                if (target == null || target._Faction == Faction.Enamy)
                                {
                                    errorText = LanguageData.Skill_FailedText[3, SaveValuePlayer.LanguageValue]; break;
                                }
                                Check = true;

                                // ������ ����
                                UnitStatus status = new UnitStatus();
                                status.Attack_Magic += skill_value[1];
                                // ���� �ð�
                                EffectAddStatus ef = new EffectAddStatus(status, skill_value[0]);
                                ef.setting(null, 0, 1);
                                target.AddEffect(ef, EffectTrigger.Immediate_Self);

                                if (data.Skills[value].SkillClip != null)
                                    CoroutineSound.Start_Coroutine(data.Skills[value].SkillClip, SaveValuePlayer.Volume_Effect);
                            }
                            break;
                        default: break;
                    }
                }
                break;
            default: break;
        }

        if (Check)
            Canvas_Main.instance._Fight._Skill.Skill_Success(value);
        else
            Canvas_Main.instance._Fight._Skill.Skill_Failed(value, errorText);
    }
}
