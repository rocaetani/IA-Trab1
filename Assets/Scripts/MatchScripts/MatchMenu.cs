using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchMenu : MonoBehaviour
{

    public BoardController BoardController;
    // Start is called before the first frame update
    public void ReturnButton()
    {
        transform.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Menu");
    }
    
    public void ResetButton()
    {
        transform.GetComponent<AudioSource>().Play();
        //SceneManager.LoadScene("Menu");
        BoardController.ResetBoard();
    }
}
