using Pattern;
using UnityEngine;

namespace Manager
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance;

        [Header("Prefab References")]
        [SerializeField] private GameObject boardCardPrefab; 
        //[SerializeField] private GameObject handCardPrefab; 
        [SerializeField] private GameObject piecePrefab; 

        [Header("Parent Transforms")]
        //[SerializeField] private Transform boardCardParent;
        //[SerializeField] private Transform handCardParent;
        //[SerializeField] private Transform pieceParent;

        private ObjectPool<Card> _boardCardPool;
        //private ObjectPool<Card> _handCardPool;
        private ObjectPool<Piece> _piecePool;

        private Card _boardCardComponent;
        //private Card _handCardComponent;
        private Piece _pieceComponent;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
            
            _boardCardComponent = Instantiate(boardCardPrefab).GetComponent<Card>();
            //_handCardComponent = Instantiate(handCardPrefab).GetComponent<Card>();
            _pieceComponent = Instantiate(piecePrefab).GetComponent<Piece>();
        
            _boardCardPool = new ObjectPool<Card>(_boardCardComponent, 64);
            //_handCardPool = new ObjectPool<Card>(handCard, 7);
            _piecePool = new ObjectPool<Piece>(_pieceComponent, 32);
        }

        private void Start()
        {

        }

        public Card GetBoardCard() => _boardCardPool.Get();
        //public Card GetHandCard() => _handCardPool.Get();
        public Piece GetPiece() => _piecePool.Get();

        public void ReturnBoardCard(Card card) => _boardCardPool.Return(card);
        //public void ReturnHandCard(Card card) => _handCardPool.Return(card);
        public void ReturnPiece(Piece piece) => _piecePool.Return(piece);
    }
}
