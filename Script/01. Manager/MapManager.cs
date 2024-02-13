using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveData;

public class TileData : MonoBehaviour
{
    public Unit Unit_Object;

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    public GameObject Prefab_Tile;

    public StageData _StageData;

    public TileData[,] Tile { get; private set; }

    private void Awake()
    {
        instance = this;

        Init();
    }
    void Init()
    {
        Tile = new TileData[SaveValue.MapSize_X, SaveValue.MapSize_Z];

        for (int i = 0; i < SaveValue.MapSize_X; i++)
        {
            for (int j = 0; j < SaveValue.MapSize_Z; j++)
            {
                GameObject ins = Instantiate(Prefab_Tile, new Vector3(i, 0, j), Quaternion.identity, transform);
                ins.name = $"Tile {i} : {j}";

                TileData data = ins.AddComponent<TileData>();
                Tile[i, j] = data;
            }
        }
    }
    // Get
    public TileData Get_Tile(int x, int z)
    {
        if (x < 0 || z < 0 || x >= SaveValue.MapSize_X || z >= SaveValue.MapSize_Z)
            return null;

        return Tile[x, z];
    }
    public TileData Get_Tile(Vector3 vector)
    {
        Vector3 round = Support.Vector.Get_RoundVector(vector);

        if (round.x < 0 || round.z < 0 || round.x >= SaveValue.MapSize_X || round.z >= SaveValue.MapSize_Z)
            return null;

        return Tile[(int)round.x, (int)round.z];
    }

    public void SetTileUnit(Vector3 vector, Unit unit)
    {
        Vector3 round = Support.Vector.Get_RoundVector(vector);

        if (round.x < 0 || round.z < 0 || round.x >= SaveValue.MapSize_X || round.z >= SaveValue.MapSize_Z)
            return;

        Tile[(int)round.x, (int)round.z].Unit_Object = unit;
    }
}

