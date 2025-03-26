using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager _instance;

    [Header("Prefab References")]
    [SerializeField] private Card cardPrefab; 
    [SerializeField] private Piece piecePrefab; 

    [Header("Parent Transforms")]
    [SerializeField] private Transform boardCardParent;
    [SerializeField] private Transform pieceParent;

    private ObjectPool<Card> _boardCardPool;
    private ObjectPool<Piece> _piecePool;

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    private void Start()
    {
        _boardCardPool = new ObjectPool<Card>(cardPrefab, 64, boardCardParent);
        _piecePool = new ObjectPool<Piece>(piecePrefab, 32, pieceParent);
    }

    public Card GetBoardCard() => _boardCardPool.Get();
    public Piece GetPiece() => _piecePool.Get();

    public void ReturnBoardCard(Card card) => _boardCardPool.Return(card);
    public void ReturnPiece(Piece piece) => _piecePool.Return(piece);
}
