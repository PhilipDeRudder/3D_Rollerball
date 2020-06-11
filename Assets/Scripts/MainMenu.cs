using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
