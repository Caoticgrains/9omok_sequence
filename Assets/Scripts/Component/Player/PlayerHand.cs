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
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardParent;
    private RectTransform _cardRectTransform;
    
    private CardDeck _cardDeck; 
    private Vector2Int _spacing = new (100, 0);
     
    private readonly HashSet<int> _usedNumbers = new HashSet<int>(); // 중복 방지
    private readonly List<GameObject> _activeCards = new ();  
    
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
        
        // about random card
        int cardValue;
        do
        {
            cardValue = Random.Range(1, 20);
        } 
        while (_usedNumbers.Contains(cardValue));
        _usedNumbers.Add(cardValue);
        
        // object pool -> card 
        GameObject go = ObjectPool.Instance.GetObj();
        if (go == null)
        {
            Debug.LogError("Object Pool is empty!");
            return;
        }
        go.transform.SetParent(cardParent);
        _cardRectTransform = go.GetComponent<RectTransform>();
        float spacingX = index * _cardRectTransform.sizeDelta.x + _spacing.x;
        _cardRectTransform.anchoredPosition = new Vector2(spacingX, 0);
        go.GetComponent<Image>().sprite = _cardDeck.cards[cardValue].sprite;
        
        // Data manage 
        _activeCards.Add(go);
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
