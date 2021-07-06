using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : HandlerBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (check(other.transform))
        {
            movingAgent.CurrentMove.Terminate();
            stuffToExecute.Invoke();
        }
    }
}
