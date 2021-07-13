using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MovementBase
{
    [SerializeField] float timeBeetweenAttacks;
    private int harm;

    private float currentTime = 0f;
    private Player player;

    private Particles[] collisionParticles;

    private System.Random random;

    protected override void Init()
    {
        collisionParticles = GetComponentsInChildren<Particles>();

        player = FindObjectOfType<Player>();
        BasePickUp main = GetComponentInParent<BasePickUp>();
        harm = main.Score;

        random = new System.Random();
    }

    public override void Move()
    {
        if (currentTime >= timeBeetweenAttacks)
        {
            currentTime = 0f;
            animator.SetTrigger("Attack");
            CallParticles();
            player.TotalScore = harm;
        }
        currentTime += Time.deltaTime;
    }

    private void CallParticles()
    {
        int index = random.Next(0, collisionParticles.Length);
        collisionParticles[index].PlayParticles();
    }

}
