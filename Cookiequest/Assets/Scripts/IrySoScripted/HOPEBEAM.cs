using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HOPEBEAM : MonoBehaviour
{
    private GameObject Irys;
    public Collider2D Hitbox;
    public GameObject BurnGroundPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Irys = GameObject.FindWithTag("Boss");
    }

    public void AfterBeam()
    {
        Irys.GetComponent<Animator>().SetBool("HOPEBEAM", false);
        Irys.GetComponent<TheIrysScript>().EnableBaseCollider();
        Irys.GetComponent<Animator>().SetInteger("Warp", 4);
        Irys.transform.position = new Vector3(0, 60, 0);
        Destroy(this.gameObject);
    }

    public void EnableHitbox()
    {
        Hitbox.enabled = true;
    }

    public void DisableHitbox()
    {
        Hitbox.enabled = false;
    }

    public void BurnGround()
    {
        Instantiate(BurnGroundPrefab, new Vector3(0, 0, 0), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D ElTako)
    {
        TakoHealth Tako = ElTako.GetComponent<TakoHealth>();
        if (Tako != null)
        {
            Tako.Sudoku();
            Destroy(ElTako.gameObject);
            Debug.Log("DOOM!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
