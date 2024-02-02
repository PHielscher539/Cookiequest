using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExplodeIrys : MonoBehaviour
{
    public Collider2D hitboxInner;
    public Collider2D hitboxOuter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void HitboxActiveInner()
    {
        hitboxInner.enabled = true;
    }

    public void HitboxActiveOuter()
    {
        hitboxOuter.enabled = true;
    }

    public void HitboxNotActiveInner()
    {
        hitboxInner.enabled = false;
    }

    public void HitboxNotActiveOuter()
    {
        hitboxOuter.enabled = false;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
