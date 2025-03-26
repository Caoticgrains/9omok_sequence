using UnityEngine;
using UnityEngine.UI;

public partial class Board
{

    private Vector3 CalCardPos(int index)
    {
        int row = index / _boardSize.x;
        int column = index % _boardSize.x;
        return new Vector3(row * _boardSize.x, column * _boardSize.y, -3f);
    }
    
}
