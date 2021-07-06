using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public enum TypeAim
{
    Player,
    Hand
}

public class HandlerBase : MonoBehaviour
{
    [SerializeField] private TypeAim typeAim;
    protected Predicate<Transform> check;
    protected MovingAgent movingAgent;
    public UnityEvent stuffToExecute;

    private void Awake()
    {
        if (stuffToExecute == null)
            stuffToExecute = new UnityEvent();

        check = SetTypeVerification();
    }

    private void Start()
    {
        movingAgent = GetComponentInParent<MovingAgent>();
    }

    private Predicate<Transform> SetTypeVerification()
    {
        switch (typeAim)
        {
            case TypeAim.Player: return (Transform t) => t.GetComponent<Player>();
            case TypeAim.Hand: return (Transform t) => t.CompareTag("Hand");
            default: throw new ArgumentException("Недопустимый ключ");
        }
    }
}
