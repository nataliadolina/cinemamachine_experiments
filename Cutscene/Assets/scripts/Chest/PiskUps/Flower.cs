using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : BasePickUp
{
    private Player player = null;

    protected override void Init()
    {
        player = FindObjectOfType<Player>();   
    }

    public void GiveToPlayer()
    {
        player.Take(this);
    }
}
