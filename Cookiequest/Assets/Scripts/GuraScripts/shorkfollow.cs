using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shorkfollow : MonoBehaviour
{
    private GameObject Tako = null;
    private bool follow = true;
    public Collider2D FirstOne;
    public Collider2D SecondOne;

    // Start is called before the first frame update
    void Start()
    {
        Tako = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Tako != null)
        {
            if (follow == true)
            {
                transform.position = new Vector3(Tako.transform.position.x, 0, 0);
            }
        }
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
            Debug.Log("nom");
        }
    }

    public void playChomp()
    {
        FindObjectOfType<AudioManager>().Play("Chomp");
    }

    public void stopFollow()
    {
        follow = false;
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

    public void sudoku()
    {
        Destroy(this.gameObject);
    }
}
