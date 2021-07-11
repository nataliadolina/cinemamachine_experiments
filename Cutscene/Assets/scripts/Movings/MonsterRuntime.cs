using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRuntime : RuntimeBase 
{
    [SerializeField] private float pursueDist;

    [SerializeField] private MovementBase pursue;
    [SerializeField] private MovementBase walk;

    private Transform player;
    private MovingAgent movingAgent;

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        movingAgent = GetComponentInParent<MovingAgent>();
    }

    public override void Run()
    {
        var heading = transform.position - player.position;
        var distance = heading.magnitude;

        if (distance < pursueDist & movingAgent.CurrentMove)
        {
            movingAgent.CurrentMove = pursue;
        }

        else
        {
            movingAgent.CurrentMove = walk;
        }
        movingAgent.CurrentMove.Move();
    }
}
