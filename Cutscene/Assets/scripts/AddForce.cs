using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float timeBetween;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        rb.AddForce(Vector3.up * force * 0.02f, ForceMode.Impulse);
        yield return new WaitForSeconds(timeBetween);
        yield return StartCoroutine(Go());
    }
}
