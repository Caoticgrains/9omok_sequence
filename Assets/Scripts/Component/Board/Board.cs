using System;
using System.Collections;
using System.Collections.Generic;
using Component.Board;
using Component.Content;
using Cysharp.Threading.Tasks;
using Data;
using Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Component.Board
{
    public enum Owner { None, P1, P2 }

    [Serializable]
    public class BoardTile
    {
        public Owner owner;
        public BoardUnit unit;

        public BoardTile(Owner owner, BoardUnit unit)
        {
            this.owner = owner;
            this.unit = unit;
        }
    }

    public class Board : MonoBehaviour
    {
        // turn
        private Owner _owner;

        // board tile 
        private BoardTile[,] _boardTileArr;

        // board size 
        private Vector2Int _boardSize = new Vector2Int(8, 8);

        // Transform 
        [SerializeField] private Transform boardParent;

        [SerializeField] private RectTransform boardPanelRectTransform;

        // P1, P2 button
        public Button[] selectedPieceButtons;

        // trigger
        private bool _isTrigger = true;
        private bool _isSelected;
        private bool _isPlaced;

        // card prefab setting
        private CardDeck _cardDeck;

        // piece prefab setting;
        private PieceFilter _pieceFilter;

        // Place card setting on board
        private Dictionary<Vector2Int, Card> _cardOnBoard = new();

        // Place Piece setting on board
        private Dictionary<Vector2Int, Piece> _pieceOnBoard = new();

        // delegate
        public delegate void OnBoardClicked(int row, int column);
        public OnBoardClicked OnBoardClickedDelegate;
        
        void Start()
        {
            PlayerSelected();

            CreateBoard();

            // 비동기 작업 실행 Update()기능 
            //RunAsyncUpdate().Forget();
        }

        private void OnDestroy()
        {
            _isTrigger = false;
        }

        // private async UniTask RunAsyncUpdate()
        // {
        //     while (_isTrigger)
        //     {
        //         // 프레임당 로직처리 
        //         transform.Translate(Vector3.right * Time.deltaTime);
        //
        //         // 다음 프레임까지 대기
        //         await UniTask.Yield(PlayerLoopTiming.Update);
        //     }
        // }

        public void PlayerSelected()
        {
            for (int i = 0; i < selectedPieceButtons.Length; i++)
            {
                int j = i;
                selectedPieceButtons[i].onClick.AddListener(() => OnSelectPlayer(j));
            }
        }

        public void CreateBoard()
        {
            _boardTileArr = new BoardTile[_boardSize.x, _boardSize.y];

            for (int i = 0; i < _boardSize.x; i++)
            {
                for (int j = 0; j < _boardSize.y; j++)
                {
                    // object
                    GameObject go = ObjectPoolManager.Instance.GetBoardCard();
                    go.name = $"Tile_{i}_{j}";
                    go.transform.position = new Vector3(j * 100f, -i * 100f, 0);
                    go.transform.SetParent(boardParent);

                    // null 
                    if (go == null)
                    {
                        Debug.LogError("Object Pool is empty!");
                        return;
                    }

                    // 2D Calculator
                    int row = i, column = j;
                    Vector2Int index = CalTileToV2Int(i, j);

                    // click event Add
                    go.AddComponent<BoxCollider2D>();


                    // card spawn
                    // SpawnCardOnTile(new Vector2Int(i, j));

                    // card data random get
                    int randomValue = UnityEngine.Random.Range(1, 20);
                    _cardDeck = ScriptableObject.CreateInstance<CardDeck>();
                    go.GetComponent<Image>().sprite = _cardDeck.cards[randomValue].sprite;

                    // closure issue
                    var i1 = i;
                    var j1 = j;

                    BoardUnit unit = go.AddComponent<BoardUnit>();
                    // unit.Initialize(new Vector2Int(i, j), _cardDeck.cards[randomValue], () =>
                    // {
                    //     Debug.Log("BoardUnit Setting event triggered");
                    //     //OnBoardClickedDelegate?.Invoke(i1, j1);
                    // });

                    // init
                    _boardTileArr[i, j] = new BoardTile(_owner, unit);
                   // CalTileGroupCenterInPanel(_boardTileArr, boardPanelRectTransform);
                }
            }
        }


        // private void SpawnCardOnTile(Vector2Int position)
        // {
        //     if (ObjectPoolManager.Instance == null) return;
        //
        //     Card card = ObjectPoolManager.Instance.GetBoardCard();
        //     
        //     card.transform.position = new Vector3(position.x, position.y, 0);
        //     card.gameObject.SetActive(true);
        //     
        //     int randomValue = UnityEngine.Random.Range(1, 20);
        //     _cardDeck = ScriptableObject.CreateInstance<CardDeck>();
        //     card.Initialize(_cardDeck.cards[randomValue]);
        //     
        //     _cardOnBoard[position] = card;
        // }




// void SpawnCards()
// {
//     foreach (CardData cardData in deck.cards)
//     {
//         GameObject newCard = Instantiate(cardPrefab, cardParent);
//         newCard.GetComponent<Card>().Setup(cardData);
//         activeCards.Add(newCard);
//     }
// }
//
        private Vector3 CalIndexToPos(int index)
        {
            int row = index / _boardSize.x;
            int column = index % _boardSize.x;
            return new Vector3(row * _boardSize.x, column * _boardSize.y, -2);
        }

        private Vector2Int CalTileToV2Int(int row, int column)
        {
            return new Vector2Int(row, column);
        }

        private int CalTileToIndex(int row, int column)
        {
            return row * _boardSize.x + column;
        }

        public void RayToBoard()
        {
            if (!_isSelected) return;

            if (Camera.main != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {

                    BoardUnit boardUnit = hit.transform.GetComponent<BoardUnit>();

                    if (boardUnit != null)
                    {
                        // int x = Mathf.RoundToInt(hit.collider.transform.position.x);
                        // int y = Mathf.RoundToInt(hit.collider.transform.position.y);

                        // int x = boardUnit.X;
                        // int y = boardUnit.Y;
                        //
                        // if (_boardTileArr[x, y].index == 0)
                        // {
                        //     if (Input.GetMouseButtonDown(0))
                        //     {
                        //         PlacePiece(x, y);
                        //     }
                        //
                        //     //curStoneArr.transform.position = new Vector3(x, y, -5f);
                        // }
                    }

                    if (Input.GetMouseButtonDown(0))
                    {
                        //CreateStone(stoneArr[_stoneIndex], x, y);
                    }

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

        // public void ReturnBoardData()
        // {
        //     // card
        //     foreach (Transform child in tileParent)
        //     {
        //         ObjectPoolManager.Instance.ReturnBoardCard(card);
        //     }
        //     
        //     
        //     
        //     // piece 
        //     foreach (Transform child in cardParent)
        //     {
        //         ObjectPoolManager.Instance.ReturnPiece(piece);
        //     }
        // }


        void CalTileGroupCenterInPanel(BoardTile[,] tiles, RectTransform panel)
        {
            Transform tile_0 = tiles[0, 0].unit.transform;
            Vector3 tile_0_position = tile_0.position;

            float totalWidth = tiles.Length > 0
                ? tiles.Length * tiles[0, 0].unit.GetComponent<RectTransform>().rect.width
                : 0;

            float totalHeight = tiles.Length > 0 ? tiles[0, 0].unit.GetComponent<RectTransform>().rect.height : 0;

            Vector3 groupOffset = new Vector3(totalWidth / 2, totalHeight / 2, 0);

            Vector3 panelCenter = panel.position
                                  + new Vector3(panel.rect.width / 2, panel.rect.height / 2, 0);

            Vector3 newGroupPosition = panelCenter - groupOffset;

            tile_0.position = newGroupPosition;

        }

    }

}

// void EndGame()
// {
//     // 게임 종료 처리
//     GameManager gameManager = FindObjectOfType<GameManager>();
//     GameManager.ReturnTilesAndCards();
//
//     Debug.Log("모든 타일과 카드를 반환했습니다!");
// }
    
// public void ResetObject(GameObject obj)
// {
//     obj.transform.position = Vector3.zero; // 위치 초기화
//     obj.transform.rotation = Quaternion.identity; // 회전 초기화
//     // 필요에 따라 추가 초기화 작업 (예: 애니메이션, 스프라이트 변경 등)
// }





    // public class CardComparer
    // {
    //     public static bool CompareCards(Card handCard, Card boardCard)
    //     {
    //         return handCard.GetData().content == boardCard.GetData().content;
    //     }
    // }
    //
    // public class PieceFilter
    // {
    //     public static bool CanPlacePiece(Tile tile, PieceData pieceData)
    //     {
    //         if (tile.HasPiece()) return false;  // 이미 놓인 경우 배치 불가
    //         return true;
    //     }
    // }
    //
    //
    // public class Piece : MonoBehaviour
    // {
    //     private PieceData pieceData;
    //
    //     public void SetData(PieceData data)
    //     {
    //         this.pieceData = data;
    //         GetComponent<SpriteRenderer>().color = (data.type == PlayerType.P1) ? Color.black : Color.white;
    //     }
    // }
    //
    //
    // public class Card : MonoBehaviour
    // {
    //     private CardData data;
    //
    //     public void SetData(CardData data)
    //     {
    //         this.data = data;
    //         GetComponent<SpriteRenderer>().sprite = data.sprite;
    //     }
    //
    //     public CardData GetData() => data;
    // }
    //
    // public class Tile : MonoBehaviour
    // {
    //     private Vector2Int index;
    //     private Card currentCard;
    //     private Piece currentPiece;
    //
    //     public void Init(Vector2Int index)
    //     {
    //         this.index = index;
    //     }
    //
    //     public void SetCard(Card card)
    //     {
    //         currentCard = card;
    //         card.transform.SetParent(transform, false);
    //     }
    //
    //     public void PlacePiece(Piece piece)
    //     {
    //         if (currentPiece != null) return;
    //         currentPiece = piece;
    //         piece.transform.SetParent(transform, false);
    //     }
    // }
    //
    // public class BoardManager : MonoBehaviour
    // {
    //     public GameObject tilePrefab;
    //     public Transform boardParent;
    //     private Tile[,] tiles = new Tile[8, 8];
    //
    //     void Start()
    //     {
    //         CreateBoard();
    //         SpawnCards();
    //     }
    //
    //     void CreateBoard()
    //     {
    //         for (int x = 0; x < 8; x++)
    //         {
    //             for (int y = 0; y < 8; y++)
    //             {
    //                 GameObject tileObj = Instantiate(tilePrefab, boardParent);
    //                 Tile tile = tileObj.GetComponent<Tile>();
    //                 tile.Init(new Vector2Int(x, y));
    //                 tiles[x, y] = tile;
    //             }
    //         }
    //     }
    //
    //     void SpawnCards()
    //     {
    //         foreach (Tile tile in tiles)
    //         {
    //             Card card = ObjectPool<Card>.Instance.Get();
    //             card.SetData(CardDeck.Instance.GetRandomCard());
    //             tile.SetCard(card);
    //         }
    //     }
    // }



    //
    // void SpawnBoardCard(Vector2Int pos, CardData cardData)
    // {
    //     Card card = ObjectPoolManager.Instance.GetBoardCard();
    //     card.transform.position = new Vector3(pos.x, pos.y, 0);
    //     card.Initialize(cardData);
    // }
    //
    //
    // void DrawCard(CardData cardData)
    // {
    //     Card card = ObjectPoolManager.Instance.GetHandCard();
    //     card.Initialize(cardData);
    // }
    //
    //
    //
    // void PlacePiece(Vector2Int pos, PlayerType player)
    // {
    //     Piece piece = ObjectPoolManager.Instance.GetPiece();
    //     piece.transform.position = new Vector3(pos.x, pos.y, 0);
    //     piece.Initialize(new PieceData(pos, player, true));
    // }
// private void PlacePiece(int x, int y)
    // {
    //     _boardTileArr[x, y].owner = 1; // _ownerType
    //     _boardTileArr[x, y].unit.GetComponent<SpriteRenderer>().color = Color.black;
    // }
    
    
    
    // private void CreateStone(GameObject stonePrefab, int x, int y)
    // {
    //     _isSelected = false;
    //     
    //     //Destroy(curStoneArr);
    //
    //     if (tileArr[x, y] == 0)
    //     {
    //         //curStoneArr = Instantiate(stonePrefab, new Vector3(x, y, -5f), Quaternion.identity);
    //         tileArr[x, y] = 1;
    //
    //         // curStoneArr = Instantiate(stonePrefab, this.transform);
    //         // curStoneArr.transform.position = new Vector3(x, 0, z);
    //         // tileArr[x, z] = 1;
    //     }
    // }
    //
    // private void OnSelectPlayer(int index)
    // {
    //     _isSelected = true;
    //     // _stoneIndex = index;
    //     // curStoneArr = prevStoneArr[index];
    //     // curStoneArr = Instantiate(curStoneArr, this.transform);
    // }
    //
    // public void OnChangePlayer(int index)
    // {
    //     // curStoneArr = stoneArr[index];
    // }
    
    
    
    // private Vector3 CalCardPos(int index)
    // {
    //     int row = index / _boardSize.x;
    //     int column = index % _boardSize.x;
    //     return new Vector3(row * _boardSize.x, column * _boardSize.y, -3f);
    // }