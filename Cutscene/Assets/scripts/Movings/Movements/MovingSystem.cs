using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeMove
{
    reverse,
    circle
}

public class MovingSystem : MonoBehaviour
{

    private Transform[] points = null;
    private int pointsLimit = 0;
    private int currentPoint = 0;
    private int delta = 1;
    private Dictionary<TypeMove, Action> typesMovement = null;

    public Transform GetNextPoint(TypeMove typeMove)
    {
        currentPoint += delta;

        if (currentPoint >= pointsLimit || currentPoint < 0)
            typesMovement[typeMove]();

        return points[currentPoint];
    }

    public Transform GetStartPoint()
    {
        return points[0];
    }

    private void Awake()
    {
        typesMovement = new Dictionary<TypeMove, Action>()
        {
            { TypeMove.reverse, this.ReverseChangeCurrentPoint},
            { TypeMove.circle, this.CircleChangeCurrentPoint}
        };

        var i = 0;
        points = new Transform[transform.childCount];

        if (points.Length != 0)
        {
            foreach (Transform child in transform)
            {
                points[i] = child.transform;
                i += 1;
            }
            pointsLimit = points.Length;
        }
    }

    private void CircleChangeCurrentPoint()
    {
        currentPoint = 0;
    }

    private void ReverseChangeCurrentPoint()
    {
        delta *= -1;
        currentPoint += delta;
    }
}
