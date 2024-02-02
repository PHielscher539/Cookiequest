using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeGura : MonoBehaviour
{
    private GameObject Tako = null;
    private bool direction = false;
    private bool isCharging = false;
    public Collider2D FirstOne;
    public Collider2D SecondOne;
    public Collider2D ThirdOne;
    public Animator animator;
    public GameObject WoahPrefab;
    public GameObject TridentPrefab;
    public GameObject WaterfallTriggerObject;
    public GameObject SharkTriggerObject;
    public GameObject TransfoPrefab;
    public GameObject EbiPrefab;
    public Health myhealth;
    float Sharkcd = 0;
    float maxSharkcd = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Tako = GameObject.FindWithTag("Player");
    }

    public void WhereTako()
    {
        if (Tako != null)
        {
            float difference = Tako.transform.position.x - transform.position.x;
            direction = false;
            if (difference > 0)
            {
                direction = true;
            }
        }
    }

    void StopCharge()
    {
        animator.SetBool("RunNext", false);
        isCharging = false;       
    }

    void GETROTATED()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    public void charge()
    {
        isCharging = true;
    }

    public void Waterfall()
    {
        WaterfallTrigger Trigger = WaterfallTriggerObject.GetComponent<WaterfallTrigger>();
        Trigger.SpawnWaterfall();
    }

    public void Shark()
    {
        Shorktrigger Trigger = SharkTriggerObject.GetComponent<Shorktrigger>();
        Trigger.SpawnBloop();
        animator.SetBool("SharkOnCd", true);
        Sharkcd = maxSharkcd;
    }

    public void Woah()
    {
        Instantiate(WoahPrefab, new Vector3(transform.position.x + 1.1f, -2.9f, 0), transform.rotation);
        Instantiate(WoahPrefab, new Vector3(transform.position.x - 1.1f, -2.9f, 0), transform.rotation);
    }

    public void UnlimitedBladeWorks()
    {
        if (Tako != null)
        {
            if (transform.position.x > 0)
            {
                Instantiate(TridentPrefab, new Vector3(7, 2.5f, 0), transform.rotation);
            }
            else
            {
                Instantiate(TridentPrefab, new Vector3(-7, 2.5f, 0), transform.rotation);
            }
        }
    }

    public void SpawnEbi()
    {
        Instantiate(EbiPrefab, new Vector3(transform.position.x, -2.9f, 0), transform.rotation);
    }

    public void EnableFirst()
    {
        FirstOne.enabled = true;
    }

    public void EnableSecond()
    {
        SecondOne.enabled = true;
    }

    public void EnableThird()
    {
        ThirdOne.enabled = true;
    }

    public void DisableFirst()
    {
        FirstOne.enabled = false;
    }

    public void DisableSecond()
    {
        SecondOne.enabled = false;
    }

    public void DisableThird()
    {
        ThirdOne.enabled = true;
    }

    public void TriggerTransfo()
    {
        Instantiate(TransfoPrefab, new Vector3(0, 0, 0), transform.rotation);
    }

    public void EndTransfo()
    {
        animator.SetBool("Red", false);
        animator.SetBool("RedState", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isCharging == true)
        {
            if (direction == true)
            {
                transform.position += new Vector3(0.2f, 0, 0);
                if (animator.GetBool("RedState"))
                {
                    transform.position += new Vector3(0.23f, 0, 0);
                }
            }
            else if (direction == false)
            {
                transform.position += new Vector3(-0.2f, 0, 0);
                if (animator.GetBool("RedState"))
                {
                    transform.position += new Vector3(-0.23f, 0, 0);
                }
            }
        }
        if (transform.position.x > 7 || transform.position.x < -7)
        {
            StopCharge();
            GETROTATED();
            if (direction == true)
            {
                transform.position = new Vector3(7, transform.position.y, 0);
                if (myhealth.currentHealth < myhealth.maxHealth * 0.6 && animator.GetBool("Red") == false && animator.GetBool("RedState") == false)
                {
                    animator.SetBool("Red", true);
                }
            }
            else if (direction == false)

            {
                transform.position = new Vector3(-7, transform.position.y, 0);
            }
        }
    }

    void Update()
    {
        Sharkcd -= Time.deltaTime;
        if (Sharkcd <= 0)
        {
            animator.SetBool("SharkOnCd", false);
        }
        if (animator.GetBool("RedState") == true)
        {
            if (animator.GetBool("SharkOnCd") == false)
            {
                int Number = Random.Range(0, 4);
                if (Number == 0)
                {
                    Shark();
                }
                else
                {
                    Waterfall();
                }
                animator.SetBool("SharkOnCd", true);
                Sharkcd = maxSharkcd;
            }
        }
    }
}

