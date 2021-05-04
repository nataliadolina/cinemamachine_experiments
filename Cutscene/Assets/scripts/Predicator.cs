using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ObjectToCollide
{
    Player,
    Camera
}

public abstract class Predicator : MonoBehaviour
{
    [SerializeField] private ObjectToCollide objectToCollide;
    protected Predicate<Collider> isTargetObject;

    protected void Init()
    {
        isTargetObject = IsTargetObject();
    }

    protected Predicate<Collider> IsTargetObject()
    {
        switch (objectToCollide)
        {
            case ObjectToCollide.Player: return (Collider coll) => coll.GetComponent<PlayerMove>();
            case ObjectToCollide.Camera: return (Collider coll) => coll.GetComponent<Camera>();
            default: throw new ArgumentException("Недопустимый ключ");
        }
    }
}
