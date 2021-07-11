using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAppear : MovementBase
{
    [SerializeField] private GameObject triggerHandler = null;
    [SerializeField] private RuntimeBase nextRuntime = null;
    private Rigidbody monsterRigidbody;
    private float prevY;

    private Transform monsterTransform;
    private BasePickUp pickUp;

    protected override void Init()
    {
        monsterRigidbody = GetComponentInParent<Rigidbody>();
        monsterTransform = GetComponentInParent<BasePickUp>().transform;
        pickUp = GetComponentInParent<BasePickUp>();

        triggerHandler.SetActive(false);
        AddForce();
    }

    public override void Move()
    {
        float curY = monsterTransform.position.y;
        if (curY < prevY)
        {
            Terminate();
        }

        else
        {
            prevY = curY;
        }
    }

    private void AddForce()
    {
        monsterRigidbody.isKinematic = false;
        monsterRigidbody.AddForce(Vector3.up * speed * 0.02f, ForceMode.Impulse);
    }

    protected override void StuffToExecuteWhenTerminate()
    {
        monsterRigidbody.isKinematic = true;
        movingAgent.ChangeCurrentRuntime(nextRuntime);
        triggerHandler.SetActive(true);
    }
}
