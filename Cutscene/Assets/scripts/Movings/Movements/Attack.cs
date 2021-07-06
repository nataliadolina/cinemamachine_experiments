using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MovementBase
{
    [SerializeField] float timeBeetweenAttacks;
    private int harm;

    private float currentTime = 0f;
    private Player player;

    protected override void Init()
    {
        player = FindObjectOfType<Player>();
        BasePickUp main = GetComponentInParent<BasePickUp>();
        harm = main.Score;
    }

    public override void Move()
    {
        if (currentTime >= timeBeetweenAttacks)
        {
            currentTime = 0f;
            animator.SetTrigger("Attack");
            player.TotalScore = harm;
        }
        currentTime += Time.deltaTime;
    }

}
