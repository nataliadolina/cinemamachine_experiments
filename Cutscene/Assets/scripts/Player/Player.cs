using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform hand;
    public Transform Hand { get { return hand; } }
    public Action OpenChest;

    private int totalScore;
    public int TotalScore { get { return totalScore; } set { totalScore += value; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OpenChests()
    {
        OpenChest();
    }

    public void Take(BasePickUp pickUp)
    {
        pickUp.transform.position = hand.position;
        pickUp.Sleep();
        pickUp.transform.localScale = new Vector3(pickUp.transform.localScale.x * 0.5f, pickUp.transform.localScale.y * 0.5f, pickUp.transform.localScale.z * 0.5f);
        pickUp.transform.Rotate(Vector3.forward * -45f);
        pickUp.transform.SetParent(hand);
        TotalScore = pickUp.Score;
    }
}
