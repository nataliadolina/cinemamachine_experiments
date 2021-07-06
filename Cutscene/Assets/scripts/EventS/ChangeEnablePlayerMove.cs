using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangeEnablePlayerMove : MonoBehaviour
{
    private PlayerMove playerMove = null;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    public void Execute()
    {
        playerMove.enabled = !playerMove.enabled;
    }
}
