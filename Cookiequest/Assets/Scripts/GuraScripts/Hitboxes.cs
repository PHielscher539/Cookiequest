using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitboxes : MonoBehaviour
{
    public Transform ChargeAttackPoint;
    public Transform RaisePoint;
    public Transform GroundStabPoint;
    public float AttackRange = 0.5f;
    public LayerMask TakoLayer;

    void OnDrawGizmosSelected()
    {
        if (ChargeAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(ChargeAttackPoint.position, AttackRange);
        if (RaisePoint == null)
            return;
        Gizmos.DrawWireSphere(RaisePoint.position, AttackRange);
        if (GroundStabPoint == null)
            return;
        Gizmos.DrawWireSphere(GroundStabPoint.position, 0.3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TridentChargeHitbox()
    {
        Collider2D[] hitTako = Physics2D.OverlapCircleAll(ChargeAttackPoint.position, AttackRange, TakoLayer);

        foreach (Collider2D Tako in hitTako)
        {
            float difference = Tako.transform.position.x - ChargeAttackPoint.position.x;
            bool direction = false;
            if (difference>0)
            {
                direction = true;
            }
            Debug.Log(Tako.name + " got magged");
            Tako.GetComponent<TakoHealth>().TakeDamage(direction);
        }
    }

    public void GroundStabHitbox()
    {
        Collider2D[] hitTako = Physics2D.OverlapCircleAll(GroundStabPoint.position, AttackRange, TakoLayer);

        foreach (Collider2D Tako in hitTako)
        {
            float difference = Tako.transform.position.x - ChargeAttackPoint.position.x;
            bool direction = false;
            if (difference > 0)
            {
                direction = true;
            }
            Debug.Log(Tako.name + " got magged");
            Tako.GetComponent<TakoHealth>().TakeDamage(direction);
        }
    }

    public void TridentRaiseHitbox()
    {
        Collider2D[] hitTako = Physics2D.OverlapCircleAll(RaisePoint.position, AttackRange, TakoLayer);

        foreach (Collider2D Tako in hitTako)
        {
            float difference = Tako.transform.position.x - ChargeAttackPoint.position.x;
            bool direction = false;
            if (difference > 0)
            {
                direction = true;
            }
            Debug.Log(Tako.name + " got magged");
            Tako.GetComponent<TakoHealth>().TakeDamage(direction);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
