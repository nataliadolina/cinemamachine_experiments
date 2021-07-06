using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    [SerializeField] float speed = 0.0f;
    [SerializeField] float rotationSpeed = 0.0f;
    [SerializeField] bool lookCameraRotation = false;

    private Animator animator = null;
    private int animTurn = 0;
    private int animSpeed = 0;

    private Rigidbody rigidbody = null;
    private Transform camera = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        animTurn = Animator.StringToHash("turn");
        animSpeed = Animator.StringToHash("speed");
        camera = Camera.main.transform;

        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    { 
        Move();
        Rotate();
    }

    private void Rotate()
    {
        float axisRot = Input.GetAxis("Horizontal");
        animator.SetFloat(animTurn, axisRot);
        transform.Rotate(Vector3.up * axisRot * rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float axisMove = Input.GetAxis("Vertical");
        float translation = axisMove * speed * Time.deltaTime;
        animator.SetFloat(animSpeed, axisMove);
        if (translation != 0f)
        {
            transform.Translate(Vector3.forward * translation);
        }

    }
}
