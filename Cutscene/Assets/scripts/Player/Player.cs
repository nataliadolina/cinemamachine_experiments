using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Transform> flowerPositions;
    [SerializeField] private Transform hand;
    public Transform Hand { get { return hand; } }

    private float totalScore;
    public float TotalScore
    {
        get
            { return totalScore; }
        set
            {
                totalScore += value;
                totalScore = Mathf.Clamp(totalScore, 0, 1000f);
                ChangeScore(value);
            }
    }

    private List<BasePickUp> takenFlowers = null;

    private FlowersContainer flowersContainer = null;

    void Start()
    {
        takenFlowers = new List<BasePickUp>();
        flowersContainer = FindObjectOfType<FlowersContainer>();
    }

    private void ChangeScore(float value)
    {
        while (value < 0)
        {
            var closestFlower = GetClosestFlower(value);

            if (closestFlower == null)
            {
                Debug.Log("No flowers to harm");
                return;
            }

            float prevScore = closestFlower.Score;
            closestFlower.GetHarm(Mathf.Clamp(Mathf.Abs(value), 0f, closestFlower.Score));
            value += prevScore;
            
            if (value <= 0)
            {
                Debug.Log("Removed flower");
                takenFlowers.Remove(closestFlower);
            }
        }
        
    }

    #region closest flower logic
    private BasePickUp GetClosestFlower(float value) // возвращает цветок с наиболее близким значением к урону. Предпочтение отдаётся цветкам с весом меньшим или равным урону.
    {
        BasePickUp res = null;

        float negDelta = 1f;
        BasePickUp negPickUp = null;


        float posDelta = -1f;
        BasePickUp posPickUp = null;

        foreach (var p in takenFlowers)
        {
            var delta = value + p.Score;

            if (delta <= 0)
            {
                if (negDelta == 1 | Mathf.Abs(delta) < Mathf.Abs(negDelta))
                {
                    negDelta = delta;
                    negPickUp = p;
                }
            }

            else if (delta > 0)
            {
                if (posDelta == -1 | delta < posDelta)
                {
                    posDelta = delta;
                    posPickUp = p;
                }
            }

        }

        if (negPickUp)
        {
            return negPickUp;
        }
        return posPickUp;
    }
    #endregion

    public void Take(BasePickUp pickUp)
    {
        pickUp.transform.position = hand.position;
        pickUp.transform.SetParent(hand);
        pickUp.Sleep();
        pickUp.DisableAnimator();
        pickUp.transform.localScale = pickUp.transform.localScale * 0.5f;
        flowersContainer.SetFlowerRotation(pickUp.gameObject);
        TotalScore = pickUp.Score;
        takenFlowers.Add(pickUp);
    }
}
