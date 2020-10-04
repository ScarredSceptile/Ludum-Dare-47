using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadEnd()
    {
        SceneManager.LoadScene("End");
    }
}
