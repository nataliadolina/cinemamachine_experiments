using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 0.0f;

    private Animator animator = null;
    private int animSpeed = 0;

    private Transform camera = null;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        animSpeed = Animator.StringToHash("speed");
        camera = Camera.main.transform;
    }

    void Update()
    {
        float vertAxis = Input.GetAxis("Vertical");
        if (vertAxis != 0f)
        {
            Move(vertAxis);
        }
        Vector3 dir = camera.forward;
        dir.y = 0;
        Quaternion rotation = Quaternion.LookRotation(dir, transform.up);
        transform.rotation = rotation;
        
    }
    
    private void Move(float axis)
    {
        animator.SetFloat(animSpeed, axis);
        transform.Translate(camera.forward * axis * speed * Time.deltaTime, Space.World);
    }

}
