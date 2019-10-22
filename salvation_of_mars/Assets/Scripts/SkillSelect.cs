using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    public GameObject skillSelectUI;
    public static bool gravitySelected = false; //The next 3 are used in classes that control skill usage as well
    public static bool boostSelected = false;
    public static bool cloneSelected = false;
    public static bool skillSelected = false; //For pause menu script to refer to
    public bool hasBoost;
    public bool hasGrav;
    public bool hasClone;
    public static bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        skillSelected = false;
        isActive = true;
        gravitySelected = false;
        boostSelected = false;
        cloneSelected = false;
}

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.skillSelectOff == false)
        {
            skillSelectUI.SetActive(true);
            Time.timeScale = 0f;
            //isActive = true;
        }
        if (PauseMenu.skillSelectOff == true)
        {
            skillSelectUI.SetActive(false);
            //isActive = true;
        }
        if(skillSelected)
        {
            skillSelectUI.SetActive(false);
            Time.timeScale = 1f;
            isActive = false;
        }
        if(!skillSelected)
        {
            //isActive = true;
            keyboardInput();
        }
        if(!skillSelected)
        {
            keyboardInput();
        }
    }

    public void keyboardInput()
    {
        if(Input.GetButtonDown("Fire1")&&hasGrav)
        {
            ReverseGravity();
        }
        if (Input.GetButtonDown("Fire2")&&hasBoost)
        {
            Boost();
        }
        if (Input.GetButtonDown("Fire3")&&hasClone)
        {
            Clone();
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
