using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Chest : MonoBehaviour
{
    [SerializeField] private Button button = null;
    [SerializeField] private float takeTime = 0f;

    private Animator animator;

    private Action open;
    private Player player;

    private BasePickUp pickUp;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        open = FindObjectOfType<Player>().OpenChest;
        button.enabled = false;
        player = FindObjectOfType<Player>();

        pickUp = GetComponentInChildren<BasePickUp>();
    }

    protected virtual void Open()
    {
        animator.SetTrigger("open");
        player.Take(pickUp, takeTime);
        if (pickUp != null)
        {
            pickUp.WakeUp();
        }  
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            button.enabled = true;
            button.interactable = true;
            FindObjectOfType<Player>().OpenChest += Open;
            Debug.Log(FindObjectOfType<Player>().OpenChest);
        }
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMove>())
        {
            button.enabled = false;
            button.interactable = false;
            FindObjectOfType<Player>().OpenChest -= Open;
        }
    }

}
