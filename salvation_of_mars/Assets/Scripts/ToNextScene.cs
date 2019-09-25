using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToNextScene : MonoBehaviour
{
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInfo pi = collision.gameObject.GetComponent<PlayerInfo>();

        if(pi.collectedCard)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        } 
    }
}
