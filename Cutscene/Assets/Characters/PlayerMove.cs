﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    private Animator animator;
    private int animTurn;
    private int animSpeed;

    private Rigidbody rigidbody;
    private Transform camera;
    
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
        float axis = Input.GetAxis("Horizontal");
        animator.SetFloat(animTurn, axis);
        transform.Rotate(Vector3.up * axis * rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float axis = Input.GetAxis("Vertical");
        float translation = axis * speed * Time.deltaTime;
        if (axis != 0)
            transform.rotation = new Quaternion(transform.rotation.x, camera.rotation.y, transform.rotation.z, transform.rotation.w);
        transform.Translate(Vector3.forward * translation);
        animator.SetFloat(animSpeed, axis);
    }

    private void OnTriggerEnter(Collider other)
    {
        rigidbody.isKinematic = true;
    }

}
