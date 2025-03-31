using System.Collections.Generic;
using Data;

public class CardDeck
{
    private List<CardData> deck = new();
    
    private bool init;

    public void Initialize()
    {
        if (init) return;
        init = true;
        deck.Clear();
        for (int i = 0; i < 16; i++)
        for (int j = 0; j < 4; j++)
            deck.Add(CardFilter.cards[i]);
        deck.Shuffle();
    }

    public CardData Draw()
    {
        if (!init) Initialize();
        var item = deck[0];
        deck.RemoveAt(0);
        return item;
    }
}