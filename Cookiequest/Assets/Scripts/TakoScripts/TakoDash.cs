using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoDash : MonoBehaviour
{
    public CharacterController2D controller;
    public TakoMovement mvmt;
    public Animator animator;
    private Rigidbody2D rb;
    private Renderer rend;
    private float dashTime;
    private float dashcd;
    public float startDashTime;
    public float CooldownTime;
    private int direction;
    private int DashAmountMax = 1;
    private int DashAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rend = GameObject.FindWithTag("Speedlines").GetComponent<Renderer>() ;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    public void TakoWarp()
    {
        if (direction == 1)
        {
            transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y, 0);
        }

        else if (direction == 3)
        {
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.m_Grounded == true)
        {
            DashAmount = DashAmountMax;
        }

        if (DashAmount > 0 && dashcd <= 0)
        {
            if (direction == 0 && Input.GetAxis("Dash") > 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    direction = 1;
                    dashTime = startDashTime;
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    direction = 3;
                    dashTime = startDashTime;
                }

            }

            else
            {              
                if (Input.GetAxis("Dash") > 0 || dashTime < startDashTime)
                {
                    if (dashTime <= 0 || mvmt.hitstun == true)
                    {
                        direction = 0;
                        dashTime = startDashTime;
                        DashAmount -= 1;
                        dashcd = CooldownTime;
                        rend.enabled = false;
                        mvmt.lockout = false;
                        rb.gravityScale = 2f;
                    }
                    else
                    {                        
                        rb.gravityScale = 0f;

                        dashTime -= Time.deltaTime;
                        if (animator.GetBool("WarpUpgrade") == true)
                        {
                            animator.SetBool("IsWarping", true);
                        }
                        else
                        {
                            mvmt.lockout = true;
                            rb.velocity = Vector2.zero;
                            rend.enabled = true;
                            
                            if (direction == 1)
                            {
                                controller.Move(200 * Time.fixedDeltaTime, false, false);
                            }
                            else if (direction == 3)
                            {
                                controller.Move(-200 * Time.fixedDeltaTime, false, false);
                            }
                        }
                        
                    }
                }
            }
        }
        dashcd -= Time.deltaTime;
    }
}
