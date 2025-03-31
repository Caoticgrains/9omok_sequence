using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class CardFilter
    {
        public static List<CardData> cards => new()
        {
            new CardData
            {
                content = Content.Back,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_Back")
            },
            new CardData
            {
                content = Content.Penguin,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_001")
            },
            new CardData
            {
                content = Content.Sheep,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_002")
            },
            new CardData
            {
                content = Content.Capybara,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_003")
            },
            new CardData
            {
                content = Content.Rabbit,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_004")
            },
            new CardData
            {
                content = Content.Chicken,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_005")
            },
            new CardData
            {
                content = Content.Cat,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_006")
            },
            new CardData
            {
                content = Content.Jellyfish,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_007")
            },
            new CardData
            {
                content = Content.Whale,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_008")
            },
            new CardData
            {
                content = Content.Monkey,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_009")
            },
            new CardData
            {
                content = Content.Snake,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_010")
            },
            new CardData
            {
                content = Content.Dog,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_011")
            },
            new CardData
            {
                content = Content.Hedgehog,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_012")
            },
            new CardData
            {
                content = Content.Turtle,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_013")
            },
            new CardData
            {
                content = Content.Giraffe,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_014")
            },
            new CardData
            {
                content = Content.Rat,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_015")
            },
            new CardData
            {
                content = Content.Hippo,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_016")
            },
            new CardData
            {
                content = Content.Fox,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_017")
            },
            new CardData
            {
                content = Content.Unicorn,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_018")
            },
            new CardData
            {
                content = Content.Dragon,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_019")
            },
            new CardData
            {
                content = Content.WildSpace,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_Wild")
            },
        };
    }
}