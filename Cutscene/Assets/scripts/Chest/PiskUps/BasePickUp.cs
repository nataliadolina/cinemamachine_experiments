using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickUp : MonoBehaviour
{
    [SerializeField] protected int score = 0;
    public int Score { get { return score; } set { score += value; } }

    protected Particles aura;
    private MovementBase initialMove;
    private MovementBase[] movesPatterns;

    private Collider[] colliders;
    private Rigidbody[] rigidBodies;

    private MovingAgent movingAgent;

    private void OnEnable()
    {
        Init();
        aura = GetComponentInChildren<Particles>();
        movesPatterns = GetComponentsInChildren<MovementBase>();
        movingAgent = GetComponent<MovingAgent>();

        colliders = GetComponentsInChildren<Collider>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        Sleep();

    }

    protected virtual void Init()
    {

    }

    public virtual void WakeUp()
    {
        transform.parent = null;
        aura.PlayParticles();
        movingAgent.CurrentMove.Terminate();
    }

    public virtual void Sleep()
    {
        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
        }

        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = true;
        }
    }

    public virtual void MakeCollidable()
    {
        foreach (Collider coll in colliders)
        {
            coll.enabled = true;
        }

        foreach (Rigidbody rb in rigidBodies)
        {
            rb.isKinematic = false;
        }
    }
}
