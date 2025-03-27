using System.Collections.Generic;
using Data;
using UnityEngine;

public class PieceFilter
{
    private Dictionary<Vector2Int, PieceData> pieceRegistry = new();

    public int PositionToIndex(Vector2Int position) => position.y * 8 + position.x;
    
    public Vector2Int IndexToPosition(int index) => new Vector2Int(index % 8, index / 8);
    
    public bool IsPositionPlaced(Vector2Int position) => pieceRegistry.ContainsKey(position);
    
    // inactive
    public bool SetPieceTemp(GameObject piece, PlayerType playerType, Vector2Int position)
    {
        if (IsPositionPlaced(position)) return false; // 이미 말이 놓여 있으면 배치 불가

        PieceData newPiece = new PieceData(position, playerType);
        pieceRegistry[position] = newPiece;

        // 오브젝트 위치 설정
        piece.transform.position = new Vector3(position.x, position.y, 0);
        piece.name = $"{playerType}_TEMP";

        // 반투명
        SpriteRenderer renderer = piece.GetComponent<SpriteRenderer>();
        
        if (renderer != null)
        {
            if (playerType == PlayerType.P1)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Gem/Blue_gem");
                renderer.color *= 0.5f;
            }
            else if (playerType == PlayerType.P2)
            {
                renderer.sprite = Resources.Load<Sprite>("Sprites/Gem/Red_gem");
                renderer.color *= 0.5f;
            }
        }
        
        Debug.Log($"임시 배치: {piece.name} / 위치: {position} / 인덱스: {PositionToIndex(position)}");
        
        return true;
    }

    // active
    public bool ConfirmPlacement(Vector2Int position)
    {
        if (!pieceRegistry.ContainsKey(position)) return false;

        PieceData confirmedPiece = pieceRegistry[position].SetPlaced();
        
        pieceRegistry[position] = confirmedPiece;

        Debug.Log($"배치 확정: {confirmedPiece.type} " +
                  $"/ 위치: {confirmedPiece.pos} " +
                  $"/ 인덱스: {PositionToIndex(confirmedPiece.pos)}");
        
        return true;
    }
    
    public bool RemovePiece(Vector2Int position)
    {
        if (!pieceRegistry.ContainsKey(position)) return false;

        pieceRegistry.Remove(position);
        Debug.Log($"삭제 : 위치 {position}");
        return true;
    }
}
