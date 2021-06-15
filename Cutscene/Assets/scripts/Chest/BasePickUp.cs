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

    private Animator animator;

    private void Start()
    {
        aura = GetComponentInChildren<Particles>();
        movesPatterns = GetComponentsInChildren<MovementBase>();

        animator.GetComponent<Animator>();
    }

    public void WakeUp()
    {
        aura.PlayParticles();
        animator.SetTrigger("float");
    }
}
