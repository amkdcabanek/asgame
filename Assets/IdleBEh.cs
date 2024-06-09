using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBEh : StateMachineBehaviour
{
    float timer;
    Transform player;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            animator.SetBool("IsPatroling", true);
        }
        else
        {
            animator.SetBool("IsPatroling", false);
        }
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance <= 10)
        {
            animator.SetBool("IsChasing", true);
        }
        else
        {
            animator.SetBool("IsChasing", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
    }
}
