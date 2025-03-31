using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Component.Board
{
    public class BoardUnit : MonoBehaviour
    {
        private Vector2Int _index;
        public Board _board;
        // board unit
        private Image _boardUnitImage;
        private Transform _boardUnitParent;
        private RectTransform _boardUnitRectTransform;

        public Owner owner;
        
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
        
        public void Initialize( Vector2Int index, 
            GameObject cardObject, CardData cardData, 
            GameObject pieceObject, PieceData pieceData,
            OnBoardUnitClicked onBoardUnitClicked)
        {
            this._index = index;
            this._cardData = cardData;
            this._pieceData = pieceData;
            this._onBoardUnitClickedDelegate = onBoardUnitClicked;
            
            _cardImage = cardObject.GetComponent<Image>();
            _cardImage.sprite = cardData.sprite;
            
            _pieceImage = pieceObject.GetComponent<Image>();
            _pieceImage.sprite = pieceData.sprite;
            
            // _selectorImage = go.GetComponent<Image>();
            // _selectorImage.sprite = cardData.sprite;
            // _selectorSprite = Resources.Load<Sprite>("Sprites/Pointer/position-selector");
        }
        
        private void OnMouseDown()
        {
            // UI component crash 
            if (EventSystem.current.IsPointerOverGameObject()) return;

            // call back 
            _onBoardUnitClickedDelegate?.Invoke();
        }

        public Vector2Int GetVec2Int()
        {
            return _index;
        }
        
        public void SetSelectUnitColor(Color color)
        {
            _cardImage.color = color;
        }

        public void SetSelectPlayerTurn(Owner owner)
        {
            switch (owner)
            {
                case Owner.P1:
                    // TODO: sprite가 변하는 상황
                    break;
                case Owner.P2:
                    // TODO: sprite가 변하는 상황
                    break;
                case Owner.None:
                    // TODO: sprite가 변하는 상황
                    break;
            }
        }

        // private Image _selectorImage;
        // private Transform _selectorParent;
        // private RectTransform _selectorRectTransform;
        
        public void OnSelect()
        {

            _selectorImage = _selectObject.GetComponent<Image>();
            _selectorImage.sprite = Resources.Load<Sprite>("Sprites/Pointer/position-selector");
        }
    }
}





// public void Initialize(Vector2Int index, bool isSelected, CardData cardData, PieceData pieceData, OnBoardUnitClicked onBoardUnitClicked)
// {
//     this._index = index;
//     this._cardData = cardData;
//     this._pieceData = pieceData;
//     this._onBoardUnitClickedDelegate = onBoardUnitClicked;
//     
//     _cardImage = GetComponent<Image>();
//     _cardImage.sprite = cardData.sprite;
//
//     _pieceImage = GetComponent<Image>();
//     _pieceImage.sprite = cardData.sprite;
//     
//     _selectorImage = GetComponent<Image>();
//     _selectorImage.sprite = cardData.sprite;
//     
// }