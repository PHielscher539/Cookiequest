using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool IsMinion;
    private float invultime = 0;
    private float MAXinvultime = 0.2f;
    public bool ded = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (IsMinion == false)
        {
            GameObject healthBar = GameObject.FindWithTag("HealthBar");
            HealthBar healthScript = healthBar.GetComponent<HealthBar>();
            healthScript.SetMaxHealth(maxHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        if (invultime <= 0)
        {
            currentHealth -= damage;
            if (IsMinion == false)
            {
                GameObject healthBar = GameObject.FindWithTag("HealthBar");
                HealthBar healthScript = healthBar.GetComponent<HealthBar>();
                healthScript.SetHealth(currentHealth);
            }

            if (currentHealth <= 0)
            {
                if (IsMinion == true)
                {
                    Rigidbody2D rb = GetComponent<Rigidbody2D>();
                    Collider2D colli = GetComponent<Collider2D>();
                    rb.AddForce(new Vector2(0, 100));
                    colli.enabled = false;
                    ded = true;
                    transform.Rotate(180f, 0f, 0f);
                }
                else
                {
                    Sudoku();
                }
            }

            invultime = MAXinvultime;
        }        
    }

    void Sudoku()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        invultime -= Time.deltaTime;
    }
}
