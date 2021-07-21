using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flower : BasePickUp
{
    private float maxScore = 10;
    private List<float> scoresNeeded;

    private Player player = null;

    private float initialScore = 0f;

    private GameObject currentMesh = null;

    private FlowersContainer flowersContainer = null;
    private Rigidbody flowerRigidbody = null;

    

    protected override void Init()
    {
        player = FindObjectOfType<Player>();
        initialScore = score;

        flowersContainer = FindObjectOfType<FlowersContainer>();

        flowerRigidbody = GetComponent<Rigidbody>();
        flowerRigidbody.isKinematic = true; 
    }

    private void SetMesh(bool rotate=false)
    {
        Debug.Log("---set mesh---");

        if (currentMesh != null)
        {
            Destroy(currentMesh);
        }

        GameObject mesh = flowersContainer.GetMesh(Score);
        currentMesh = Instantiate(mesh, transform.position, Quaternion.identity, transform);

        if (rotate)
        {
            flowersContainer.SetFlowerRotation(currentMesh);
        }
    }

    public override void WakeUp()
    {
        SetMesh();
        transform.parent = null;
        aura.PlayParticles();
    }

    public void GiveToPlayer()
    {
        player.Take(this);
    }

    public override void GetHarm(float value)
    {
        if (score - value <= 0f)
        {
            score = 0f;
            flowerRigidbody.isKinematic = false;
            transform.parent = null;
        }

        else
        {
            score -= value;
        }

        SetMesh(true);
    }
}
