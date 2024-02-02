using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAttackGura : StateMachineBehaviour
{
    private GameObject Tako = null;
    private GameObject Gura = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tako = GameObject.FindWithTag("Player");
        Gura = GameObject.FindWithTag("Boss");

        int Number = 20;

        if (animator.GetBool("Red") == true)
        {
            Number = 21;
        }
        else
        {
            Number = Random.Range(0, 11);
        }

        if (Number == 0 || Number == 1 || Number == 2 || Number == 3)
        {
            animator.SetBool("RunNext", true);
            if (Tako != null)
            {
                float difference = Tako.transform.position.x - Gura.transform.position.x;
                if (difference > -2 && difference < 2)
                {
                    animator.SetBool("RunNext", false);
                    animator.SetBool("SMASHNext", true);
                }
            }
        }
        if (Number == 4 || Number == 5)
        {
            animator.SetBool("RaiseNext", true);
        }

        if (Number == 6)
        {
            animator.SetBool("JumpNext", true);
        }
        if (Number == 7 || Number == 8)
        {
            if (animator.GetBool("SharkOnCd") == false)
            {
                animator.SetBool("SharkNext", true);
            }
            else
            {
                animator.SetBool("RunNext", true);
                if (Tako != null)
                {
                    float difference = Tako.transform.position.x - Gura.transform.position.x;
                    if (difference > -2 && difference < 2)
                    {
                        animator.SetBool("RunNext", false);
                        animator.SetBool("SMASHNext", true);
                    }
                }
            }
        }
        if (Number == 9 || Number == 10)
        {
            animator.SetBool("EbiNext", true);
            if (Tako != null)
            {
                float difference = Tako.transform.position.x - Gura.transform.position.x;
                if (difference > -2 && difference < 2)
                {
                    animator.SetBool("EbiNext", false);
                    animator.SetBool("SMASHNext", true);
                }
            }
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}
