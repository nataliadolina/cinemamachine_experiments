using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public abstract class MovementBase : MonoBehaviour
{
    [SerializeField] private MovementBase nextState;
    private MovementBase previousState;
    [SerializeField] protected float speed;

    protected Transform parentTransform;

    protected MovingAgent movingAgent;
    public UnityEvent setAnim;

    protected Animator animator;

    void Awake()
    {
        if (setAnim == null)
            setAnim = new UnityEvent();
    }

    private void OnEnable()
    {
        movingAgent = GetComponentInParent<MovingAgent>();
        parentTransform = GetComponentInParent<BasePickUp>().transform;
        animator = parentTransform.GetComponentInChildren<Animator>();
        Init();
    }


    protected virtual void Init()
    {

    }

    public abstract void Move();

    public void SwitchToPreviousState()
    {
        movingAgent.CurrentMove = previousState;
    }

    public void Terminate()
    {
        previousState = movingAgent.CurrentMove;
        movingAgent.ChangeCurrentState(nextState);
        nextState.StuffToExecuteWhenStart();
        StuffToExecuteWhenTerminate();
    }

    protected virtual void StuffToExecuteWhenTerminate()
    {

    }

    protected virtual void StuffToExecuteWhenStart()
    {

    }

    public virtual void SetAnim()
    {
        setAnim.Invoke();
    }
}
