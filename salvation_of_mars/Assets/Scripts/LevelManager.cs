using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager:MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

}
