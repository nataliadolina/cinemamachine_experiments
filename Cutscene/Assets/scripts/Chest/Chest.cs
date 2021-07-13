using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Chest : MonoBehaviour
{
    [SerializeField] private Particles appearParticles;
    [SerializeField] private Particles destroyParticles;

    private Animator animator;

    private Action open;
    private Player player;

    private BasePickUp pickUp;

    private void OnEnable()
    {
        appearParticles.PlayParticles();

        Transform main = transform.parent;
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

        pickUp = main.GetComponentInChildren<BasePickUp>();
        pickUp.gameObject.SetActive(false);
        
    }

    public virtual void Open()
    {
        animator.SetTrigger("open");
        if (pickUp != null)
        {
            pickUp.gameObject.SetActive(true);
            pickUp.WakeUp();
        }  
    }

    private void OnDestroy()
    {
        destroyParticles.transform.parent = null;
        destroyParticles.PlayParticles();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            OpenButton.chestToOpen = this;
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            OpenButton.chestToOpen = null;
        }
    }

}
