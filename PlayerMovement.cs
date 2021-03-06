﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       
       animator.SetFloat("speed", Mathf.Abs(horizontalMove));
       
       if(Input.GetButtonDown("Jump"))
       {
           jump = true;
           animator.SetBool("isJumping", true);
       }

       if (Input.GetButtonDown("Crouch"))
       {
           crouch = true;
       } else if (Input.GetButtonUp("Crouch"))
       {
           crouch = false;
       }
       
    }
    
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
}
