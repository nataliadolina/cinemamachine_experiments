using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Chest : MonoBehaviour
{
    [SerializeField] private Button button = null;
    private Animator animator;

    private Action open;
    private Player player;

    private BasePickUp pickUp;
    private bool enabled = false;

    private void OnEnable()
    {
        if (!enabled)
        {
            Transform main = transform.parent;
            animator = GetComponent<Animator>();
            open = FindObjectOfType<Player>().OpenChest;
            button.enabled = false;
            player = FindObjectOfType<Player>();

            pickUp = main.GetComponentInChildren<BasePickUp>();
            pickUp.gameObject.SetActive(false);
            enabled = true;
        }
        
    }

    protected virtual void Open()
    {
        animator.SetTrigger("open");
        if (pickUp != null)
        {
            pickUp.gameObject.SetActive(true);
            pickUp.WakeUp();
        }  
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            button.enabled = true;
            button.interactable = true;
            var player = FindObjectOfType<Player>();
            player.OpenChest += Open;
            Debug.Log(player.OpenChest);
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            button.enabled = false;
            button.interactable = false;
            FindObjectOfType<Player>().OpenChest -= Open;
        }
    }

}
