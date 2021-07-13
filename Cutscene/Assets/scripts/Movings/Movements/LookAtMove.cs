using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OnTerminate
{
    DoNothing,
    BeTaken,
}

public class LookAtMove : MovementBase
{
    [SerializeField] private OnTerminate onTerminate;
    private Transform aim;

    private BasePickUp pickUp;
    private Player player;

    protected override void Init()
    {
        player = FindObjectOfType<Player>();
        aim = player.transform;

        pickUp = GetComponentInParent<BasePickUp>();
        parentTransform = pickUp.transform;
    }

    public override void Move()
    {
        parentTransform.LookAt(aim.position + new Vector3(0, aim.localScale.y / 2, 0));
        parentTransform.position += transform.forward * speed * Time.deltaTime;
    }

    protected override void StuffToExecuteWhenTerminate()
    {
        if (onTerminate == OnTerminate.BeTaken)
            player.Take(pickUp);
    }
}
