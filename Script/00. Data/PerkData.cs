using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Perk", order = int.MaxValue)]
public class PerkData : ScriptableObject
{
    [Header("Á¤º¸")]
    [SerializeField] private int _Id;
    [SerializeField] private string[] _Name;
    [SerializeField] private int _Color;
    [SerializeField][Multiline(3)] private string[] _Description;

    public int Id { get { return _Id; } }
    public string[] Name { get { return _Name; } }
    public int Color { get { return _Color; } }
    public string[] Description { get { return _Description; } }
}
