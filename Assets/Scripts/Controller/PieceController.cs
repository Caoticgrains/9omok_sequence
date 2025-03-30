using UnityEngine;

namespace Controller
{
    public class PieceController : MonoBehaviour
    {
// private Dictionary<Vector2Int, PieceData> pieceRegistry = new();
//
//         public int PositionToIndex(Vector2Int position) => position.y * 8 + position.x;
//         public Vector2Int IndexToPosition(int index) => new Vector2Int(index % 8, index / 8);
//         public bool IsPositionPlaced(Vector2Int position) => pieceRegistry.ContainsKey(position);
//
//         public PieceData GetPieceData(Owner owner) //  TODO: 매개변수 잘 살펴보기 
//         {
//             return new PieceData
//             {
//                 type = owner == Owner.P1 ? ColorType.P1 : ColorType.P2
//             };
//         }
//         
//         public bool SetPieceTemp(GameObject go, ColorType colorType, Vector2Int position)
//         {
//             if (IsPositionPlaced(position)) return false; // 이미 말이 놓여 있으면 배치 불가
//
//             PieceData newPiece = new PieceData(position, colorType);
//             pieceRegistry[position] = newPiece;
//             
//             go.transform.position = new Vector3(position.x, position.y, 0);
//             go.name = $"{colorType}_TEMP";
//             
//             Image image = go.GetComponent<Image>();
//
//             if (image != null)
//             {
//                 if(colorType == ColorType.None) 
//                     Debug.Log("NONE STATE");
//                 
//                 // TODO: 매개변수 살펴보기 
//                 if (colorType == ColorType.P1)
//                 {
//                     image.sprite = Resources.Load<Sprite>("Sprites/Gem/Blue_gem");
//                     image.color *= 0.5f;
//                 }
//                 else if (colorType == ColorType.P2)
//                 {
//                     image.sprite = Resources.Load<Sprite>("Sprites/Gem/Pink_gem");
//                     image.color *= 0.5f;
//                 }
//             }
//
//             Debug.Log($"임시 배치: {go.name} / 위치: {position} / 인덱스: {PositionToIndex(position)}");
//
//             return true;
//         }
//         
//         public bool ConfirmPlacement(Vector2Int position)
//         {
//             if (!pieceRegistry.ContainsKey(position)) return false;
//
//             PieceData confirmedPiece = pieceRegistry[position].SetPlaced();
//
//             pieceRegistry[position] = confirmedPiece;
//
//             Debug.Log($"배치 확정: {confirmedPiece.type} " +
//                       $"/ 위치: {confirmedPiece.pos} " +
//                       $"/ 인덱스: {PositionToIndex(confirmedPiece.pos)}");
//
//             return true;
//         }
//
//         public bool RemovePiece(Vector2Int position)
//         {
//             if (!pieceRegistry.ContainsKey(position)) return false;
//             
//             pieceRegistry.Remove(position);
//             Debug.Log($"삭제 : 위치 {position}");
//             return true;
//         }
    }
}
