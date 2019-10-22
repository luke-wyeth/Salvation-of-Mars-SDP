    using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    //public bool skipToNext;
    //[HideInInspector]
    public static int nextSceneToLoad;
    public static float score;
    public static bool levelFinished;
    public GameObject levelCompleteUI;
    public GameObject tutorialCompleteUI;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        levelFinished = false;
        score = 0.0f;
    }

    void Update()
    {
        score += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if (scene.name == "Story1" || scene.name == "Story2")
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
        else if(scene.name == "CloneUnlock" || scene.name == "GravityUnlock" || scene.name == "BoostUnlock")
        {
            if(pi.collectedCard && pi.abilityUnlock)
            {
                Time.timeScale = 0f;
                levelCompleteUI.SetActive(true);
            }
        }
        else if(scene.name == "BoostTutorial" || scene.name == "Bre_Lvl_1" || scene.name == "GravityTutorial" || scene.name == "GravTutorial" || scene.name == "ThrowTutorial")
        {
            if (pi.collectedCard)
            {
                Time.timeScale = 0f;
                tutorialCompleteUI.SetActive(true);
            }
        }
        else if (pi.collectedCard)
        {
            levelFinished = true;
        }
    }
}
