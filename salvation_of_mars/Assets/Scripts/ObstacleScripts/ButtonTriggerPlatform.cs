using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerPlatform : MonoBehaviour
{
    public MovingPlatform platform;
    public bool permanent;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        platform.isActive = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!permanent)
        {
            platform.isActive = false;
        } 
    }
}
