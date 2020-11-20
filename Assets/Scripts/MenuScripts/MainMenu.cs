using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public BoardController boardController;
    public void PlayButton()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MatchScene");
    }

    public void PlayVersusButton()
    {
        transform.GetComponent<AudioSource>().Play();
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.PlayerXPlayer;
        SceneManager.LoadScene("MatchScene");
    }

    public void SetDifficultyButton()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("SetDifficultyScene");
    }


}
    
