using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Component.Board;
using Cysharp.Threading.Tasks;
using Data;
using Manager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Component.Board
{
    public enum Owner
    {
        None,
        P1,
        P2
    }

    public class Board : MonoBehaviour
    {
        // Tile 
        private Owner _owner;
        private BoardUnit _unit;

        // board tile Array
        public BoardUnit[,] boardUnits;

        // board size 
        private Vector2Int _boardSize = new Vector2Int(8, 8);

        // Transform 
        [SerializeField] private Transform boardCardParent;
        [SerializeField] private Transform boardPieceParent;

        // P1, P2 button
        public Button[] selectedPieceButtons;

        // trigger
        private bool _isTrigger = true;
        private bool _isSelected;
        private bool _isPlaced;

        // piece prefab setting;
        private PieceFilter _pieceFilter;

        // data
        private Dictionary<Vector2Int, GameObject> _cardOnBoard = new();
        private Dictionary<Vector2Int, GameObject> _pieceOnBoard = new();

        private List<int> _cards = new();

        void Start()
        {
            PlayerSelected();
            CreateBoard();
        }

        private void OnDestroy()
        {
            _isTrigger = false;
        }

        public void PlayerSelected()
        {
            for (int i = 0; i < selectedPieceButtons.Length; i++)
            {
                int j = i;
                selectedPieceButtons[i].onClick.AddListener(() => OnSelectPlayer(j));
            }
        }

        private Vector3 CalculateBoardPosition(Vector2Int position, Transform parent)
        {
            return new Vector3(
                parent.transform.position.x + position.y * 100f - (_boardSize.x * 50f),
                parent.transform.position.y + -position.x * 100f + (_boardSize.y * 50f),
                0
            );
        }

        private CardData GetRandomCardData(Vector2Int position)
        {
            if (position is { x: 0, y: 0 } ||
                position is { x: 0, y: 7 } ||
                position is { x: 7, y: 0 } ||
                position is { x: 7, y: 7 })
                return CardFilter.cards[UnityEngine.Random.Range(20, 21)];
            
            int randomIndex = UnityEngine.Random.Range(0, _cards.Count);
            int randomValue = _cards[randomIndex];
            _cards.RemoveAt(randomIndex);
            return CardFilter.cards[randomValue];
        }

        public BoardUnit CreateBoardUnit(Vector2Int position)
        {
            GameObject cardObject = ObjectPoolManager.Instance.GetBoardCard();
            cardObject.name = $"Card_{position.x}_{position.y}";
            cardObject.transform.position = CalculateBoardPosition(position, boardCardParent);
            cardObject.transform.SetParent(boardCardParent);

            GameObject pieceObject = ObjectPoolManager.Instance.GetPiece();
            pieceObject.name = $"Piece_{position.x}_{position.y}";
            pieceObject.transform.position = CalculateBoardPosition(position, boardPieceParent);
            pieceObject.transform.SetParent(boardPieceParent);

            if (_owner == Owner.None)
            {
                pieceObject.SetActive(false);
            }

            CardData cardData = GetRandomCardData(position);

            BoardUnit unit = cardObject.GetOrAddComponent<BoardUnit>();

            unit.Initialize(position, cardObject, cardData, pieceObject, () => { Debug.Log("onBoardUnitClicked"); });

            _cardOnBoard[position] = cardObject;
            _pieceOnBoard[position] = pieceObject;

            return unit;
        }

        public void CreateBoard()
        {
            if (_isSelected == false)
                _owner = Owner.None;
            
            _cards.Clear(); 
            for (int i = 1; i < 16; i++)
            for (int j = 0; j < 4; j++)
                _cards.Add(i);

            boardUnits = new BoardUnit[_boardSize.x, _boardSize.y];

            for (int i = 0; i < _boardSize.x; i++)
            {
                for (int j = 0; j < _boardSize.y; j++)
                {
                    Vector2Int position = new Vector2Int(i, j);
                    BoardUnit boardUnit = CreateBoardUnit(position);
                    boardUnits[i, j] = boardUnit;
                }
            }
        }

        private void OnSelectPlayer(int playerIndex)
        {
            _isSelected = true;

            if (playerIndex == 0)
            {
                _owner = Owner.P1;
            }
            else // if (playerIndex == 1)
            {
                _owner = Owner.P2;
            }

            Debug.Log($"플레이어 {playerIndex + 1} 선택됨");
        }
    }
}