using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExitHandler : HandlerBase
{
    private void OnTriggerExit(Collider other)
    {
        if (check(other.transform))
        {
            stuffToExecute.Invoke();
        }
            
    }
}
