using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoHealth : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public CharacterController2D controller;
    public Animator animator;
    public GameObject spot1;
    public GameObject spot2;
    public GameObject spot3;
    public GameObject CookiePrefab;
    public GameObject HalfCookiePrefab;
    private GameObject cookie1 = null;
    private GameObject cookie2 = null;
    private GameObject cookie3 = null;
    private float invultime = 0;
    private float MAXinvultime = 1.5f;
    public Rigidbody2D rb;
    public TakoMovement mvmt;
    public Collider2D colli1;
    public Collider2D colli2;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        DrawHealth();
    }

    public void TakeDamage(bool direction)
    {
        if (invultime <= 0)
        {
            currentHealth -= 1;
            DrawHealth();
            mvmt.hitstun = true;
            Physics.IgnoreLayerCollision(6, 7, true);
            Physics.IgnoreLayerCollision(6, 8, true);
            rb.velocity = Vector2.zero;
            if (direction == false)
            {
                if (controller.IsFacingLeft() == true)
                {
                    controller.Flip();
                }
                rb.AddForce(new Vector2(-200f, 400f));
            }
            else if (direction == true)
            {
                if (controller.IsFacingLeft() == false)
                {
                    controller.Flip();
                }
                rb.AddForce(new Vector2(200f, 400f));
            }

            if (currentHealth <= 0)
            {
                Sudoku();
            }
            invultime = MAXinvultime;
        }
        if (animator.GetBool("Squish") == false && animator.GetBool("SquishMax") == false )
        {
            animator.SetBool("OOF", true);
        }
    }

    public void Sudoku()
    {
        currentHealth = 0;
        DrawHealth();
        Debug.Log("Death");
        colli1 = GetComponent<Collider2D>();
        rb.AddForce(new Vector2(0, 100));
        colli1.enabled = false;
        colli2.enabled = false;
        mvmt.lockout = true;
        transform.Rotate(180f, 0f, 0f);
    }

    void DrawHealth()
    {
        IRLQSS();

        if (currentHealth==1)
        {
            cookie1 = Instantiate(HalfCookiePrefab, spot1.transform.position, spot1.transform.rotation);
        }
        else if (currentHealth == 2)
        {
            cookie1 = Instantiate(CookiePrefab, spot1.transform.position, spot1.transform.rotation);
        }
        else if (currentHealth == 3)
        {
            cookie1 = Instantiate(CookiePrefab, spot1.transform.position, spot1.transform.rotation);
            cookie2 = Instantiate(HalfCookiePrefab, spot2.transform.position, spot2.transform.rotation);
        }
        else if (currentHealth == 4)
        {
            cookie1 = Instantiate(CookiePrefab, spot1.transform.position, spot1.transform.rotation);
            cookie2 = Instantiate(CookiePrefab, spot2.transform.position, spot2.transform.rotation);
        }
        else if (currentHealth == 5)
        {
            cookie1 = Instantiate(CookiePrefab, spot1.transform.position, spot1.transform.rotation);
            cookie2 = Instantiate(CookiePrefab, spot2.transform.position, spot2.transform.rotation);
            cookie3 = Instantiate(HalfCookiePrefab, spot3.transform.position, spot3.transform.rotation);
        }
        else if (currentHealth == 6)
        {
            cookie1 = Instantiate(CookiePrefab, spot1.transform.position, spot1.transform.rotation);
            cookie2 = Instantiate(CookiePrefab, spot2.transform.position, spot2.transform.rotation);
            cookie3 = Instantiate(CookiePrefab, spot3.transform.position, spot3.transform.rotation);
        }

    }

    void IRLQSS()
    {
        if (cookie1 != null)
        {
            Destroy(cookie1);
        }
        if (cookie2!= null)
        {
            Destroy(cookie2);
        }
        if (cookie3 != null)
        {
            Destroy(cookie3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        invultime -= Time.deltaTime;
        if (invultime - 0.75f <=0)
        {
            mvmt.hitstun = false;
            Physics.IgnoreLayerCollision(6, 7, false);
            Physics.IgnoreLayerCollision(6, 8, false);
            if (currentHealth > 0)
            {
                animator.SetBool("OOF", false);
            }
        }
    }
}
