using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly float speed = 2f;
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            movement.y = 0;
        else
            movement.x = 0;
        if (movement != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("inputX", movement.x);
            anim.SetFloat("inputY", movement.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        rb.MovePosition(rb.position + movement*Time.deltaTime*speed);
    }
}