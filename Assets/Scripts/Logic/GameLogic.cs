using Component.Board;

public class GameLogic
{
    public bool CheckVictory(BoardUnit[,] unitArray, Owner owner)
    {
        int tileLength = 8;

        for (int y = 0; y < tileLength; y++)
        {
            for (int x = 0; x < tileLength; x++)
            {
                if (unitArray[y, x].owner == Owner.None) continue;
                if (x == 5) continue;
                if (y == 5) continue;
                if (
                    (unitArray[y + 1, x].owner == owner) &&
                    (unitArray[y + 2, x].owner == owner) &&
                    (unitArray[y + 3, x].owner == owner)
                ) return true;
                else if (
                    (unitArray[y, x + 1].owner == owner) &&
                    (unitArray[y, x + 2].owner == owner) &&
                    (unitArray[y, x + 3].owner == owner)
                ) return true;
            }
        }

        return false;
    }
}