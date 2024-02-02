using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D Anything)
    {
        Destroy(Anything.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
