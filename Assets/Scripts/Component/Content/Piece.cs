using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Component.Content
{
    public enum PieceState
    {
        None, 
        Inactive, // Alpha 
        Active, // isPlaced
    }
    
    public class Piece : MonoBehaviour
    {
        private PieceState _state;
        private PieceData _pieceData;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        public void Initialize(PieceData pieceData)
        {
            _state = PieceState.None; // state
            _pieceData = pieceData;
  
            
            if (_image != null)
            {
                if(pieceData.type == ColorType.None) 
                    Debug.Log("NONE STATE");
                
                // TODO: 매개변수 살펴보기 
                if (pieceData.type == ColorType.P1)
                {
                    _image.sprite = Resources.Load<Sprite>("Sprites/Gem/Blue_gem");
                    _image.color *= 0.8f;
                }
                else if (pieceData.type == ColorType.P2)
                {
                    _image.sprite = Resources.Load<Sprite>("Sprites/Gem/Pink_gem");
                    _image.color *= 0.8f;
                }
            }
        }

        public void SetState(PieceState state)
        {
            _state = state;

            switch (_state)
            {
                case PieceState.None:
                    gameObject.SetActive(false);
                    break;
                case PieceState.Inactive:
                    gameObject.SetActive(true);
                    _image.color = new Color(1, 1, 1, 0.5f);
                    break;
                case PieceState.Active:
                    gameObject.SetActive(true);
                    _image.color = new Color(1, 1, 1, 1);
                    break;
            }
        }
    }
}