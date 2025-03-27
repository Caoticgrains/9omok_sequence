using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Component.Content
{
    public class Piece : MonoBehaviour
    {
        private PieceData _pieceData;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        public void Initialize(PieceData pieceData)
        {
            _pieceData = pieceData;
            _image.color = _pieceData.type == PlayerType.P1 ? Color.black : Color.white;
        }
    }
}