using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalGirlTransformation : MonoBehaviour
{
    private GameObject Gura = null;
    private Renderer rend = null;
    
    void Start()
    {
        Gura = GameObject.FindWithTag("Boss");
        rend = Gura.GetComponent<Renderer>();
        rend.enabled = false;
    }

    public void backfromvoid()
    {
        rend.enabled = true;
        ChargeGura scriptus = Gura.GetComponent<ChargeGura>();
        scriptus.EndTransfo();
    }
    public void sudoku()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
