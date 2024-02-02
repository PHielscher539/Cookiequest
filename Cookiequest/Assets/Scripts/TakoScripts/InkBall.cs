using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkBall : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    private CharacterController2D controller;
    private bool splarfed = false;


    void Start()
    {
        controller = GameObject.Find("Tako").GetComponent<CharacterController2D>();

        if (controller.IsFacingLeft() == false)
        {
            rb.AddForce(new Vector2(speed, speed));
        }
        else
        {
            rb.AddForce(new Vector2( -speed, speed));
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Health enemy = hitInfo.GetComponent<Health>();
        transform.localScale += new Vector3(0.5f, 0.5f,0);
        if (enemy != null && splarfed == false)
        {
            enemy.TakeDamage(40);
            Debug.Log("Splarf!");           
        }
        if (hitInfo.tag == "Ground")
        {
            transform.position += new Vector3(0, -0.4f, 0);
            Destroy(rb);
        }
        else
        {
            if (rb != null)
            rb.velocity *= 0.3f;
        }
        if (splarfed == false)
        {
            FindObjectOfType<AudioManager>().Play("InkSplat");
        }
        animator.SetBool("Oof", true);
        splarfed = true;
    }
     public void Sudoku()
    {
        Destroy(gameObject);
    }

}
