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
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            _boardCardPool = CreatePool("BoardCardPool",boardCardPrefab, 64);
            _handCardPool = CreatePool("HandCardPool",handCardPrefab, 7);
            _piecePool = CreatePool("PiecePool",piecePrefab, 64);
            _bannerPool = CreatePool("BannerPool",bannerPrefab, 10);
        }

        private ObjectPool9 CreatePool(string poolName, GameObject prefab, int size)
        {
            GameObject poolObject = new GameObject(poolName);
            poolObject.transform.SetParent(transform);
            ObjectPool9 pool = poolObject.AddComponent<ObjectPool9>();
            pool.Initialize(prefab, size);
            return pool;
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
