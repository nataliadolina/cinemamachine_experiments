using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlower : MonoBehaviour
{
    [SerializeField] private MovementBase initialMove;
    [SerializeField] private MovementBase floatingToPlayerHand;

    private MovementBase currentMove;

    void Start()
    {
        currentMove = initialMove;
    }

    void Update()
    {
        currentMove.Move();
    }

    public void SwitchToApproachingPlayer()
    {
        currentMove = floatingToPlayerHand;
    }
}
