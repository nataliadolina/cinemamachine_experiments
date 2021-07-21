using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacura : MonoBehaviour
{
    [SerializeField] private Particles leavesParticles = null;
    [SerializeField] private Particles smellParticles = null;

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

    public void ChangeLook(GameObject toLook)
    {
        Instantiate(toLook, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
