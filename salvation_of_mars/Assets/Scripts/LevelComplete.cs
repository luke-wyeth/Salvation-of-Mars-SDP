using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private int nextLevel;

    void Start()
    {
        Time.timeScale = 0f;
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
    }

    //Loads the tutorial levels corresponding to the recently unlocked ability
    public void GoToTutorial()
     {
         Scene scene = SceneManager.GetActiveScene();

         if (scene.name == "CloneUnlock")
         {
             SceneManager.LoadScene("CloneTutorial");
         }
         //else if (scene.name == "GravityUnlock")
        // {
         //    SceneManager.LoadScene("GravityTutorial");
        // }
        // else if (scene.name == "CloneUnlock") ;
       //  {
       //      SceneManager.LoadScene("CloneTutorial");
       //  }
     }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "CloneUnlock")
        {
            SceneManager.LoadScene(nextLevel + 1);
        }
        else
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
