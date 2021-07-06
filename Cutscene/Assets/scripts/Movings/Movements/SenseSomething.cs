using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseSomething : MovementBase
{
    [SerializeField] float rotationSpeed;
    private Transform player = null;
    private Transform meshTransform = null;
    private int dir = 1;

    protected override void Init()
    {
        player = FindObjectOfType<Player>().transform;
        Animator anim = GetComponentInParent<BasePickUp>().GetComponentInChildren<Animator>();
        meshTransform = anim.transform;
    }

    public override void Move()
    {
        Debug.Log("Spinning");
        //Spin();
    }

    private void Spin()
    {
        meshTransform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * dir, Space.World);
    }

}
