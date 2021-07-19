using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Chest : MonoBehaviour
{
    [SerializeField] private Particles appearParticles;
    [SerializeField] private Particles destroyParticles;
    [SerializeField] private GameObject selectionAura;

    private Animator animator;

    private Action open;
    private Player player;

    private BasePickUp pickUp;

    private void Start()
    {
        Transform main = transform.parent;
        animator = GetComponent<Animator>();
        player = FindObjectOfType<Player>();

        selectionAura.SetActive(false);

        pickUp = main.GetComponentInChildren<BasePickUp>();
        pickUp.gameObject.SetActive(false);
        
    }

    public void playerAppearParticles()
    {
        appearParticles.PlayParticles();
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

    protected void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            ChestsController.chestToOpen = this;
            selectionAura.SetActive(true);
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            ChestsController.chestToOpen = this;
            selectionAura.SetActive(true);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            ChestsController.chestToOpen = null;
            selectionAura.SetActive(false);
        }
    }

}
