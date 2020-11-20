
using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class BoardController : MonoBehaviour
{

    private Board _board;
    public Symbol currentPlayer;
    private MiniMax _miniMax;
    private List<Spot> _spots;
    private GameMode _gameMode;
    public GameObject winMessage;
    public Text gameModeText;

    private bool _isPlying;


    public void Start()
    {
        _isPlying = false;
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
        gameModeText.text = _gameMode.ToString();
        if (_gameMode != GameMode.PlayerXPlayer)
        {
            SetRandomPlayer();
            if (currentPlayer == Symbol.Circle)
            {
                StartCoroutine(CoroutineMakeFirstMove());
            }
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ResetBoard();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

    }

    public void SetRandomPlayer()
    {
        if (Random.Range(0, 2) > 0)
        {
            currentPlayer = Symbol.Cross;
            
        }
        else
        {
            currentPlayer = Symbol.Circle;
        }

        _miniMax.AIPlayer = currentPlayer.GetOther();

    }

    public void ResetBoard()
    {
        _board.CleanBoard();
        CleanSpots();
        winMessage.SetActive(false);
        
    }

    public void CleanSpots()
    {
        for (int index = 0 ; index < _spots.Count; index ++)
        {
            _spots[index].CurrentSymbol = Symbol.None;
        }
    }

    public void MakeFirstMove()
    {
        switch (_gameMode)
        {
            case GameMode.Easy:
                RandomMove(currentPlayer.GetOther());
                break;

            case GameMode.Medium:
                if (Random.Range(0, 2) > 0)
                {
                    SetSymbolAt(4, currentPlayer.GetOther());
                }
                else
                {
                    RandomMove(currentPlayer.GetOther());
                }

                break;
            case GameMode.Hard:
                SetSymbolAt(4, currentPlayer.GetOther());
                break;

            default:
                Debug.Log("Error");
                break;
        }
    }

    public void SpotClicked(Spot spot)
    {
        if (!VerifyWinner() && !_isPlying)
        {
            StartCoroutine(CoroutineMakeNextMove(spot));
        }

    }

    public void MakeNextMove(Spot spot)
    {
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



    public bool VerifyWinner()
    {
        int score = _board.Score(currentPlayer);

        if (score == 10)
        {
            
            PresentWinMessage($"The winner is {currentPlayer}");
            //Debug.Log();
            return true;
        }
        else if (score == -10)
        {
            PresentWinMessage($"The winner is {currentPlayer.GetOther()}");
            //Debug.Log();
            return true;
        }
        else if (score == -1)
        {
            PresentWinMessage("It's a tie");
            return true;
        }

        return false;
    }

    public void PresentWinMessage(String message)
    {
        winMessage.SetActive(true);
        Text text = winMessage.GetComponentInChildren<Text>();
        text.text = message;
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

    
    IEnumerator CoroutineMakeNextMove(Spot spot)
    {
        SetSymbolAt(spot.Position, currentPlayer);
        _isPlying = true;
        yield return new WaitForSeconds(0.7f);
        MakeNextMove(spot);
        _isPlying = false;

    }

    IEnumerator CoroutineMakeFirstMove()
    {
        
        _isPlying = true;
        yield return new WaitForSeconds(0.2f);
        MakeFirstMove();
        _isPlying = false;

    }


}
