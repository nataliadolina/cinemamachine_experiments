using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MovementBase
{
    [SerializeField] float timeBeetweenAttacks = 1f;
    [SerializeField] float attackDist = 2f;
    private float harm;

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

            var heading = transform.position - player.transform.position;
            var distToPlayer = heading.magnitude;

            if (distToPlayer <= attackDist)
            {
                player.TotalScore = harm;
                CallParticles();
            }

        }
        currentTime += Time.deltaTime;
    }

    private void CallParticles()
    {
        int index = random.Next(0, collisionParticles.Length);
        collisionParticles[index].PlayParticles();
    }

}
