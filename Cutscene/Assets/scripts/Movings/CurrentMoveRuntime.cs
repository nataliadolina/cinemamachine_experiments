﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentMoveRuntime : RuntimeBase
{
    private MovingAgent movingAgent;

    private void OnEnable()
    {
        movingAgent = GetComponentInParent<MovingAgent>();
    }

    public override void Run()
    {
        Debug.Log("---CurrentMoveRuntime---");
        Debug.Log("---CurrentMoveRuntime---", movingAgent.CurrentMove);
        movingAgent.CurrentMove.Move();
    }
}