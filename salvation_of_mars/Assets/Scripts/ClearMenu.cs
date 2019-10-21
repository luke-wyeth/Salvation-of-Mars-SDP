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

    public void setStars()
    {
        if (starOne <= ToNextScene.score)
        {
            stars[1].SetActive(true);
        }
        if (starOne <= ToNextScene.score)
        {
            stars[2].SetActive(true);
        }
        if (starThree <= ToNextScene.score)
        {
            stars[3].SetActive(true);
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(ToNextScene.nextSceneToLoad);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, -(Mathf.Abs(Physics2D.gravity.y)));
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
