using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image cardImage;
    private CardData _cardData;

    public void Initialize(CardData cardData)
    {
        _cardData = cardData;
        cardImage.sprite = _cardData.sprite;
    }
}
