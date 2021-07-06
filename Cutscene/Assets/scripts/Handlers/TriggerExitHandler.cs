using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitHandler : HandlerBase
{
    [SerializeField] private MovementBase toState;

    private void OnTriggerExit(Collider other)
    {
        if (check(other.transform))
        {
            movingAgent.ChangeCurrentState(toState);
            stuffToExecute.Invoke();
        }
            
    }
}
