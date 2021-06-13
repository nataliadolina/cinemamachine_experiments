using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacura : MonoBehaviour
{
    [SerializeField] private GameObject leaves;
    [SerializeField] private GameObject smell;

    private ParticleSystem[] leavesParticles;
    private ParticleSystem[] smellParticles;

    void Start()
    {
        leavesParticles = GetComponentsInChildren<ParticleSystem>();
        smellParticles = GetComponentsInChildren<ParticleSystem>();
    }

    private void PlayParticles(ParticleSystem[] particles)
    {
        foreach (ParticleSystem p in particles)
        {
            p.Play();
        }
    }

    private void StopParticles(ParticleSystem[] particles)
    {
        foreach (ParticleSystem p in particles)
        {
            p.Stop();
        }
    }

    public void PlayLeaves()
    {
        PlayParticles(leavesParticles);
    }

    public void StopLeaves()
    {
        StopParticles(leavesParticles);
    }
}
