using System;
using Data;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Component.Board
{
    public class BoardUnit : MonoBehaviour
    {
        public Owner owner;
        

        
        private Vector2Int _index;
        public Board _board;
        // board unit
        private Image _boardUnitImage;
        private Transform _boardUnitParent;
        private RectTransform _boardUnitRectTransform;

        // selector
        private GameObject _selectObject;
        private Image _selectorImage;
        private Transform _selectorParent;
        private RectTransform _selectorRectTransform;
        private Sprite _selectorSprite;
        
        // card
        private CardData _cardData;
        private Image _cardImage;
        private Transform _cardParent;
        private RectTransform _cardRectTransform;
        
        // piece
        private GameObject _pieceGameObject;
        private PieceData _pieceData;
        private Image _pieceImage;
        private Transform _pieceParent;
        private RectTransform _pieceRectTransform;
        
        // delegate
        public delegate void OnBoardUnitClicked();
        private OnBoardUnitClicked _onBoardUnitClickedDelegate;
        
        // active
        private bool IsActiveBoardUnit { get; set; }
        private bool IsActiveSelector { get; set; }
        private bool IsActivePiece { get; set; }
        private bool IsActiveCard { get; set; }


        private void Start()
        {
            Button button = GetComponent<Button>();
            button.onClick.AddListener(OnClicked);
            
        }


        public void Initialize( Vector2Int index, 
            GameObject cardObject, CardData cardData, 
            GameObject pieceObject,
            OnBoardUnitClicked onBoardUnitClicked)
        {
            this.owner = Owner.None;
            this._index = index;
            this._cardData = cardData;
            this._onBoardUnitClickedDelegate = onBoardUnitClicked;
            
            _cardImage = cardObject.GetComponent<Image>();
            _cardImage.sprite = cardData.sprite;
            
            _pieceImage = pieceObject.GetComponent<Image>();
            _pieceGameObject = pieceObject;
        }
        
        public void OnClicked()
        {
            GameManager.Instance.SelectBoardUnit(this);
        }

        public Vector2Int GetVec2Int()
        {
            return _index;
        }
        
        public void SetSelectUnitColor(Color color)
        {
            _cardImage.color = color;
        }

        public void SetSelectPlayer(Owner owner)
        {
            this.owner = owner;
            
            switch (owner)
            {
                case Owner.P1:
                    _pieceImage.sprite = Resources.Load<Sprite>("Sprites/Gem/Blue_gem");
                    break;
                case Owner.P2:
                    _pieceImage.sprite = Resources.Load<Sprite>("Sprites/Gem/Pink_gem");
                    break;
                case Owner.None:
                    break;
            }
            
            _pieceGameObject.SetActive(true);
        }
    }
}
