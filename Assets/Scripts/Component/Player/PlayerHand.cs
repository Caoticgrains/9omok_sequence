using System;
using System.Collections.Generic;
using Common;
using Component.Board;
using Data;
using Manager;
using Pattern;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Component.Player
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Transform cardParent;

        [SerializeField] private Owner owner;
        
        private RectTransform _cardRectTransform;

        private CardFilter _cardFilter;
        private Vector2Int _spacing = new(100, 0);

        private readonly HashSet<int> _usedNumbers = new HashSet<int>(); // 중복 방지
        private readonly List<HandCard> _activeCards = new();

        private void Start()
        {
            Initialize();
            DrawCardPlayerHand();
        }

        void Initialize()
        {
            if (_cardFilter != null)
            {
                Debug.Log("Card Deck is already initialized");
                return;
            }

            _cardFilter = ScriptableObject.CreateInstance<CardFilter>();
        }

        void DrawCardPlayerHand()
        {
            for (int i = 0; i < Constants.cardMaxCountOnPlayerHand; i++)
            {
                DrawNewCard(i);
            }
        }

        void DrawNewCard(int index)
        {
            // random value
            int cardValue;
            do
            {
                cardValue = Random.Range(1, 16);
            } while (_usedNumbers.Contains(cardValue));

            _usedNumbers.Add(cardValue);

            // object & component
            GameObject go = ObjectPoolManager.Instance.GetHandCard();

            if (go == null)
            {
                Debug.LogError("Object Pool is empty!");
                return;
            }
            
            // transform 
            go.transform.SetParent(cardParent);
            _cardRectTransform = go.GetComponent<RectTransform>();
            
            float spacingX = index * _cardRectTransform.sizeDelta.x + _spacing.x;
            _cardRectTransform.anchoredPosition = new Vector2(spacingX, 0);
            
            // image sprite
            go.GetComponent<Image>().sprite = _cardFilter.cards[cardValue].sprite;
            go.SetActive(true);

            HandCard card = go.GetOrAddComponent<HandCard>();
            card.content = (Content)cardValue;
            card.owner = owner;
            
            // Data manage 
            _activeCards.Add(card);
        }
        
    }
}