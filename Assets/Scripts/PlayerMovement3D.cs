using System;
using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    private readonly float speed = 2f;
    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (Math.Abs(movement.x) > Math.Abs(movement.z))
        {
            movement = new Vector3(movement.x, 0, 0);
        }
        else
        {
            movement = new Vector3(0, 0, movement.z);
        }
        if (anim && movement != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("inputX", movement.x);
            anim.SetFloat("inputY", movement.z);
        }
        else if (anim)
        {
            anim.SetBool("isWalking", false);
        }
        rb.MovePosition(rb.position + movement*Time.deltaTime*speed);
    }
}