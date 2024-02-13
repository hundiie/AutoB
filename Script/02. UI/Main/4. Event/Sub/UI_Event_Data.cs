using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Event_Data : MonoBehaviour
{
    public bool[] EventCheck;

    private void Start()
    {
        EventCheck = new bool[ResourcesData._EventData.Count];
    }

    public bool CheckEvent(int id)
    {
        EventData data = ResourcesData.Get_EventData(id);

        if (data != null)
            return CheckEvent(data);

        return false;
    }
    public bool CheckEvent(EventData data)
    {
        if (data == null) return false;
        if (data.Infinite) return true;

        return !EventCheck[data.Id];
    }

    public void SetEvent(int id, bool value)
    {
        EventCheck[id] = value;
    }
}
