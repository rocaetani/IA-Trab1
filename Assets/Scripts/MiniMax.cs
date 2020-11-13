using System.Collections.Generic;
using UnityEngine;

public class MiniMax
{

    public int VerifyPlay(Board board, int position, Symbol player, out int bestPosition, bool first)
    {
        bestPosition = position;
        int score = board.Score();
        if (score != 0) 
        {
            if (score == -1) 
            {
                return 0;
            }
            return score;
        }
        List<int> possiblePlays = board.PossiblePlays();
        
        bool isMin = (player == Symbol.Cross);
        if (isMin)
        {
            score = 999;
        }
        else
        {
            score = -999;
        }


        
        foreach (int possiblePosition in possiblePlays)
        {
            board.Play(possiblePosition, player.GetOther());
            int newScore = VerifyPlay(board, possiblePosition, player.GetOther(), out var bestPlay, false);
            if (first)
            {
                Debug.Log($"Position: {possiblePosition} - {newScore}");
            }

            //Debug.Log($"Position: {possiblePosition} - {newScore}");
            if (isMin)
            {
                if (newScore < score)
                {
                    score = newScore;
                    bestPosition = possiblePosition;
                }
            }
            else
            {
                if (newScore > score)
                {
                    score = newScore;
                    bestPosition = possiblePosition;
                }  
            }
            board.Remove(possiblePosition);
        }
        
        return score;
    }
    
}
