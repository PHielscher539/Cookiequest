using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdkAtThisPoint : StateMachineBehaviour
{
    private GameObject Tako = null;
    private GameObject Gura = null;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tako = GameObject.FindWithTag("Player");
        Gura = GameObject.FindWithTag("Boss");

        int Number = Random.Range(0, 7);
        if (Number == 0 || Number == 1 || Number == 2 || Number == 3)
        {
            Debug.Log("yes");
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
        if (Number == 4)
        {
            Debug.Log("YES");
            animator.SetBool("JumpNext", true);
        }
        if (Number == 5 || Number == 6)
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

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
