using System;
using UnityEngine;

public class BossAhLongMovement : MonoBehaviour
{
    private Animator anim;
    public Transform cube;
    private Rigidbody rb;
    public float speed = 1.5f;
    private Transform trans;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindWithTag("Player").GetComponent<Collider>());
    }

    // Update is called once per frame
    private void Update()
    {
        var pos = cube.position;
        var myPos = trans.position;
        var movement = pos - myPos;
        if (movement != Vector3.zero)
        {
            anim.SetBool("isWalking", true);
            var max = Math.Max(Math.Abs(movement.x), Math.Abs(movement.z));
            if (max != 0)
            {
                anim.SetFloat("inputX", movement.x/max);
                anim.SetFloat("inputY", movement.z/max);
            }
            else
            {
                anim.SetFloat("inputX", movement.x);
                anim.SetFloat("inputY", movement.z);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        rb.MovePosition(pos);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("attack");
        }
    }
}