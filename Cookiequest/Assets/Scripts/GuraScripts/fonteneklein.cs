using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fonteneklein : MonoBehaviour
{
    public Collider2D FirstOne;
    public Collider2D SecondOne;

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
            Debug.Log("Dont do it man!");
        }
    }

    public void EnableFirst()
    {
        FirstOne.enabled = true;
    }

    public void EnableSecond()
    {
        SecondOne.enabled = true;
    }

    public void DisableFirst()
    {
        FirstOne.enabled = false;
    }

    public void DisableSecond()
    {
        SecondOne.enabled = false;
    }

    public void Sudoku()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
