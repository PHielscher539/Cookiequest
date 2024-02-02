using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheIrysScript : MonoBehaviour
{
    public GameObject Warp1;
    public GameObject Warp2;
    public GameObject Warp3;
    public GameObject Warp4;
    public GameObject Warp5;
    public GameObject Warp6;
    public Animator animator;
    public Health myhealth;
    public Collider2D BaseCollider;
    public GameObject HOPEBEAMPREFAB;
    public GameObject LaserPrefab;
    public GameObject ExplodePrefab;
    public GameObject Dark;
    public GameObject Light;
    int i = 0;
    bool beamfired = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    void WarpOrigin()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    

    void CreateSumRawHope()
    {
        Instantiate(HOPEBEAMPREFAB, new Vector3(0, 0, 0), transform.rotation);
    }

    public void SpawnLaser()
    {
        Instantiate(LaserPrefab, new Vector3(transform.position.x + 0.2f, transform.position.y, 0), transform.rotation);
    }

    public void WarpXplode()
    {
        int Number = Random.Range(0, 2);
        if (Number == 0)
        {
            Instantiate(ExplodePrefab, new Vector3(transform.position.x, transform.position.y -0.5f, 0), transform.rotation);
        }
    }

    void TriggerWarp()
    {
        int Spot = animator.GetInteger("Warp");
        if (Spot == 0)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                Spot++;
            }
            else
            {
                transform.position = Warp1.transform.position;
            }
        }
        if (Spot == 1)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                Spot++;
            }
            else
            {
                transform.position = Warp2.transform.position;
            }
        }
        if (Spot == 2)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                Spot++;
            }
            else
            {
                transform.position = Warp3.transform.position;
            }
        }
        if (Spot == 3)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                Spot++;
            }
            else
            {
                transform.position = Warp4.transform.position;
            }
        }
        if (Spot == 4)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                Spot++;
            }
            else
            {
                transform.position = Warp5.transform.position;
            }
        }
        if (Spot == 5)
        {
            if (animator.GetInteger("PrevWarp") == Spot)
            {
                transform.position = Warp1.transform.position;
            }
            else
            {
                transform.position = Warp6.transform.position;
            }
        }

        animator.SetInteger("PrevWarp", Spot);
        animator.SetInteger("Warp", 20);
    }

    public void ShotWarpEnd()
    {
        animator.SetBool("ANOTHAONE", false);
    }

    public void ANOTHAONE()
    {
        int Number = Random.Range(0, 3);
        if (Number < 2)
        {
            animator.SetBool("ANOTHAONE", true);
            Number = Random.Range(0, 6);
            animator.SetInteger("Warp", Number);
        }
        else
        {
            animator.SetBool("ShootMode", false);
        }
    }

    public void TriggerHappy()
    {
        int Number = Random.Range(0, 100);
        if (Number < 40)
        {
            animator.SetBool("ShootMode", true);
        }
    }

    public void EnableBaseCollider()
    {
        BaseCollider.enabled = true;
    }

    public void DisableBaseCollider()
    {
        BaseCollider.enabled = false;
    }

    public void WarpPattern1()
    {
        transform.position = new Vector3(0, 2, 0);
    }
    public void Pattern1 ()
    {
        if (i == 0)
        {
            Instantiate(Dark, new Vector3(-6.5f, 0.7f, 0), transform.rotation);
            i++;
        }
        else if (i == 1)
        {
            Instantiate(Light, new Vector3(-4.5f, -2f, 0), Quaternion.Euler(0, 0, 45));
            i++;
        }
        else if (i == 2)
        {
            Instantiate(Dark, new Vector3(0f, -1.5f, 0), transform.rotation);
            i++;
        }
        else if (i == 3)
        {
            Instantiate(Light, new Vector3(4.5f, -2f, 0), Quaternion.Euler(0, 0, 45));
            i++;
        }
        else if (i == 4)
        {
            Instantiate(Dark, new Vector3(6.5f, 0.7f, 0), transform.rotation);
            i++;
        }
        else
        {
            i = 0;
        }



    }
    // Update is called once per frame
    void Update()
    {
        if (myhealth.currentHealth < myhealth.maxHealth * 0.5 && beamfired == false)
        {
            animator.SetBool("HOPEBEAM", true);
            beamfired = true;
        }
    }
}
