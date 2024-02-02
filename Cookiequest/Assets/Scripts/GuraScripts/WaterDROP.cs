using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDROP : MonoBehaviour
{
    public Collider2D FirstOne;
    public Collider2D SecondOne;
    public Collider2D ThirdOne;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

    public void EnableThird()
    {
        ThirdOne.enabled = true;
    }

    public void DisableFirst()
    {
        FirstOne.enabled = false;
    }

    public void DisableSecond()
    {
        SecondOne.enabled = false;
    }

    public void DisableThird()
    {
        ThirdOne.enabled = false;
    }

    public void sudoku()
    {
        Destroy(this.gameObject);
    }
}
