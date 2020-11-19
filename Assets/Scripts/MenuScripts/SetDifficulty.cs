using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public void EasyButton()
    {
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Easy;
        SceneManager.LoadScene("Menu");
    }
    public void MediumButton()
    {
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Medium;
        SceneManager.LoadScene("Menu");
    }
    public void HardButton()
    {
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Hard;
        SceneManager.LoadScene("Menu");
    }
}
