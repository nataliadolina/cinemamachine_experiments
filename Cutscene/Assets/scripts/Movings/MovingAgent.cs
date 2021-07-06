using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAgent : MonoBehaviour
{
    [SerializeField] private MovementBase currentMove;
    [SerializeField] private RuntimeBase currentRuntime;
    private StayStill still;

    public MovementBase CurrentMove { get { return currentMove; } set { currentMove = value; } }
    
    private void Start()
    {
        still = GetComponentInChildren<StayStill>();
    }

    private void Update()
    {
        currentRuntime.Run();
    }

    public void ChangeCurrentRuntime(RuntimeBase runtime)
    {
        currentRuntime = runtime;
    }

    public void ChangeCurrentState(MovementBase toState)
    {
        CurrentMove = toState;
        CurrentMove.SetAnim();
    }

    public void SetToStill()
    {
        CurrentMove = still;
    }
}
