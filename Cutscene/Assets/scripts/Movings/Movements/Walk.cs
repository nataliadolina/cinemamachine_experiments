using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MovementBase
{
    [SerializeField] private MovingSystem movingSystem = null;
    [SerializeField] private TypeMove typeMove;
    private Transform targetPoint = null;

    protected override void Init()
    {
        movingSystem.CreateWay();
        targetPoint = movingSystem.GetStartPoint();
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
    }
}
