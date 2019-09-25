using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadFunction : MonoBehaviour
{
    public void LoadSave()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }
}

