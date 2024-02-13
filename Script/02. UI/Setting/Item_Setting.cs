using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Setting : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI Text_Head;
    public TextMeshProUGUI Text_Body;
    public Button Button_Left;
    public Button Button_Right;

    [Header("Value")]
    private int _Value;
    public string[] StringValue;

    public int Value
    {
        get { return _Value; }
        set
        {
            int SetValue = value;

            if (SetValue >= 0)
                SetValue %= StringValue.Length;
            else
                SetValue = StringValue.Length - 1;

            Text_Body.text = StringValue[SetValue];
            _Value = SetValue;
        }
    }

    public void SetButton_Left()
    {
        Value -= 1;
    }
    public void SetButton_Right()
    {
        Value += 1;
    }
}
