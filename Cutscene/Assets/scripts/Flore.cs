using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flore : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float startPosY;
    private Animator animator;

    void Start()
    {
        rigidbody = GetComponentInParent<Rigidbody>();
        startPosY = transform.position.y;
        SetRigidBodyKinematic(true);
    }

    public void AddForce(float force)
    {
        rigidbody.AddForce(Vector3.up * force * 0.02f, ForceMode.Impulse);
    }

    public void SetRigidBodyKinematic(bool isKinematic)
    {
        rigidbody.isKinematic = isKinematic;
    }

    public void ToStartHeight()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x, startPosY, pos.z);
    }
}
