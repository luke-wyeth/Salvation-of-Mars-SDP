using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    //Escape key will activate the PauseGame function.
    void Update()
    {
        if (!gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && SkillSelect.skillSelected)
            {
                PauseGame();
            }
        }
    }

    //Remove the pause menu UI and let the game be playable
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    //Activate the pause menu UI and let the game be unplayable
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    //Resets the gravity back to normal and let the game be playable
    //Reloads the current level to restart the game
    public void RestartGame()
    {
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameIsPaused = false;
    }

    //Function to go to the main menu
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    //Close application
    public void QuitGame()
    {
        Application.Quit();
    }
}
