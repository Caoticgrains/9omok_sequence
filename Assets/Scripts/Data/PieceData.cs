using System;
using UnityEngine;

namespace Data
{
    public enum PlayerColor
    {
        Blue,
        Pink
    }
    
    [Serializable]
    public class PieceData
    {
        public PlayerColor color;
        public Sprite sprite;
    }
}