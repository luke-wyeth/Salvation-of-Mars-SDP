using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveFunction : MonoBehaviour
{
    void Start() // saves automatically on level startup
    {
        int level = SceneManager.GetActiveScene().buildIndex; // get current level
        PlayerPrefs.SetInt("Level", level); // save current level
    }
}
