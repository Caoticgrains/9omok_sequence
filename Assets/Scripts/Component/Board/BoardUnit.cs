using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoardUnit : MonoBehaviour
{
    private Vector2Int _boardIndex;
    
    private GameObject _cardObject;
    private Transform _cardParent;
    private Image _cardImage;
    private CardData _cardData;
    
    private GameObject _pieceObject;
    private Transform _pieceParent;
    private Image _pieceImage;
    private PieceData _pieceData;
    
    public delegate void OnBoardUnitClicked();
    private OnBoardUnitClicked _onBoardUnitClickedDelegate;
    
    public void Initialize(Vector2Int index, CardData cardData, OnBoardUnitClicked onBoardUnitClicked)
    {
        this._boardIndex = index;
        this._cardData = cardData;
        this._onBoardUnitClickedDelegate = onBoardUnitClicked;
        
        _cardImage = GetComponent<Image>();
        _cardImage.sprite = cardData.sprite;
        
        _pieceImage = GetComponent<Image>();
        _pieceImage.sprite = cardData.sprite;
        
    }
    
    private void OnMouseDown()
    {
        // UI component crash 
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        // call back 
        _onBoardUnitClickedDelegate?.Invoke();
        
        // raycast 
        //_board.RayToBoard();
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
}
