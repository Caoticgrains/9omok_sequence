using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CardDeck", menuName = "User/CardDeck", order = 0)]
public class CardDeck : ScriptableObject
{
    public List<CardData> cards = new List<CardData>();

    private void OnEnable()
    {
        if (cards == null || cards.Count == 0)
        {
            Init();
        }
    }

    public void Init()
    {
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Two,
            sprite = Resources.Load<Sprite>("Sprites/2club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Three,
            sprite = Resources.Load<Sprite>("Sprites/3club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Four,
            sprite = Resources.Load<Sprite>("Sprites/4club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Five,
            sprite = Resources.Load<Sprite>("Sprites/5club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Six,
            sprite = Resources.Load<Sprite>("Sprites/6club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Seven,
            sprite = Resources.Load<Sprite>("Sprites/7club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Eight,
            sprite = Resources.Load<Sprite>("Sprites/8club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Nine,
            sprite = Resources.Load<Sprite>("Sprites/9club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Ten,
            sprite = Resources.Load<Sprite>("Sprites/10club")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Jack,
            sprite = Resources.Load<Sprite>("Sprites/Jclub")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Queen,
            sprite = Resources.Load<Sprite>("Sprites/Qclub")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.King,
            sprite = Resources.Load<Sprite>("Sprites/Kclub")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Club,
            rank = CardRank.Ace,
            sprite = Resources.Load<Sprite>("Sprites/Aclub")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Two,
            sprite = Resources.Load<Sprite>("Sprites/2diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Three,
            sprite = Resources.Load<Sprite>("Sprites/3diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Four,
            sprite = Resources.Load<Sprite>("Sprites/4diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Five,
            sprite = Resources.Load<Sprite>("Sprites/5diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Six,
            sprite = Resources.Load<Sprite>("Sprites/6diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Seven,
            sprite = Resources.Load<Sprite>("Sprites/7diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Eight,
            sprite = Resources.Load<Sprite>("Sprites/8diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Nine,
            sprite = Resources.Load<Sprite>("Sprites/9diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Ten,
            sprite = Resources.Load<Sprite>("Sprites/10diamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Jack,
            sprite = Resources.Load<Sprite>("Sprites/Jdiamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Queen,
            sprite = Resources.Load<Sprite>("Sprites/Qdiamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.King,
            sprite = Resources.Load<Sprite>("Sprites/Kdiamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Diamond,
            rank = CardRank.Ace,
            sprite = Resources.Load<Sprite>("Sprites/Adiamond")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Two,
            sprite = Resources.Load<Sprite>("Sprites/2heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Three,
            sprite = Resources.Load<Sprite>("Sprites/3heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Four,
            sprite = Resources.Load<Sprite>("Sprites/4heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Five,
            sprite = Resources.Load<Sprite>("Sprites/5heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Six,
            sprite = Resources.Load<Sprite>("Sprites/6heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Seven,
            sprite = Resources.Load<Sprite>("Sprites/7heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Eight,
            sprite = Resources.Load<Sprite>("Sprites/8heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Nine,
            sprite = Resources.Load<Sprite>("Sprites/9heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Ten,
            sprite = Resources.Load<Sprite>("Sprites/10heart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Jack,
            sprite = Resources.Load<Sprite>("Sprites/Jheart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Queen,
            sprite = Resources.Load<Sprite>("Sprites/Qheart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.King,
            sprite = Resources.Load<Sprite>("Sprites/Kheart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Heart,
            rank = CardRank.Ace,
            sprite = Resources.Load<Sprite>("Sprites/Aheart")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Two,
            sprite = Resources.Load<Sprite>("Sprites/2spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Three,
            sprite = Resources.Load<Sprite>("Sprites/3spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Four,
            sprite = Resources.Load<Sprite>("Sprites/4spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Five,
            sprite = Resources.Load<Sprite>("Sprites/5spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Six,
            sprite = Resources.Load<Sprite>("Sprites/6spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Seven,
            sprite = Resources.Load<Sprite>("Sprites/7spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Eight,
            sprite = Resources.Load<Sprite>("Sprites/8spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Nine,
            sprite = Resources.Load<Sprite>("Sprites/9spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Ten,
            sprite = Resources.Load<Sprite>("Sprites/10spade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Jack,
            sprite = Resources.Load<Sprite>("Sprites/Jspade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Queen,
            sprite = Resources.Load<Sprite>("Sprites/Qspade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.King,
            sprite = Resources.Load<Sprite>("Sprites/Kspade")
        });
        cards.Add(new CardData
        {
            suit = CardSuit.Spade,
            rank = CardRank.Ace,
            sprite = Resources.Load<Sprite>("Sprites/Aspade")
        });
        
    }
    
}
