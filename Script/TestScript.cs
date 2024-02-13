using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [Multiline(3)] public string StringValue;

    public List<int> Value;

    private void Awake()
    {
        string a = StringValue;
        for (int i = 0; i < Value.Count; i++)
        {
            a = a.Replace($"({i})", $"{Value[i]}");
        }
        Debug.Log(a);
    }
}
