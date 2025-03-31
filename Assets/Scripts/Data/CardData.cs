using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

namespace Data
{
    public enum Content
    {
        Back = 0,
        Penguin = 1,
        Sheep = 2,
        Capybara = 3,
        Rabbit = 4,
        Chicken = 5,
        Cat = 6,
        Jellyfish = 7,
        Whale = 8,
        Monkey = 9,
        Snake = 10,
        Dog = 11,
        Hedgehog = 12,
        Turtle = 13,
        Giraffe = 14,
        Rat = 15,
        Hippo = 16,
        Fox = 17,
        Unicorn = 18,
        Dragon = 19,
        WildSpace = 20,
        Max = 21
    }

    [Serializable]
    public class CardData
    {
        public Content content;
        public Sprite sprite;
    }
}