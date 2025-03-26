using System;
using UnityEngine;

public enum PlayerType { P1, P2 }

[Serializable]
public struct PieceData
{
    public Vector2Int pos;
    public PlayerType type;
    public bool isPlaced;
    
    public PieceData(Vector2Int pos, PlayerType type, bool isPlaced = false)
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