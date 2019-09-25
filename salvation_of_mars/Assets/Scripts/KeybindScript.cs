using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindScript : MonoBehaviour
{
    //Keycode, string for the name of the movement and keycode for the keyboard input to activate it
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    //public TMP_Text jump, left, right, ability, pause, restart;

    private GameObject currentKey;
    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Jump", KeyCode.W);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Ability", KeyCode.Space);
        keys.Add("Pause", KeyCode.Escape);
        keys.Add("Restart", KeyCode.R);

        //jump.text = keys["Jump"].ToString();
        //left.text = keys["Left"].ToString();
        //right.text = keys["Right"].ToString();
        //ability.text = keys["Ability"].ToString();
        //pause.text = keys["Pause"].ToString();
        //restart.text = keys["Restart"].ToString();
    }

    // Update is called once per frame
    //Recieves User's keyboard input and prints out the movement it should make
    void Update()
    {
        if (Input.GetKeyDown(keys["Jump"]))
        {
            Debug.Log("Jump");
        }
        if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("Right");
        }
        if (Input.GetKeyDown(keys["Ability"]))
        {
            Debug.Log("Ability");
        }
        if (Input.GetKeyDown(keys["Pause"]))
        {
            Debug.Log("Pause");
        }
        if (Input.GetKeyDown(keys["Restart"]))
        {
            Debug.Log("Restart");
        }
    }

    //Replaces the keybindtext with the the user's keyboard input
    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e  = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;  
               // currentKey.transform.GetChild(0).GetComponent<TMP_Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    //changing of keybinds
    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}
