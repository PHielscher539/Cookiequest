using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakoHitbox : MonoBehaviour
{
    private GameObject Tako;
    // Start is called before the first frame update
    void Start()
    {
        Tako = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.gameObject.tag == "Boss" || enemy.gameObject.tag == "Minion")
        {
            if (Tako.GetComponent<Animator>().GetBool("TridentUpgrade") == true)
            {
                enemy.GetComponent<Health>().TakeDamage(25);

                return;
            }

            enemy.GetComponent<Health>().TakeDamage(50);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
