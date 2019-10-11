using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip clickAudio;

    //Play audio once a button is clicked
    public void ClickButtonSound()
    {
        myAudio.PlayOneShot(clickAudio);
    }
}
