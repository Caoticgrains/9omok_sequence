using Data;
using UnityEngine;

namespace Manager
{
    public class CardController : MonoBehaviour
    {
        private CardStack _stack;

        public void OnClickCardDeckButton()
        {
            Debug.Log("Card Deck Button Clicked");
        }

        public void OnClickCardStackButton()
        {
            Debug.Log("CardStackButton Clicked");

            // if (_stack.IsEmpty())
            // {
            //     Debug.Log("버려진 카드가 없습니다.");
            //     return;
            // }
            // else
            // {
            //     foreach (var card in _stack._items)
            //     {
            //         Debug.Log($" {card.content.ToString()} , {card.sprite.name} ");
            //     }
            // }
        }
    }
}

