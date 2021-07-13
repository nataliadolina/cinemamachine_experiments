using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightInParticles : MonoBehaviour
{
    private Light light;

    void OnEnable()
    {
        light = GetComponent<Light>();
        light.enabled = false;
    }

    public void SetEnbaled(bool value)
    {
        light.enabled = value;
    }

}
