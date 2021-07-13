using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Particles : MonoBehaviour
{
    public UnityEvent onPlayParticles;
    private ParticleSystem[] particles;

    private void OnEnable()
    {
        if (onPlayParticles == null)
            onPlayParticles = new UnityEvent();

        particles = GetComponentsInChildren<ParticleSystem>();
    }

    public void PlayParticles()
    {
        if (particles != null)
        {
            foreach (ParticleSystem p in particles)
            {
                p.Play();
            }
        }
        
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

    public void StopParticles()
    {
        foreach (ParticleSystem p in particles)
        {
            p.Stop();
        }
    }

}
