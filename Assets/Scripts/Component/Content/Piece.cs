using Data;
using UnityEngine;


namespace Component.Content
{



    public class Piece : MonoBehaviour
    {
        private PieceData _pieceData;
        private SpriteRenderer _spriteRenderer;
        private PieceFilter _filter;

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
}