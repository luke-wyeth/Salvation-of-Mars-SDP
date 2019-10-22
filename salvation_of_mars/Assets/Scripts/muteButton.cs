using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muteButton : MonoBehaviour
{
	public GameObject muteControlButton;
	public Sprite audioOffSprite;
	public Sprite audioOnSprite;

	// Start is called before the first frame update
	void Start()
	{
		if (AudioListener.pause == true)
		{
			muteControlButton.GetComponent<Image>().sprite = audioOffSprite;
		}
		else
		{
			muteControlButton.GetComponent<Image>().sprite = audioOnSprite;
		}

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void muteControl()
	{
		if (AudioListener.pause == true)
		{
			AudioListener.pause = false;
			muteControlButton.GetComponent<Image>().sprite = audioOnSprite;
		}
		else
		{
			AudioListener.pause = true;
			muteControlButton.GetComponent<Image>().sprite = audioOffSprite;
		}
	}
}