using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shorktrigger : MonoBehaviour
{
    public GameObject SHORKPrefab;
    private GameObject Tako = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnBloop()
    {
        Tako = GameObject.FindWithTag("Player");
        if (Tako != null)
        {
            Instantiate(SHORKPrefab, new Vector3(Tako.transform.position.x, 0, 0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
