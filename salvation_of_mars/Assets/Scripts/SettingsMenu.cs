using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public AudioMixer SECMixer;

	public void SetVolume(float volume)
	{
        audioMixer.SetFloat("Volume", volume);
	}

    public void SetSECvolume(float volume)
    {
        SECMixer.SetFloat("SECvolume", volume);
    }
}
