using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MovementBase
{
    [SerializeField] private MovingSystem movingSystem = null;
    [SerializeField] private TypeMove typeMove;
    private Transform targetPoint = null;

   // private Transform enemyTransform = null;

    //private NavMeshAgent navMeshAgent;

    protected override void Init()
    {
        //GameObject main = GetComponentInParent<MovingAgent>().gameObject;
        //enemyTransform = main.transform;
        targetPoint = movingSystem.GetStartPoint();
        //navMeshAgent = main.GetComponent<NavMeshAgent>();
    }

    public override void Move()
    { 
        if (parentTransform.position == targetPoint.position)
        {
            targetPoint = movingSystem.GetNextPoint(typeMove);
        }
        MoveToTheNextPoint();
    }

    private void MoveToTheNextPoint()
    {
        parentTransform.LookAt(targetPoint);
        parentTransform.position = Vector3.MoveTowards(parentTransform.position, targetPoint.position, speed * Time.fixedDeltaTime);
        //navMeshAgent.SetDestination(targetPoint.position);
    }

    protected override void StuffToExecuteWhenTerminate()
    {
        //navMeshAgent.isStopped = true;
    }
}
