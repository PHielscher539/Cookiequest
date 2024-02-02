using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burnground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D ElTako)
    {
        TakoHealth Tako = ElTako.GetComponent<TakoHealth>();
        if (Tako != null)
        {
            float difference = Tako.transform.position.x - transform.position.x;
            bool direction = false;
            if (difference > 0)
            {
                direction = true;
            }
            Tako.TakeDamage(direction);
            Debug.Log("Damn Son!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
