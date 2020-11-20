using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    public void EasyButton()
    {
        transform.GetComponent<AudioSource>().Play();
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Easy;
        SceneManager.LoadScene("Menu");
    }
    public void MediumButton()
    {
        transform.GetComponent<AudioSource>().Play();
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Medium;
        SceneManager.LoadScene("Menu");
    }
    public void HardButton()
    {
        transform.GetComponent<AudioSource>().Play();
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.Hard;
        SceneManager.LoadScene("Menu");
    }
}
