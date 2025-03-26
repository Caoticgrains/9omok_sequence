using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Owner { None, P1, P2 }

[Serializable]
public class BoardTile
{
    public Owner owner;   
    public BoardUnit unit;
}

public partial class Board : MonoBehaviour
{
    // turn
    private Owner _owner;
    
    // board tile 
    private BoardTile[,] _boardTileArr;
    
    // board size 
    private Vector2Int _boardSize = new Vector2Int(8,8);
    
    // Transform 
    [SerializeField] private Transform boardParent;
    
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
    
    // card setting on board
    private Dictionary<Vector2Int, GameObject> _cardOnBoard = new Dictionary<Vector2Int, GameObject>();
    
    // Piece setting on board
    private Dictionary<Vector2Int, GameObject> _pieceOnBoard = new Dictionary<Vector2Int, GameObject>();
    
    // delegate
    public delegate void OnBoardClicked(int row, int column);
    public OnBoardClicked OnBoardClickedDelegate;
    
    // ObjectPool
    
    
    void Start()
    {
        CreateBoard();
        
        // 비동기 작업 실행 Update()기능 
        RunAsyncUpdate().Forget();
    }

    private void OnDestroy()
    {
        _isTrigger = false;
    }
    
    private async UniTask RunAsyncUpdate()
    {
        while (_isTrigger)
        {
            // 프레임당 로직처리 
            transform.Translate(Vector3.right * Time.deltaTime);

            // 다음 프레임까지 대기
            await UniTask.Yield(PlayerLoopTiming.Update);
        }
    }
    
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
        // tile array init
        _boardTileArr = new BoardTile[_boardSize.x, _boardSize.y];
        
        for (int i = 0; i < _boardSize.x; i++)
        {
            for (int j = 0; j < _boardSize.y; j++)
            {
                // init
                _boardTileArr[i, j] = new BoardTile
                {
                    owner = Owner.None,
                    unit = null
                };
                
                // object
                GameObject go = new GameObject($"Tile_{i}_{j}");
                go.transform.SetParent(boardParent);
                go.transform.position = new Vector3(i * 100f, j * 100f, 0);
                
                // null 
                if (go == null)
                {
                    Debug.LogError("Object Pool is empty!");
                    return;
                }
                
                // 2D
                int row = i, column = j;
                Vector2Int index = CalTileToV2Int(i, j);

                // click event
                go.AddComponent<BoxCollider2D>();
               
                // card spawn
                SpawnCardOnTile(new Vector2Int(i, j));
                
                // card data random get
                int randomValue = UnityEngine.Random.Range(1, 20);
                _cardDeck = ScriptableObject.CreateInstance<CardDeck>();
                go.GetComponent<Image>().sprite = _cardDeck.cards[randomValue].sprite;
                
                // closure issue
                var i1 = i;
                var j1 = j;
                
                // 
                _boardTileArr[i, j].unit.Initialize(index, _cardDeck.cards[randomValue], () =>
                {
                    Debug.Log("event triggered");
                    _boardTileArr[i1, j1].owner = _owner;
                    _boardTileArr[i1, j1].unit = go.AddComponent<BoardUnit>();
                    OnBoardClickedDelegate?.Invoke(i1, j1);
                });
            }
        }
    }


    
    
// void SpawnBoardCards()
// {
//     for (int i = 0; i < 8; i++)
//     {
//         for (int j = 0; j < 8; j++)
//         {
//             Vector3 position = new Vector3(i * 2, j * 2, 0); // 타일맵에서 위치를 가져다가 넘긴다. 
//             GameObject newCard = objectPool.GetObj();
//             //newCard.GetComponent<CardData>().SetCardValue(board[i, j]);
//
//             _cardObjects[new Vector2Int(i, j)] = newCard;
//         }
//     }
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

        // 여기서 인덱스도 찾아야 한다. 
        // 
        
        var clickedRow = playerIndex / 3;
        var clickedColumn = playerIndex % 3;
        
        OnBoardClickedDelegate?.Invoke(clickedRow, clickedColumn);
    }
    
}

//public void ReturnTilesAndCards()
//{
    // 타일 반환
    // foreach (Transform child in tileParent)
    // {
    //     tilePool.ReturnObj(child.gameObject);
    // }
    //
    // // 카드 반환
    // foreach (Transform child in cardParent)
    // {
    //     cardPool.ReturnObj(child.gameObject);
    // }
//}
    
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
