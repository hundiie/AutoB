using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StageData_Unit
{
    [SerializeField] private int _Id;
    [SerializeField] bool _RandomVector;
    [SerializeField] private Vector3 _Vector;

    public int Id { get { return _Id; } }
    public bool RandomVector { get { return _RandomVector; } }
    public Vector3 Vector
    {
        get
        {
            Vector3 vec = new Vector3 ((SaveData.SaveValue.MapSize_X - 1) - _Vector.x, 0, _Vector.z >= SaveData.SaveValue.MapSize_Z ? SaveData.SaveValue.MapSize_Z - 1 : _Vector.z);
            return vec;
        }
    }
}

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Stage", order = int.MaxValue)]
public class StageData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private int _Id;

    [SerializeField] private StageData_Unit[] _UnitData;
    public int Id { get { return _Id; } }
    public StageData_Unit[] UnitData { get { return _UnitData; } }

    [Header("드랍")]
    [SerializeField] private float _Coin;
    [SerializeField] private float _Exp;
    [SerializeField] private ItemData[] _DropItem;

    public float Exp { get { return _Exp; } }
    public float Coin { get { return _Coin; } }
    public ItemData[] DropItem { get { return _DropItem; } }
}
