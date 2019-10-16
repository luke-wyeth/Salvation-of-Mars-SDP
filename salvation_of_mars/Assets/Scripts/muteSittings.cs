using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteSittings
{
    public GameObject muteControlButton;
    public Sprite audioOffSprite;
    public Sprite audioOnSprite;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {

    }

    public void muteControl()
    {
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
            
        }
        else
        {
            AudioListener.pause = true;
           
        }
    }
}
