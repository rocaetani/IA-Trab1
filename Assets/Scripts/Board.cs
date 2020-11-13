
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.Rendering;

public class Board
{
    private List<Symbol> _board;
    private int _numPlays;    

    public Board()
    {
        _board = new List<Symbol>(9);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _board.Add(Symbol.None);
        _numPlays = 0;
    }


    public void Play(int position, Symbol player)
    {
        _board[position] = player;
        _numPlays += 1;
    }
    
    public void Remove(int position)
    {
        _board[position] = Symbol.None;
        _numPlays -= 1;
    }
    
    
    public int Score() {
        //return the score acording to a player win or not
        // X - Win: +10 / O - Win: -10 / Tie: 1 / StillPlaing = 0

        if (VerifyWinPossibilities(Symbol.Cross)) {
            return 15;
        }
        if (VerifyWinPossibilities(Symbol.Circle)) {
            return -10;
        }
        
        
        if (this._numPlays == 9) {
            return -1;
        }

        return 0;
    }
    
    private bool VerifyWinPossibilities(Symbol player) {
        if (
            VerifyEquals(0, 1, 2, player) |
            VerifyEquals(3, 4, 5, player) |
            VerifyEquals(6, 7, 8, player) |
            
            VerifyEquals(0, 3, 6, player) |
            VerifyEquals(1, 4, 7, player) |
            VerifyEquals(2, 5, 8, player) |
            
            VerifyEquals(0, 4, 8, player) |
            VerifyEquals(2, 4, 6, player)) 
        {
            return true;
        }

        return false;
    } 
    
    private bool VerifyEquals(int a, int b,  int c, Symbol player) {
        if(_board[a] == player & _board[b] == player & _board[c] == player)
        {
            return true;   
        }
        return false;
    }

    public List<int> PossiblePlays()
    {
        List<int> possiblePlays = new List<int>();
        for (int i = 0; i < 9; i++) 
        {
            if (_board[i] == Symbol.None) 
            {
                possiblePlays.Add(i);
            }
        }
        return possiblePlays;
    }

    public String ToString() {
        String result = "";
        
        result = result + "[" + _board[0].ToCharacter() + "]";
        result = result + "[" + _board[1].ToCharacter() + "]";
        result = result + "[" + _board[2].ToCharacter() + "] \n";

        result = result + "[" + _board[3].ToCharacter() + "]";
        result = result + "[" + _board[4].ToCharacter() + "]";
        result = result + "[" + _board[5].ToCharacter() + "] \n";

        result = result + "[" + _board[6].ToCharacter() + "]";
        result = result + "[" + _board[7].ToCharacter() + "]";
        result = result + "[" + _board[8].ToCharacter() + "] \n";
        return result;
    }


}

