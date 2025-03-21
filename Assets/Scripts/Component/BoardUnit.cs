using UnityEngine;
using UnityEngine.EventSystems;

public class BoardUnit : MonoBehaviour
{
    // boardUnit
    private Board _board;
    
    // index
    private int _boardUnitIndex;
    
    // coord
    public int X { get; private set; }
    public int Y { get; private set; }
    
    // stone
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private Sprite _stoneSpriteRenderer;
    [SerializeField] private Sprite _stoneBlackSprite;
    [SerializeField] private Sprite _stoneWhiteSprite;
    
    // stone
    private SpriteRenderer _spriteRenderer;
    private Color _stoneColor;
    
    // delegate
    public delegate void OnBoardUnitClicked(int index);
    private OnBoardUnitClicked _onBoardUnitClicked;

    private void Awake()
    {
        // stone info manage
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _stoneColor = _spriteRenderer.color;
        
        // card info manage
        
    }
    
    public void Initialize(Board board, int x, int y)
    {
        // index 
        // card info
        // stone info
        // delegate(event) info
        _board = board; 
        X = x;
        Y = y;
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
    
    private void OnMouseDown()
    {
        //  
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //_onBoardUnitClicked?.Invoke(_boardUnitIndex);
        _board.RayToBoard();
    }
    
    
    
}
