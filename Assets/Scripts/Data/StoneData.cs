using System;
using UnityEngine;

public enum StoneColor { Black, White }

[Serializable]
public struct StoneData
{
    public int index;
    public StoneColor color;
 
    public int X { get; set; }
    public int Y { get; set; }
}