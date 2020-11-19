using System.Collections.Generic;
using UnityEngine;

public class MiniMax
{
    private const int MaxScore = 999;
    private const int MinScore = -999;
    public Symbol AIPlayer = Symbol.Circle;
    
     
    
    
    public int VerifyPlay(Board board, int position, Symbol player, out int bestPosition)
    {
        bestPosition = position;
        bool isMin = (player == AIPlayer);
        int score = isMin ? board.Score(player) : board.Score(player.GetOther());
        
        if (score != 0) 
        {
            if (score == -1) 
            {
                return 0;
            }
            return score;
        }
        List<int> possiblePlays = board.PossiblePlays();
        
        score = isMin ? MaxScore : MinScore;
        
        foreach (int possiblePosition in possiblePlays)
        {
            board.Play(possiblePosition, player.GetOther());
            int newScore = VerifyPlay(board, possiblePosition, player.GetOther(), out var bestPlay);
            
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
            //Make Minimax no Deterministic
            if (newScore == score)
            {
                if (Random.Range(0, 2) > 0)
                {
                    bestPosition = possiblePosition;
                }
            }
            board.Remove(possiblePosition);
        }
        
        return score;
    }
    
}
