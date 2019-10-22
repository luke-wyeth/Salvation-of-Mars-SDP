using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSelect : MonoBehaviour
  
{
    public GameObject skillSelectUI;
    public static bool gravitySelected = false; //The next 3 are used in classes that control skill usage as well
    public static bool boostSelected = false;
    public static bool cloneSelected = false;
    public static bool skillSelected = false; //For pause menu script to refer to

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        skillSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReverseGravity()
    {
        gravitySelected = true;
        boostSelected = false;
        cloneSelected = false;
        Time.timeScale = 1f;
        skillSelectUI.SetActive(false);
        skillSelected = true;
    }

    public void Boost()
    {
        gravitySelected = false;
        boostSelected = true;
        cloneSelected = false;
        Time.timeScale = 1f;
        skillSelectUI.SetActive(false);
        skillSelected = true;
    }

    public void Clone()
    {
        gravitySelected = false;
        boostSelected = false;
        cloneSelected = true;
        Time.timeScale = 1f;
        skillSelectUI.SetActive(false);
        skillSelected = true;
    }
}
