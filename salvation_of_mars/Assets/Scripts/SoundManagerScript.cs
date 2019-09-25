
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public  AudioClip jumpSound,moveSound,boostSound,cloneSound,gravitySound;
    public  AudioSource jumpSrc,moveSrc,boostSrc,cloneSrc,gravitySrc;
    // Start is called before the first frame update
    void Start()
    {
        jumpSrc.clip = jumpSound;
        moveSrc.clip = moveSound;
        boostSrc.clip = boostSound;
        cloneSrc.clip = cloneSound;
        gravitySrc.clip = gravitySound;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpSrc.PlayOneShot(jumpSound);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            moveSrc.PlayOneShot(moveSound);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveSrc.PlayOneShot(moveSound);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            moveSrc.PlayOneShot(boostSound);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            moveSrc.PlayOneShot(cloneSound);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            moveSrc.PlayOneShot(gravitySound);
        }
    }
  
}

