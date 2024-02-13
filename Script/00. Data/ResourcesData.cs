using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesData : MonoBehaviour
{
    public static List<CharacterData> _CharacterData = new List<CharacterData>();
    public static List<ItemData> _ItemData = new List<ItemData>();
    public static List<UnitData> _UnitData = new List<UnitData>();
    public static List<PerkData> _PerkData = new List<PerkData>();
    public static List<SkillData> _SkillData = new List<SkillData>();
    public static List<StageData> _StageData = new List<StageData>();
    public static List<StageData_Setting> _StageSetting = new List<StageData_Setting>();
    public static List<EventData> _EventData = new List<EventData>();

    public static List<GameObject> _Particle = new List<GameObject>();
    public static List<AudioClip> _AudioClip = new List<AudioClip>();

    private void Awake()
    {
        if (_CharacterData.Count == 0)
            _CharacterData = Resources.LoadAll("Character", typeof(CharacterData)).OfType<CharacterData>().ToList();
        if (_ItemData.Count == 0)
            _ItemData = Resources.LoadAll("Item", typeof(ItemData)).OfType<ItemData>().ToList();
        if (_UnitData.Count == 0)
            _UnitData = Resources.LoadAll("Unit", typeof(UnitData)).OfType<UnitData>().ToList();
        if (_PerkData.Count == 0)
            _PerkData = Resources.LoadAll("Perk", typeof(PerkData)).OfType<PerkData>().ToList();
        if (_SkillData.Count == 0)
            _SkillData = Resources.LoadAll("Skill", typeof(SkillData)).OfType<SkillData>().ToList();
        if (_StageData.Count == 0)
            _StageData = Resources.LoadAll("Stage", typeof(StageData)).OfType<StageData>().ToList();
        if (_StageSetting.Count == 0)
            _StageSetting = Resources.LoadAll("StageSetting", typeof(StageData_Setting)).OfType<StageData_Setting>().ToList();
        if (_EventData.Count == 0)
            _EventData = Resources.LoadAll("Event", typeof(EventData)).OfType<EventData>().ToList();

        if (_Particle.Count == 0)
            _Particle = Resources.LoadAll("Particle", typeof(GameObject)).OfType<GameObject>().ToList();
        if (_AudioClip.Count == 0)
            _AudioClip = Resources.LoadAll("Audio", typeof(AudioClip)).OfType<AudioClip>().ToList();
    }
    public static CharacterData Get_CharacterData(int id)
    {
        foreach (var data in _CharacterData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static ItemData Get_ItemData(int id)
    {
        foreach (var data in _ItemData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static UnitData Get_UnitData(int id)
    {
        foreach (var data in _UnitData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static PerkData Get_PerkData(int id)
    {
        foreach (var data in _PerkData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static SkillData Get_SkillData(int id)
    {
        foreach (var data in _SkillData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static StageData Get_StageData(int id)
    {
        foreach (var data in _StageData)
            if (data.Id == id) { return data; }
        return null;
    }
    public static StageData_Setting Get_StageSetting(int id)
    {
        foreach (var data in _StageSetting)
            if (data.Id == id) { return data; }
        return null;
    }
    public static EventData Get_EventData(int id)
    {
        foreach (var data in _EventData)
            if (data.Id == id) { return data; }
        return null;
    }

    public static GameObject Get_Particle(int id)
    {
        if (0 > id || id >= _Particle.Count)
            return null;
        return _Particle[id];
    }
}
