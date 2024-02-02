using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EbiJump : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rb;
    public Collider2D colli;
    private GameObject Tako;
    private bool direction;
    private float difference;
    public float AttackRange;
    public LayerMask enemyLayer;

    void Start()
    {
        Tako = GameObject.Find("Tako");
        if (Tako != null)
        {
            difference = Tako.transform.position.x - transform.position.x;
        }
        direction = false;
        if (difference > 0)
        {
            direction = true;
        }

        if (direction == false)
        {
            rb.AddForce(new Vector2(-speed, speed));
        }
        else
        {
            rb.AddForce(new Vector2(speed, speed));
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (direction == true)

        {
            transform.position += new Vector3(0.05f, 0, 0);
        }
        else if (direction == false)

        {
            transform.position += new Vector3(-0.05f, 0, 0);
        }

        if (GetComponent<Health>().ded == false)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, AttackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemies)
            {
                if (Tako != null )
                {
                    float difference = Tako.transform.position.x - transform.position.x;
                    bool direction = false;
                    if (difference > 0)
                    {
                        direction = true;
                    }
                    Tako.GetComponent<TakoHealth>().TakeDamage(direction);
                    Debug.Log("Ebi'd!");
                    GetComponent<Health>().TakeDamage(100);

                }
            }
        }

    }
}
