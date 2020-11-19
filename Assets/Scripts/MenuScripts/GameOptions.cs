using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public GameMode GameMode;
    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("GameOptions").Length > 1)
        {
            Debug.Log("Já tem um");
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Ainda não tem");
        }

    }

}
