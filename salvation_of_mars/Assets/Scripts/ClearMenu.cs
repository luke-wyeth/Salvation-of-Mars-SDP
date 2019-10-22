using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearMenu : MonoBehaviour
{
    public GameObject clearMenuUI;
    public GameObject[] stars;
    public float starOne;
    public float starTwo;
    public float starThree;
    private int level;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if(ToNextScene.levelFinished == true)
        {
            clearMenuUI.SetActive(true);
            Time.timeScale = 0f;
            setStars();
        }
    }

    public void saveLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", level + 1);
    }

    public void setStars()
    {
        stars[0].SetActive(false);
        stars[1].SetActive(false);
        stars[2].SetActive(false);

        if (starOne >= ToNextScene.finalScore)
        {
            stars[0].SetActive(true);
        }
        if (starTwo >= ToNextScene.finalScore)
        {
            stars[1].SetActive(true);
        }
        if (starThree >= ToNextScene.finalScore)
        {
            stars[2].SetActive(true);
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(ToNextScene.nextSceneToLoad);
    }

    public void MainMenu()
    {
        saveLevel();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        saveLevel();
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        saveLevel();
        Application.Quit();
    }
}
