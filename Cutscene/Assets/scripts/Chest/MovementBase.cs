using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] protected float speed;
    public abstract void Move();

    public virtual void SetAim()
    {

    }
}
