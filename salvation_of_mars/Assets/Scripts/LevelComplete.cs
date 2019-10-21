using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private int nextLevel;
    private int level;

    void Start()
    {
        Time.timeScale = 0f;
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void saveLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", level + 2);
    }

    //Loads the tutorial levels corresponding to the recently unlocked ability
    public void GoToTutorial()
     {
         Scene scene = SceneManager.GetActiveScene();

         if (scene.name == "CloneUnlock")
         {
             SceneManager.LoadScene("CloneTutorial");
         }
         else if (scene.name == "GravityUnlock")
         {
            SceneManager.LoadScene("GravityTutorial");
         }
            else if (scene.name == "BoostUnlock")
         {  
            SceneManager.LoadScene("BoostTutorial");
         }
     }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "CloneUnlock" || scene.name == "GravityUnlock" || scene.name == "BoostUnlock")
        {
            SceneManager.LoadScene(nextLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(nextLevel);
        }
    }

    public void MainMenu()
    {
        saveLevel();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        saveLevel();
        Application.Quit();
    }
}
