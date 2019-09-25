using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //PlayGame function which loads the first scene(first level) of the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //QuitGame function when clicked prints the "QUIT" and closes the application   
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
