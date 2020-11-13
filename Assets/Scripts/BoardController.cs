using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    private Board _board;
    public Symbol currentPlayer;
    private MiniMax _miniMax;
    private List<Spot> _spots;
    
    
   public void Start()
    {
        _board = new Board();
        currentPlayer = Symbol.Cross;
        _miniMax = new MiniMax();
        _spots = new List<Spot>();
        var allSpots = GetComponentsInChildren<Spot>();
        foreach (var spot in allSpots)
        {
            _spots.Add(spot);
        }
    }
    
    /* 
     0 1 2
     3 4 5
     6 7 8
    */
    public void SpotClicked(Spot spot)
    {
        

        
        //Debug.Log($"Cliked {spot.Position}");

        SetSymbolAt(spot.Position, currentPlayer);
        _board.Play(spot.Position, currentPlayer);
        //Debug.Log($"BOARD: \n {_board.ToString()}");
        
        Board newBoard = _board;
        //Debug.Log($"NEW BOARD 1: \n {newBoard.ToString()}");

        _miniMax.VerifyPlay(newBoard, spot.Position, currentPlayer, out var newPosition, true);
        //Debug.Log($"NEW BOARD 2: \n {newBoard.ToString()}");
        
        _board.Play(newPosition, currentPlayer.GetOther());
        SetSymbolAt(newPosition,currentPlayer.GetOther());
        //Debug.Log(currentPlayer);
    }


    
    public void SetSymbolAt(int position, Symbol player)
    {
        if (_spots[position].CurrentSymbol == Symbol.None)
        {
            _spots[position].CurrentSymbol = player;
        }
    }

}
