using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;
using System.Linq;

public enum Faction
{
    Player,
    Enamy
}
public enum TargetFaction
{
    /// <summary>
    /// 팀
    /// </summary>
    Allies,
    /// <summary>
    /// 적
    /// </summary>
    Enemies
}
public enum TargetMode
{
    /// <summary>
    /// 전체
    /// </summary>
    All,
    /// <summary>
    /// 본인
    /// </summary>
    Self,
    /// <summary>
    /// 평타 때리던 대상
    /// </summary>
    Target_Attack,
    /// <summary>
    /// 랜덤한
    /// </summary>
    Random,
    /// <summary>
    /// 가장 가까운
    /// </summary>
    MostNear,
    /// <summary>
    /// 가장 먼
    /// </summary>
    MostFar,
    /// <summary>
    /// 가장 체력이 많은
    /// </summary>
    MostHp,
    /// <summary>
    /// 가장 체력이 적은
    /// </summary>
    WorstHp,
}
public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    public List<Unit> Units_AllPlayer { get; set; } = new List<Unit>();
    public List<Unit> Units_AllEnamy { get; set; } = new List<Unit>();

    public List<Unit> Units_Player { get; set; } = new List<Unit>();
    public List<Unit> Units_Enamy { get; set; } = new List<Unit>();

    private void Awake()
    {
        instance = this;
    }
    public int xx = 1;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {   
            CreateUnit(new Vector3(Random.Range(0, SaveValue.MapSize_X), 0, Random.Range(0, SaveValue.MapSize_Z)), Faction.Player, xx);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            CreateUnit(new Vector3(Random.Range(0, SaveValue.MapSize_X), 0, Random.Range(0, SaveValue.MapSize_Z)), Faction.Enamy, xx);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveValueGame.Current_GameState = GameState.Gameover;
        }
    }
    // Create
    public bool CreateUnit(Vector3 vector, Faction faction, int id)
    {
        // 유닛 체크
        UnitData data_unit = ResourcesData.Get_UnitData(id);
        if (data_unit == null) return false;
        // 위치 체크
        TileData tile_Check = MapManager.instance.Get_Tile(vector);
        if (tile_Check == null) return false;
        else
        {
            // 타일 위 유닛 있는지 체크
            if (tile_Check.Unit_Object != null)
                return false;
        }
        GameObject ins = Instantiate(data_unit.Prefab_Unit, vector, Quaternion.identity, transform);

        Unit script = ins.AddComponent<Unit>();
        script.Init(faction, data_unit);

        MapManager.instance.SetTileUnit(vector, script);

        switch (faction)
        {
            case Faction.Player:
                {
                    Units_AllPlayer.Add(script);
                    Units_Player.Add(script);
                }
                break;
            case Faction.Enamy:
                {
                    Units_AllEnamy.Add(script);
                    Units_Enamy.Add(script);
                }
                break;
            default: break;
        }

        Canvas_Main.instance._Fight._Life.SetLife(script);

        return true;
    }
    // Target
    public List<Unit> GetTarget(Unit owner, TargetFaction faction, TargetMode mode)
    {
        Faction faction_Target = Faction.Player;

        if (faction == TargetFaction.Allies && owner._Faction == Faction.Enamy || faction == TargetFaction.Enemies && owner._Faction == Faction.Player)
            faction_Target = Faction.Enamy;

        List<Unit> unitList = new List<Unit>();

        switch (faction_Target)
        {
            case Faction.Player:
                {
                    unitList = Units_Player.ToList();

                    if (mode != TargetMode.All)
                    {
                        if (faction == TargetFaction.Allies)
                            unitList.Remove(owner);

                        Unit target = SearchTarget(owner, unitList, mode);
                        unitList.Clear();

                        if (target != null) unitList.Add(target);
                    }
                }
                break;
            case Faction.Enamy:
                {
                    unitList = Units_Enamy.ToList();

                    if (mode != TargetMode.All)
                    {
                        if (faction == TargetFaction.Allies)
                            unitList.Remove(owner);

                        Unit target = SearchTarget(owner, unitList, mode);
                        unitList.Clear();

                        if (target != null) unitList.Add(target);
                    }
                }
                break;
            default:
                break;
        }

        return unitList;
    }
    Unit SearchTarget(Unit script, List<Unit> unitList, TargetMode mode)
    {
        List<Unit> more = new List<Unit>();

        switch (mode)
        {
            case TargetMode.All: return null;
            case TargetMode.Self: return script;
            case TargetMode.Target_Attack: return script.Target_Attack;
            case TargetMode.Random: return unitList[Random.Range(0, unitList.Count)];
            case TargetMode.MostNear:
                {
                    int value = int.MaxValue;

                    foreach (var item in unitList)
                    {
                        if (item.IsDeath) continue;

                        int range = Support.Math.Get_Distance(script.transform.position, item.transform.position);

                        if (value > range)
                        {
                            value = range;

                            more.Clear();
                            more.Add(item);
                        }
                        else if (value == range)
                            more.Add(item);
                    }
                }
                break;
            case TargetMode.MostFar:
                {
                    int value = 0;

                    foreach (var item in unitList)
                    {
                        if (item.IsDeath) continue;

                        int range = Support.Math.Get_Distance(script.transform.position, item.transform.position);

                        if (value < range)
                        {
                            value = range;

                            more.Clear();
                            more.Add(item);
                        }
                        else if (value == range)
                            more.Add(item);
                    }
                }
                break;
            case TargetMode.MostHp:
                {
                    float value = 0;
                    Unit sc = null;

                    foreach (var item in unitList)
                    {
                        if (item.IsDeath) continue;

                        float hp = Support.Math.Get_ValueRate(item.CurrentHp, item.Stat.Hp, 100);

                        if (value < hp)
                        {
                            value = hp;
                            sc = item;
                        }
                    }
                    more.Add(sc);
                }
                break;
            case TargetMode.WorstHp:
                {
                    float value = float.MaxValue;
                    Unit sc = null;

                    foreach (var item in unitList)
                    {
                        if (item.IsDeath) continue;

                        float hp = Support.Math.Get_ValueRate(item.CurrentHp, item.Stat.Hp, 100);

                        if (value > hp)
                        {
                            value = hp;
                            sc = item;
                        }
                    }
                    more.Add(sc);
                }
                break;
            default: break;
        }

        if (more.Count == 0) return null;
        else if (more.Count == 1) return more[0];

        int rand = Random.Range(0, more.Count);
        return more[rand];
    }

    public List<Unit> GetRangeTarget(Unit target, float range)
    {
        Vector3 CubeRange = new Vector3(range, range, range);
        Collider[] col = Physics.OverlapBox(target.transform.position, CubeRange, Quaternion.identity, (1 << 6));

        List<Unit> back = new List<Unit>();

        for (int i = 0; i < col.Length; i++)
        {
            back.Add(col[i].GetComponent<Unit>());
        }

        return back;
    }

    // Remove
    public void Remove_FactionUnit(Unit owner)
    {
        switch (owner._Faction)
        {
            case Faction.Player: Units_Player.Remove(owner); break;
            case Faction.Enamy: Units_Enamy.Remove(owner); break;
            default: break;
        }
    }
    public void Remove_FactionAllUnit(Unit owner)
    {
        switch (owner._Faction)
        {
            case Faction.Player: Units_AllPlayer.Remove(owner); break;
            case Faction.Enamy: Units_AllEnamy.Remove(owner); break;
            default: break;
        }
    }
    // Clear
    public void Clear_EnamyUnit()
    {
        for (int i = Units_AllEnamy.Count - 1; i >= 0; i--)
        {
            Units_AllEnamy[i].Exit();
        }

        Units_AllEnamy.Clear();
        Units_Enamy.Clear();
    }

    // Stage
    public void Fight_Reward()
    {
        Clear_EnamyUnit();

        for (int i = Units_AllPlayer.Count - 1; i >= 0; i--)
        {
            if (Units_AllPlayer[i].IsDeath)
                Units_AllPlayer[i].Exit();
            else
                Units_AllPlayer[i].InitData();
        }
    }
    // 스테이지 데이터를 기반한 유닛 생성
    public void Create_StageUnit(int id)
    {
        StageData data = ResourcesData.Get_StageData(id);
        
        if (data != null)
            Create_StageUnit(data);
    }
    public void Create_StageUnit(StageData data)
    {
        for (int i = 0; i < data.UnitData.Length; i++)
        {
            Vector3 vec = data.UnitData[i].RandomVector ? new Vector3(Random.Range(SaveValue.MapSize_X / 2, SaveValue.MapSize_X), 0, Random.Range(0, SaveValue.MapSize_Z)) : data.UnitData[i].Vector;

            bool check = CreateUnit(vec, Faction.Enamy, data.UnitData[i].Id);
            
            if (!check && data.UnitData[i].RandomVector)
                i--;
        }
        MapManager.instance._StageData = data;
    }
}
