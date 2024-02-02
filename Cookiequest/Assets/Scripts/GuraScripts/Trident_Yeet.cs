using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trident_Yeet : MonoBehaviour
{
    private GameObject Tako = null;
    private GameObject Gura = null;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Tako = GameObject.FindWithTag("Player");
        Gura = GameObject.FindWithTag("Boss");
        Gura.GetComponent<Animator>().GetBool("RedState");
        if (Tako != null)
        {
            Quaternion rotation = Quaternion.LookRotation(Tako.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            direction = (this.transform.position - Tako.transform.position).normalized;
            if (this.transform.position.x < Tako.transform.position.x)
            {                
                    transform.Rotate(0f, 180f, 0f);
            }
        }
        FindObjectOfType<AudioManager>().Play("Throw");

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
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
    void FixedUpdate()
    {
        if (Gura != null)
        {
            if (Gura.GetComponent<Animator>().GetBool("RedState") == true)
            {
                transform.position -= direction * 0.55f;
            }
            else
            {
                transform.position -= direction * 0.4f;
            }
        }
    }
}
