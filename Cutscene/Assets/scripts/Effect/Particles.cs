using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem[] particles;

    private void Start()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayParticles()
    {
        foreach (ParticleSystem p in particles)
        {
            p.Play();
        }
    }

    public void StopParticles()
    {
        foreach (ParticleSystem p in particles)
        {
            p.Stop();
        }
    }

}
