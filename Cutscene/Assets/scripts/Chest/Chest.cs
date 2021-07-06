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

    private void Awake()
    {
        animator = GetComponent<Animator>();
        open = FindObjectOfType<Player>().OpenChest;
        button.enabled = false;
        player = FindObjectOfType<Player>();

        pickUp = GetComponentInChildren<BasePickUp>();
        pickUp.gameObject.SetActive(false);
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
