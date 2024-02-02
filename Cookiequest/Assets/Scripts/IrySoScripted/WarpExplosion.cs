using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpExplosion : MonoBehaviour
{
    public Collider2D hitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HitboxActive()
    {
        hitbox.enabled = true;
    }

    public void HitboxNotActive()
    {
        hitbox.enabled = false;
    }

    public void Sudoku()
    {
        Destroy(this.gameObject);
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
