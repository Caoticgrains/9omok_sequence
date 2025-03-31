using System;
using Component.Board;

public class GameLogic
{
    public Owner currentTurn;

    public void SetRandomTurn()
    {
        Random random = new();
        int randomInt = random.Next(0, 2);

        if (randomInt == 0)
            currentTurn = Owner.P1;
        else
            currentTurn = Owner.P2;
    }

    public void EndTurn()
    {
        if (currentTurn == Owner.P1) currentTurn = Owner.P2;
        else if (currentTurn == Owner.P2) currentTurn = Owner.P1;
    }

    public bool CheckVictory(BoardUnit[,] unitArray)
    {
        int tileLength = 8;

        for (int y = 0; y < tileLength; y++)
        {
            for (int x = 0; x < tileLength; x++)
            {
                if (unitArray[y, x].owner == Owner.None) continue;
                if (x >= 5) continue;
                if (y >= 5) continue;
                if (
                    (unitArray[y + 1, x].owner == currentTurn) &&
                    (unitArray[y + 2, x].owner == currentTurn) &&
                    (unitArray[y + 3, x].owner == currentTurn)
                ) return true;
                if (
                    (unitArray[y, x + 1].owner == currentTurn) &&
                    (unitArray[y, x + 2].owner == currentTurn) &&
                    (unitArray[y, x + 3].owner == currentTurn)
                ) return true;
            }
        }

        return false;
    }
}