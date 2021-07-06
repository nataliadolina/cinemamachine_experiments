using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;


public class NavMeshMove : MonoBehaviour
{
    private Transform currentDist;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent; } }

    private MovingSystem movingSystem;
    public void Init(MovingSystem _movingSystem = null)
    {
        agent = GetComponentInParent<NavMeshAgent>();
        if (_movingSystem != null)
        {
            movingSystem = _movingSystem;
            agent.destination = FindPoint().position;
        }
        else
            agent.destination = FindPlayer().position;
    }

    private Transform FindPlayer()
    {
        return FindObjectOfType<Player>().transform;
    }

    private Transform FindPoint()
    {
        return movingSystem.GetStartPoint();
    }

}
