using System.Collections.Generic;
using Component.Board;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Data
{
    [CreateAssetMenu(fileName = "PieceFilter", menuName = "User/PieceFilter", order = 0)]
    public class PieceFilter : ScriptableObject
    {
        public List<PieceData> pieces = new ();

        private void OnEnable()
        {
            if (pieces == null || pieces.Count == 0)
            {
                Initialize();
            }
        }

        private void Initialize()
        {
            pieces.Add(new PieceData
            {
                color = PlayerColor.Blue,
                sprite = Resources.Load<Sprite>("Sprites/Gem/Blue_gem")
            });
            pieces.Add(new PieceData
            {
                color = PlayerColor.Pink,
                sprite = Resources.Load<Sprite>("Sprites/Gem/Pink_gem")
            });
        }
    }
}
