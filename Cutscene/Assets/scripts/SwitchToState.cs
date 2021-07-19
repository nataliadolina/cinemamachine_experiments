using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToState : EventBase
{
    [SerializeField] private MovementBase toState;
    private MovingAgent agent = null;

    private void OnEnable()
    {
        agent = GetComponentInParent<MovingAgent>();
    }

    public override void Execute()
    {
        
    }
}
