using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    public static float nextSceneToLoad;
    public static float score;
    public static bool levelFinished;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        levelFinished = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if(pi.collectedCard)
        {
            score = Time.timeSinceLevelLoad;
            levelFinished = true;
            //SceneManager.LoadScene(nextSceneToLoad);
        } 
    }
}
