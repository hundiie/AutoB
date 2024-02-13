using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/StageSetting", order = int.MaxValue)]
public class StageData_Setting : ScriptableObject
{
    [System.Serializable]
    public class Array
    {
        public int[] array;
    }
    [SerializeField] private int _Id;
    [SerializeField] private Array[] _Floor_Nomal;

    [SerializeField] private Array[] _Floor_Elite;
    
    [SerializeField] private Array[] _Floor_Boss;

    public int Id { get { return _Id; } }
    public Array[] Floor_Nomal { get { return _Floor_Nomal; } }
    public Array[] Floor_Elite { get { return _Floor_Elite; } }
    public Array[] Floor_Boss { get { return _Floor_Boss; } }

}
