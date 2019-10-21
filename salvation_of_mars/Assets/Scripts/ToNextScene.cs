using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    public bool skipToNext;
    [HideInInspector]
    public static int nextSceneToLoad;
    public static float score;
    public static bool levelFinished;
    public GameObject levelCompleteUI;

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
        else if (pi.collectedCard)
        {
            if (scene.name == "Boost Unlock" || scene.name == "Clone_Unlock" || scene.name == "Gravity Unlock")
            {
                levelCompleteUI.SetActive(true);
            }
            else
            {
                levelFinished = true;
            }
        }
    }
}
