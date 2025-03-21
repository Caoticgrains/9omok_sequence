using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Tile
{
    public int owner;
    public GameObject tileObject;
}

// 타일 : Index, PlayerInfo == stone, CardInfo, 

public partial class Board : MonoBehaviour
{
    // 타일 
    public Tile[,] tileArr;
    
    // 보드 유닛 세팅 
    [SerializeField] private GameObject _boardUnitPrefab;
    [SerializeField] private Transform _parentTransform;
    private Vector2Int _boardSize = new Vector2Int(8,8);
    private TMP_Text _boardUnitIndexText;
    
    // 버튼
    public Button[] selectedStoneButtons;
    
    // 트리거 
    private bool _isSelected;
    
    void Start()
    {
        for (int i = 0; i < selectedStoneButtons.Length; i++)
        {
            int j = i;
            selectedStoneButtons[i].onClick.AddListener(() => OnSelectPlayer(j));
        }
    }
    
    public void CreateBoard()
    {
        // 한번만 호출 
        // 기존 타일이 있다면 초기화 
        foreach (Transform child in _parentTransform)
        {
            Destroy(child.gameObject);
        }
        
        tileArr = new Tile[_boardSize.x, _boardSize.y];
        
        float tileSpacing = 100f;
        
        for (int x = 0; x < _boardSize.x; x++)
        {
            for (int y = 0; y < _boardSize.y; y++)
            {
                GameObject go = Instantiate(_boardUnitPrefab, _parentTransform);
                go.transform.position = new Vector3(
                    x + tileSpacing + _parentTransform.position.x, 
                    y + tileSpacing + _parentTransform.position.y, 
                    0);
                tileArr[x, y] = new Tile { owner = 0, tileObject = go };
                
                BoardUnit boardUnit = go.AddComponent<BoardUnit>();
                boardUnit.Initialize(this, x, y);
                 
            }
        }
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
                
                int x = boardUnit.X;
                int y = boardUnit.Y;
                
                if (tileArr[x, y].owner == 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PlaceStone(x, y);
                    }
                
                    //curStoneArr.transform.position = new Vector3(x, y, -5f);
                }
            }




            if (Input.GetMouseButtonDown(0))
            {
                //CreateStone(stoneArr[_stoneIndex], x, y);
            }
            
        }
        
    }

    private void PlaceStone(int x, int y)
    {
        tileArr[x, y].owner = 1; // 예제: 플레이어1이 돌을 놓음
        tileArr[x, y].tileObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void OnSelectPlayer(int playerIndex)
    {
        _isSelected = true;
        Debug.Log($"플레이어 {playerIndex + 1} 선택됨");
    }
    
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
    
    
    
}
