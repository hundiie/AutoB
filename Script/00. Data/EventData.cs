using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Event_Choice
{
    [System.Serializable]
    public struct array
    {
        [Multiline(7)] public string[] Array;
    }

    [Header("Head")]
    [SerializeField] private string[] _Text;
    
    [Header("Body")]
    [SerializeField] private array[] _Description;
    [SerializeField] private int[] _Chance;

    public string[] Text { get { return _Text; } }
    public array[] Description { get { return _Description; } }
    public int[] Chance { get { return _Chance; } }
}

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Event", order = int.MaxValue)]
public class EventData : ScriptableObject
{
    [Header("정보")]
    [SerializeField] private int _Id;
    [SerializeField] private string[] _Name;
    [SerializeField] private Sprite _Sprite;
    
    public int Id { get { return _Id; } }
    public string[] Name { get { return _Name; } }
    public Sprite Sprite { get { return _Sprite; } }

    [Header("내용")]
    [SerializeField][Multiline(7)] private string[] _Description;
    [SerializeField] private Event_Choice[] _Choice;

    public string[] Description { get { return _Description; } }
    public Event_Choice[] Choice { get { return _Choice; } }

    [Header("설정")]
    [SerializeField] private bool _Infinite;

    public bool Infinite { get { return _Infinite; } }
}
