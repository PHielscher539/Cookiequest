using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Animator animator;
    public TakoMovement movement;
    public Transform firePoint;
    public GameObject ProjectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            movement.NotAFK();
            animator.SetBool("Spit", true); ;
        }
    }

    void Shoot()
    {
       Instantiate(ProjectilePrefab, firePoint.position, firePoint.rotation);
        animator.SetBool("Spit", false);
    }
}
