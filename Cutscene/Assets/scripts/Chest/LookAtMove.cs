using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMove : MovementBase
{
    private Transform aim;

    public override void SetAim()
    {
        aim = FindObjectOfType<Player>().Hand;
    }

    public override void Move()
    {
        transform.LookAt(aim);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
