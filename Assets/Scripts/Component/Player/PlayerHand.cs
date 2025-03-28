using System;
using System.Collections.Generic;
using Common;
using Data;
using Manager;
using Pattern;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Component.Player
{
    public class PlayerHand : MonoBehaviour
    {
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private Transform cardParent;
        private RectTransform _cardRectTransform;

        private CardDeck _cardDeck;
        private Vector2Int _spacing = new(100, 0);

        private readonly HashSet<int> _usedNumbers = new HashSet<int>(); // 중복 방지
        private readonly List<GameObject> _activeCards = new();

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
            // random
            int cardValue;
            do
            {
                cardValue = Random.Range(1, 20);
            } while (_usedNumbers.Contains(cardValue));

            _usedNumbers.Add(cardValue);

            // object & component
            GameObject go = ObjectPoolManager.Instance.GetHandCard();

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
            ObjectPoolManager.Instance.ReturnHandCard(go);
            _activeCards.RemoveAt(index);
            // DrawNewCard();
        }

    }
}