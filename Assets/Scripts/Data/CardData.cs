using System;
using UnityEngine;


public enum CardSuit { Club, Diamond, Heart, Spade }
public enum CardRank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace } 

[Serializable]
public struct CardData
{
    public CardSuit suit;
    public CardRank rank;
    public Sprite sprite;
}
