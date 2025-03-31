
using UnityEngine;

namespace Common
{
    public static class Calculators
    {
        public static Vector3 CalIndexToVec3(Vector2Int refValue, int index)
        {
            int row = index / refValue.x;
            int column = index % refValue.x;
            return new Vector3(row * refValue.x, column * refValue.y, 0);
        }
        
        public static Vector2Int CalMatrixToVec2Int(int row, int column)
        {
            return new Vector2Int(row, column);
        }

        public static int CalMatrixToIndex(Vector2Int refValue, int row, int column)
        {
            return row * refValue.x + column;
        }

    }
}


