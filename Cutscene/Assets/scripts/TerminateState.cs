using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminateState : EventBase
{
    private MovingAgent movingAgent;

    void OnEnable()
    {
        movingAgent = GetComponentInParent<MovingAgent>();
    }

    public override void Execute()
    {
        movingAgent.CurrentMove.Terminate();
    }
}
