using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walk : MovementBase
{
    [SerializeField] private TypeMove typeMove;
    private Transform targetPoint = null;

    private MovingSystem movingSystem = null;

    protected override void Init()
    {
        var main = parentTransform.parent;
        movingSystem = main.GetComponentInChildren<MovingSystem>();
        movingSystem.CreateWay();
        targetPoint = movingSystem.GetStartPoint();
        Debug.Log(movingSystem);
    }

    public override void Move()
    {
        Debug.Log("--moving---");
        if (parentTransform.position == targetPoint.position)
        {
            targetPoint = movingSystem.GetNextPoint(typeMove);
            Debug.Log("--wentToTheNextPoint--");
        }
        MoveToTheNextPoint();
    }

    private void MoveToTheNextPoint()
    {
        parentTransform.LookAt(targetPoint);
        parentTransform.position = Vector3.MoveTowards(parentTransform.position, targetPoint.position, speed * Time.fixedDeltaTime);
    }
}
