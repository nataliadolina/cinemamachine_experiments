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
    //public delegate void Take(BasePickUp pickUp);
    //public event Take take;

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

    private IEnumerator WaitBeforeTake(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    public void Take(BasePickUp pickUp, float waitTime)
    {
        StartCoroutine(WaitBeforeTake(waitTime));
        pickUp.transform.position = hand.position;
        pickUp.transform.SetParent(hand);
        totalScore = pickUp.Score;
    }
}
