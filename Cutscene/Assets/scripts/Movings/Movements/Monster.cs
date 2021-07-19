using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : BasePickUp
{
    private float anim = 0.0f;

    protected override void Init()
    {
        anim = Animator.StringToHash("Move");
    }

    public void SetNumMove(float num)
    {
        anim = num;
    }

    public void SetAnimToAttack()
    {
        animator.SetTrigger("Attack");
    }
}
