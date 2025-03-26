using UnityEngine;

public class Piece : MonoBehaviour
{
    private PieceData _pieceData;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(PieceData pieceData)
    {
        _pieceData = pieceData;
        _spriteRenderer.color = _pieceData.type == PlayerType.P1 ? Color.black : Color.white;
    }
}
