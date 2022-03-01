using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void isMoving(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    public void isJumping(bool isJumping)
    {
        animator.SetBool("isJumping", isJumping);
    }

    public void isDancing(bool isDancing)
    {
        animator.SetBool("isDancing", isDancing);
    }

    public void isAttacking(bool isAttacking)
    {
        animator.SetBool("isAttacking", isAttacking);
    }
}
