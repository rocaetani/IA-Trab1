using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //public BoardController boardController;
    public void PlayButton()
    {
        SceneManager.LoadScene("MatchScene");
       //SceneManager.LoadScene("MatchScene");
        /*
        Scene scene = SceneManager.GetSceneByName("MatchScene");
        GameObject[] list = scene.GetRootGameObjects();
        foreach(GameObject obj in list){
            Debug.Log(obj.name);
        }
        //SceneManager.LoadScene()
        */
    }

    public void PlayVersusButton()
    {
        GameObject gameOptions = GameObject.FindGameObjectsWithTag("GameOptions")[0];
        gameOptions.GetComponent<GameOptions>().GameMode = GameMode.PlayerXPlayer;
        SceneManager.LoadScene("MatchScene");
    }

    public void SetDifficultyButton()
    {
        SceneManager.LoadScene("SetDifficultyScene");
    }


}
    
