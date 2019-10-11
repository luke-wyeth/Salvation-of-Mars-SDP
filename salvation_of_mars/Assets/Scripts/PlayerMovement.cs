﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMoved = 0;
    public float speed = 40f;
    bool jumping;
    bool active = true;

    // these variables used for cooldown timer to prevent spamming abilities
    float lastReversed;
    float lastBoost;
    float nextReversed;
    float nextBoost;

    public Animator animator;

    // used to GET input from player
    // called each time updated
    void Update()
    {
        if(active)
        {
            horizontalMoved = Input.GetAxisRaw("Horizontal") * speed;

            // set animator to run or idle
            if(animator != null)
            {
                animator.SetFloat("Speed", Mathf.Abs(horizontalMoved));
            }

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            if (Input.GetButtonDown("Fire1")&& SkillSelect.gravitySelected) // activate ability1 (reverse gravity)
            {
                ReverseGrav();
            }
            if (Input.GetButtonDown("Fire2")&& SkillSelect.boostSelected) // activate ability2 (speed/sprint)
            {
                SpeedBoost();
            }
        }
        else
        {
            horizontalMoved = 0;
        }

    }

    // move character in this function
    void FixedUpdate()
    {
        // args: (movement, crouch yes/no, jump yes/no)
        controller.Move(horizontalMoved * Time.fixedDeltaTime, false, jumping);
        jumping = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void ReverseGrav() // called when button to use reverse gravity ability is triggered
    {
        if (Time.time > nextReversed) // has cooldown time passed?
        {
            Physics2D.gravity *= -1;
            controller.reverseGrav = !controller.reverseGrav;
            lastReversed = Time.time;
            nextReversed = lastReversed + 1f; // reset cooldown
        }
    }

    public void SpeedBoost() // called when button to use speed boost ability is triggered
    {
        if (Time.time > nextBoost) // has cooldown time passed?
        {
            controller.speedBoost = true;
            lastBoost = Time.time;
            nextBoost = lastBoost + 1f; // reset cooldown
        }
    }

    public void Jump()
    {
        jumping = true;
        animator.SetBool("IsJumping", true);
    }
   

}
