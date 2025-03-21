using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/// <summary>
/// Player는 7장의 랜덤한 카드를 가짐
/// Player는 기존카드를 버리고 새로운 카드를 추가하여 7장을 유지 
/// </summary>

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private RectTransform _rectTransform;
     
    private HashSet<int> _usedNumbers = new HashSet<int>(); // 중복 방지
    private List<GameObject> _activeCards = new (); // 들고있는 카드  
    private CardDeck _cardDeck; // 가져올 카드덱  
    private Vector2Int spacing = new (5, 0);
    //private Dictionary<Vector2Int, GameObject> _cardObjects = new Dictionary<Vector2Int, GameObject>();
    
    private void Start()
    {
        DeckInit();
        DrawInitHand();
    }

    void DeckInit()
    {
        if (_cardDeck != null)
        {
            Debug.Log("Card Deck is already initialized");
            return;
        }
        _cardDeck = ScriptableObject.CreateInstance<CardDeck>();
    }
    
    void DrawInitHand()
    {
        for (int i = 0; i < Constants.cardMaxCountOnPlayerHand; i++)
        {
           DrawNewCard(i);
        }
    }
    
    void DrawNewCard(int index)
    {
        int cardValue;
        do
        {
            cardValue = Random.Range(1, 53);
        } while (_usedNumbers.Contains(cardValue));
        _usedNumbers.Add(cardValue);
    
        // 오브젝트
        GameObject go = ObjectPool.Instance.GetObj();

        if (go == null)
        {
            Debug.LogError("Object Pool is empty!");
            return;
        }
        
        // 부모 트랜스폼 설정
        go.transform.SetParent(_parentTransform);
        
        // 위치 
        _rectTransform = go.GetComponent<RectTransform>();
        float spacing_x = index * _rectTransform.sizeDelta.x + spacing.x;
        _rectTransform.anchoredPosition = new Vector2(spacing_x, _rectTransform.anchoredPosition.y);
        
        // 스프라이트 설정 
        go.GetComponent<Image>().sprite = _cardDeck.cards[cardValue].sprite;
        
        // 활성화된 카드 목록에 추가 
        _activeCards.Add(go);
        
        // 오브젝트 활성화 
        go.SetActive(true);
        
    }
    
    public void ReplaceCard(int index)
    {
        if (index < 0 || index >= _activeCards.Count) return;
    
        GameObject go = _activeCards[index];
        ObjectPool.Instance.ReturnObj(go);
        _activeCards.RemoveAt(index);
        // DrawNewCard();
    }
    
}
