using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    public GameObject levelCompleteUI;
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Scene scene = SceneManager.GetActiveScene();
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if (scene.name == "Story1" || scene.name == "Story2")
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }

        //AbilityUnlock levels should be only be completable when collectedCard and abilityUnlock are true
        else if (scene.name == "CloneUnlock")
        {
            if (pi.collectedCard && pi.abilityUnlock)
            {
                Time.timeScale = 0f;
                levelCompleteUI.SetActive(true);
            }
            else
            {
                //do nothing when  user does not have keycard and ability
            }
        }
        else if (pi.collectedCard)
        {
            Time.timeScale = 0f;
            levelCompleteUI.SetActive(true);
        }
    }
}
