using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed;
    bool jump = false;
    private float chargeCounter;
    public float maxCharge;
    private float AFKCounter;
    public float maxAFKCounter;
    public Animator animator;
    private float SquishrunSpeed;
    private float normalrunspeed;
    public bool lockout = false;
    public bool hitstun = false;

    // Start is called before the first frame update
    void Start()
    {
        AFKCounter = maxAFKCounter;
        SquishrunSpeed = runSpeed/2;
        normalrunspeed = runSpeed;
}

    // Update is called once per frame
    void Update()
    {
        
        if (Mathf.Abs(horizontalMove) == 0)
        {
            if (AFKCounter <= 0)
            {
                animator.SetBool("AFK", true);
                AFKCounter = maxAFKCounter;
            }
            if (animator.GetBool("AFK") == false)
            {
                AFKCounter -= Time.deltaTime;
            }
        }
        else
        {
            AFKCounter = maxAFKCounter;
            animator.SetBool("AFK", false);
        }
        
         horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
         animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        

        if (Input.GetButtonDown("Jump") && jump == false)
        {
            chargeCounter = maxCharge;
            controller.resetJumpForce();
            runSpeed = SquishrunSpeed;

        }
        if (Input.GetButton("Jump") && jump==false)
        {
            if (chargeCounter > 0)
            {
                chargeCounter -= Time.deltaTime;
                animator.SetBool("Squish", true);
            }
            if (chargeCounter <= 0)
            {
                animator.SetBool("SquishMax", true);
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            if (chargeCounter <= 0)
            {
                controller.setJumpForce(850);
            }
            else if (chargeCounter < 0.4)
            {
                controller.setJumpForce(700);
            }
            else if (chargeCounter < 0.85)
            {
                controller.setJumpForce(410);
            }
            else
            {
                controller.setJumpForce(200);
            }

            jump = true;
            runSpeed = normalrunspeed;
            animator.SetBool("Squish", false);
            animator.SetBool("SquishMax", false);
        }

    }

    public void NotAFK()
    {
        AFKCounter = maxAFKCounter;
    }

    void FixedUpdate()
    {
        if (lockout == false && hitstun ==false)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        jump = false;


    }
}
