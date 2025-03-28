using Pattern;
using UnityEngine;

namespace Manager
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance;
        
        [SerializeField] private GameObject boardCardPrefab; 
        [SerializeField] private GameObject handCardPrefab; 
        [SerializeField] private GameObject piecePrefab; 
        [SerializeField] private GameObject bannerPrefab;
        
        private ObjectPool9 _boardCardPool;
        private ObjectPool9 _handCardPool;
        private ObjectPool9 _piecePool;
        private ObjectPool9 _bannerPool;
        
        private void Awake()
        {
            if (Instance == null) Instance = this;
        
            _boardCardPool = boardCardPrefab.AddComponent<ObjectPool9>();
            _handCardPool = handCardPrefab.AddComponent<ObjectPool9>();
            _piecePool = piecePrefab.AddComponent<ObjectPool9>();
            _bannerPool = bannerPrefab.AddComponent<ObjectPool9>();
            
            _boardCardPool.Initialize(boardCardPrefab, 64);
            _handCardPool.Initialize(handCardPrefab, 7);
            _piecePool.Initialize(piecePrefab, 64);
            _bannerPool.Initialize(bannerPrefab, 10);
        }
        
        public GameObject GetBoardCard() => _boardCardPool.GetObj();
        public GameObject GetHandCard() => _handCardPool.GetObj();
        public GameObject GetPiece() => _piecePool.GetObj();
        public GameObject GetBanner() => _bannerPool.GetObj();

        public void ReturnBoardCard(GameObject card) => _boardCardPool.ReturnObj(card);
        public void ReturnHandCard(GameObject card) => _handCardPool.ReturnObj(card);
        public void ReturnPiece(GameObject piece) => _piecePool.ReturnObj(piece);
        public void ReturnBanner(GameObject banner) => _bannerPool.ReturnObj(banner);
        
    }
}
