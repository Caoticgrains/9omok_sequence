using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Component.Content
{
    public class Card : MonoBehaviour
    {
        private CardData _cardData;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Initialize(CardData cardData)
        {
            _cardData = cardData;
            _image.sprite = _cardData.sprite;
        }
    }
}
