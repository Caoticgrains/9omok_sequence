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
        private List<HandCard> _cards = new();

        private Vector2Int _spacing = new(100, 0);

        private void Start()
        {
            Initialize();
            DrawCardPlayerHand();
        }

        void Initialize()
        {
        }

        void DrawCardPlayerHand()
        {
            for (int i = 0; i < Constants.cardMaxCountOnPlayerHand; i++)
            {
                DrawNewCard();
            }
        }

        public void DrawNewCard()
        {
            // object & component
            GameObject go = ObjectPoolManager.Instance.GetHandCard();

            if (go == null)
            {
                Debug.LogError("Object Pool is empty!");
                return;
            }

            // transform 
            go.transform.SetParent(cardParent);

            var cardData = GameManager.Instance.cardDeck.Draw();

            // image sprite
            go.GetComponent<Image>().sprite = cardData.sprite;
            go.SetActive(true);

            HandCard card = go.GetOrAddComponent<HandCard>();
            card.content = cardData.content;
            card.owner = owner;
            _cards.Add(card);
            
            Rearrange();
        }
        
        public void Discard(HandCard card)
        {
            ObjectPoolManager.Instance.ReturnHandCard(card.gameObject);
            _cards.Remove(card);
        }
    
        public void Rearrange()
        {
            int i = 0;
            foreach (var card in _cards)
            {
                _cardRectTransform = card.GetComponent<RectTransform>();
                float spacingX = i * _cardRectTransform.sizeDelta.x + _spacing.x;
                _cardRectTransform.anchoredPosition = new Vector2(spacingX, 0);
                i++;
            }
        }
    }
}