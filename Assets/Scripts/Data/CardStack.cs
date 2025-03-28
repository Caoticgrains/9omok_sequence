using System;
using Data;
using Pattern;
using UnityEngine;

namespace Data
{
    public class CardStack : Stack9<CardData>
    {
        public static CardStack Instance { get; private set; }

        public void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public void AddToStack(CardData data)
        {
            Push(data);
            Debug.Log($"카드 {data.content.ToString()} , {data.sprite.name} 이(가) 버려짐");
        }
    }
}