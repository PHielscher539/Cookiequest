using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoFight : MonoBehaviour
{
    public Animator animator;
    public TakoMovement movement;
    public GameObject TridentAttackPoint;
    public GameObject AttackPoint;
    public float MaxAttackCd;
    private float cd;


    public void AttacEnd()
    {
        if (animator.GetBool("TridentUpgrade") == true)
        {
            TridentAttackPoint.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            AttackPoint.GetComponent<Collider2D>().enabled = false;
        }

    }

    public void Attac()
    {
        if (animator.GetBool("TridentUpgrade") == true)
        {
            TridentAttackPoint.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            AttackPoint.GetComponent<Collider2D>().enabled = true;
        }
    }


        public void playSlap()
    {
        FindObjectOfType<AudioManager>().Play("Slap");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attacc") && cd <= 0)
        {
            movement.NotAFK();            
            cd = MaxAttackCd;
            animator.SetBool("Attacc", true);
        }
        cd -= Time.deltaTime;

    }
}
