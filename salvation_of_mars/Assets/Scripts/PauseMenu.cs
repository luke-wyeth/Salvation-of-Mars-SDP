using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public static bool skillSelectOn = false;
    public static bool skillSelectOff = false;

    // Update is called once per frame
    //Escape key will activate the PauseGame function.
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (gameIsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("Pause"))
            {
                PauseGame();
            }
            else if ((scene.name == "credits") && Input.GetKeyDown(KeyCode.Escape))
            {
                PauseGame();
            }
        }
        else if (gameIsPaused == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape)||Input.GetButtonDown("Pause"))
            {
                ResumeGame();
            }
            else if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Restart"))
            {
                RestartGame();
            }
        }
    }

    //Remove the pause menu UI and let the game be playable
    public void ResumeGame()
    {
        if (!SkillSelect.skillSelected)
        {
            skillSelectOff = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
            gameIsPaused = false;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }

    //Activate the pause menu UI and let the game be unplayable
    void PauseGame()
    {
        if (!SkillSelect.skillSelected)
        {
            skillSelectOff = true;
        }
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
        skillSelectOff = false;
    }

    //Function to go to the main menu
    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    //Close application
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
