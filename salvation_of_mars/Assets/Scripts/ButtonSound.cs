using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    //Different audios for different sounds
    public AudioSource myAudio;
    public AudioClip hoverAudio;
    public AudioClip clickAudio;

    //Play audio once a button is hovered over
    public void HoverButtonSound()
    {
        myAudio.PlayOneShot(hoverAudio);
    }

    //Play audio once a button is clicked
    public void ClickButtonSound()
    {
        myAudio.PlayOneShot(clickAudio);
    }
}
