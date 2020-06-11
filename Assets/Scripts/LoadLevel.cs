using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelToLoad;

    public int currentLevel = 1;
    private bool nextlevel = false;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Level Completed")>1)
        {
            currentLevel = PlayerPrefs.GetInt("Level completed");

        }
        else
        {
            currentLevel = 1;
        }
    }

    /*
    public void Won()
    {
        nextlevel = true;
    }
    public void NextLevelButton()
    {
        SaveCurrentLevel();
    }

    public void MainMenuButton()
    {
        SaveCurrentLevel();
    }

    public void SaveCurrentLevel()
    {
        if (wonTheLevel == true)
        {
            
        }
        {

        }
    }
    */

    public void Playgame()
    {
        SceneManager.LoadScene(LevelToLoad);
    }

  
    public void Quitgame()
    {
        Debug.Log("QUIT");
        Application.Quit();

    }

    public void GameOVer()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene(4);
    }

}
