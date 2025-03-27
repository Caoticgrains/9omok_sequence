using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Component.Content
{



    public class Card : MonoBehaviour
    {
        private Image _cardImage;
        private CardData _cardData;

        private void Awake()
        {
            _cardImage = GetComponent<Image>();
        }

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;
            _cardImage.sprite = _cardData.sprite;
        }
    }

}
