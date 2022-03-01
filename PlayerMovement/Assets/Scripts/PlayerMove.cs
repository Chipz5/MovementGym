using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : PlayerStateBase
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetPlayerControl(animator).audioSource.clip = GetPlayerControl(animator).moveClip;
        GetPlayerControl(animator).audioSource.Play();
        animator.SetBool("isJumping", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (dir.magnitude < 0.001f)
        {
            animator.SetBool("isMoving", false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isDancing", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("isAttacking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetPlayerControl(animator).audioSource.Stop();
    }

}
