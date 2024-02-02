using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Irys_Laser : MonoBehaviour
{
    private GameObject Tako = null;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Tako = GameObject.FindWithTag("Player");
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
        transform.position -= direction * 0.25f;
    }
}
