using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CardFilter", menuName = "User/CardFilter", order = 0)]
    public class CardFilter : ScriptableObject
    {
        public List<CardData> cards = new ();

        private void OnEnable()
        {
            if (cards == null || cards.Count == 0)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            cards.Add(new CardData
            {
                content = Content.Back,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_Back")
            });
            cards.Add(new CardData
            {
                content = Content.Penguin,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_001")
            });
            cards.Add(new CardData
            {
                content = Content.Sheep,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_002")
            });
            cards.Add(new CardData
            {
                content = Content.Capybara,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_003")
            });
            cards.Add(new CardData
            {
                content = Content.Rabbit,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_004")
            });
            cards.Add(new CardData
            {
                content = Content.Chicken,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_005")
            });
            cards.Add(new CardData
            {
                content = Content.Cat,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_006")
            });
            cards.Add(new CardData
            {
                content = Content.Jellyfish,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_007")
            });
            cards.Add(new CardData
            {
                content = Content.Whale,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_008")
            });
            cards.Add(new CardData
            {
                content = Content.Monkey,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_009")
            });
            cards.Add(new CardData
            {
                content = Content.Snake,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_010")
            });
            cards.Add(new CardData
            {
                content = Content.Dog,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_011")
            });
            cards.Add(new CardData
            {
                content = Content.Hedgehog,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_012")
            });
            cards.Add(new CardData
            {
                content = Content.Turtle,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_013")
            });
            cards.Add(new CardData
            {
                content = Content.Giraffe,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_014")
            });
            cards.Add(new CardData
            {
                content = Content.Rat,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_015")
            });
            cards.Add(new CardData
            {
                content = Content.Hippo,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_016")
            });
            cards.Add(new CardData
            {
                content = Content.Fox,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_017")
            });
            cards.Add(new CardData
            {
                content = Content.Unicorn,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_018")
            });
            cards.Add(new CardData
            {
                content = Content.Dragon,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_019")
            });
            cards.Add(new CardData
            {
                content = Content.WildSpace,
                sprite = Resources.Load<Sprite>("Sprites/Card_pack/Card_Wild")
            });
        }
    }
}