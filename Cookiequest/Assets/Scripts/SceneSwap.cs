using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public string Scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(Scenename);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
