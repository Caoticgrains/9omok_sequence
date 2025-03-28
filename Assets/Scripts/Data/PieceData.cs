using System;
using UnityEngine;

namespace Data
{
    public enum ColorType
    {
        None,
        P1,
        P2
    }
    
    [Serializable]
    public struct PieceData
    {
        public Vector2Int pos;
        public ColorType type;
        public bool isPlaced;

        public PieceData(Vector2Int pos, ColorType type, bool isPlaced = false)
        {
            this.pos = pos;
            this.type = type;
            this.isPlaced = isPlaced;
        }

        public PieceData SetPlaced()
        {
            return new PieceData(pos, type, true);
        }

    }
}