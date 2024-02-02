using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallTrigger : MonoBehaviour
{
    public GameObject WaterfallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnWaterfall()
    {
        int Number = Random.Range(0, 3);
        if (Number == 0)
        {
            Instantiate(WaterfallPrefab, new Vector3(-5, 0, 0), transform.rotation);
        }
        if (Number == 1)
        {
            Instantiate(WaterfallPrefab, new Vector3(0, 0, 0), transform.rotation);
        }
        if (Number == 2)
        {
            Instantiate(WaterfallPrefab, new Vector3(5, 0, 0), transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
