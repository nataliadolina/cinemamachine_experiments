using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUp : MovementBase
{
    [SerializeField] private GameObject triggerHandler = null;
    [SerializeField] private float height = 1f;

    private float startPoint;
    private BasePickUp pickUp;

    private GameObject chest;

    protected override void Init()
    {
        pickUp = GetComponentInParent<BasePickUp>();
        startPoint = parentTransform.position.y;

        triggerHandler.SetActive(false);

        var mainTransform = pickUp.transform;
        chest = mainTransform.parent.GetComponentInChildren<Chest>().gameObject;
    }

    public override void Move()
    {
        float delta = parentTransform.position.y - startPoint;
        if (delta < height)
        {
            float translateSpeed = speed;
            if (delta > 0.5f * height)
                translateSpeed = 2 * speed;
            parentTransform.Translate(Vector3.up * translateSpeed * Time.deltaTime);
        }
        else
        {
            Terminate();
        } 
    }

    protected override void StuffToExecuteWhenTerminate()
    {
        triggerHandler.SetActive(true);
        Destroy(chest);
    }
}
