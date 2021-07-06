using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacura : MonoBehaviour
{
    [SerializeField] private Particles leavesParticles;
    [SerializeField] private Particles smellParticles;

    void Start()
    {
        leavesParticles = GetComponentInChildren<Particles>();
        smellParticles = GetComponentInChildren<Particles>();
    }

    public void PlayLeaves()
    {
        leavesParticles.PlayParticles();
    }

    public void StopLeaves()
    {
        leavesParticles.StopParticles();
    }
}
