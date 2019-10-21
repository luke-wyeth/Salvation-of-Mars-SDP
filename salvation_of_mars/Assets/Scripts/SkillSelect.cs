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
        if(PauseMenu.skillSelectOff == false)
        {
            skillSelectUI.SetActive(true);
        }
        if (PauseMenu.skillSelectOff == true)
        {
            skillSelectUI.SetActive(false);
        }
        if(skillSelected)
        {
            skillSelectUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ReverseGravity()
    {
        gravitySelected = true;
        boostSelected = false;
        cloneSelected = false;

        skillSelected = true;
    }

    public void Boost()
    {
        gravitySelected = false;
        boostSelected = true;
        cloneSelected = false;
        skillSelected = true;
    }

    public void Clone()
    {
        gravitySelected = false;
        boostSelected = false;
        cloneSelected = true;
        skillSelected = true;
    }
}
