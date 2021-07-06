using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMove : MovementBase
{
    private Transform aim;


    protected override void Init()
    {
        var player = FindObjectOfType<Player>();
        aim = player.transform;

        var pickUp = GetComponentInParent<BasePickUp>();
        parentTransform = pickUp.transform;
    }

    public override void Move()
    {
        parentTransform.LookAt(aim);
        parentTransform.position += transform.forward * speed * Time.deltaTime;
    }
}
