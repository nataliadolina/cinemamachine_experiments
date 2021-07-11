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
    private Rigidbody[] rigidbodies;

    private MovingAgent movingAgent;


    private void OnEnable()
    {
        aura = GetComponentInChildren<Particles>();
        movesPatterns = GetComponentsInChildren<MovementBase>();
        movingAgent = GetComponent<MovingAgent>();

        colliders = GetComponentsInChildren<Collider>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();

        Init();

    }

    protected virtual void Init()
    {

    }

    public virtual void WakeUp()
    {
        transform.parent = null;
        aura.PlayParticles();
    }

    public virtual void Sleep()
    {
        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
        }

        foreach (Rigidbody rb in rigidbodies)
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

        foreach (Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}
