
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BoardController : MonoBehaviour
{

    private Board _board;
    public Symbol currentPlayer;
    private MiniMax _miniMax;
    private List<Spot> _spots;
    private GameMode _gameMode;



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

        LoadGameOptions();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _board.CleanBoard();
            CleanSpots();
        }

    }

    public void CleanSpots()
    {
        for (int index = 0 ; index < _spots.Count; index ++)
        {
            _spots[index].CurrentSymbol = Symbol.None;
        }
    }

    public void SpotClicked(Spot spot)
    {
        if (!VerifyWinner())
        {
            SetSymbolAt(spot.Position, currentPlayer);
            if (_board.HasOpenSpot())
            {
                switch (_gameMode)
                {
                    case GameMode.Easy:
                        RandomMove(currentPlayer.GetOther());
                        break;

                    case GameMode.Medium:
                        if (Random.Range(0, 2) > 0)
                        {
                            MiniMaxMove(spot);
                        }
                        else
                        {
                            RandomMove(currentPlayer.GetOther());
                        }

                        break;
                    case GameMode.Hard:
                        MiniMaxMove(spot);
                        break;

                    case GameMode.PlayerXPlayer:
                        currentPlayer = currentPlayer.GetOther();
                        break;

                    default:
                        Debug.Log("Error");
                        break;
                }
            }

            VerifyWinner();
        }

    }

    public bool VerifyWinner()
    {
        int score = _board.Score(currentPlayer);

        if (score == 10)
        {
            Debug.Log($"O vencedor é {currentPlayer}");
            return true;
        }
        else if (score == -10)
        {
            Debug.Log($"O vencedor é {currentPlayer.GetOther()}");
            return true;
        }
        else if (score == -1)
        {
            Debug.Log($"Empate");
        }

        return false;
    }


    private void MiniMaxMove(Spot spot)
    {
        Debug.Log("Jogada Minimax");
        _miniMax.VerifyPlay(_board, spot.Position, currentPlayer, out var newPosition);
            
        SetSymbolAt(newPosition, currentPlayer.GetOther());
    }

    public void RandomMove(Symbol player)
    {
        Debug.Log("Jogada Random");
        int randomPosition = Random.Range(0, 9);
        while (!SetSymbolAt(randomPosition, player))
        {
            randomPosition = Random.Range(0, 9);
        }
    }

    public bool SetSymbolAt(int position, Symbol player)
    {
        if (_spots[position].CurrentSymbol == Symbol.None)
        {
            _spots[position].CurrentSymbol = player;
            _board.Play(position, player);
            return true;
        }
        return false;
    }

    public void LoadGameOptions()
    {
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        _gameMode = gameOptions.GetComponent<GameOptions>().GameMode;
    }




}
