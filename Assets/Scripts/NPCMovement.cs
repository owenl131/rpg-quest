using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private readonly float speed = 1.2f;
    private Animator anim;
    public GUIText gt;
    private bool isColliding;
    private bool isTalking;
    private Vector2 movement;
    private Rigidbody2D rb;
    public Transform textbox;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isColliding = false;
        isTalking = false;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
            GameObject.FindWithTag("Player").GetComponent<Collider2D>());
        InvokeRepeating("Wander", 0.2f, 1);
    }

    private void Wander()
    {
        Debug.Log("Wandering");
        var toMove = Random.Range(0, 2);
        if (toMove == 1)
        {
            movement = Vector2.zero;
            return;
        }
        var direction = Random.Range(0, 2); //if 0, x axis. if 1, y axis
        var directionX = Random.Range(0, 2); //if 0, go left or up. if 1, go right or down
        movement = randomDirection(direction, directionX);
    }

    private void Update()
    {
        if (isColliding)
        {
            if (!isTalking && Input.GetKeyDown(KeyCode.Space))
            {
                isTalking = true;
                movement = Vector2.zero;
                anim.SetBool("isWalking", false);
                turn();
                Time.timeScale = 0;
                gt.text = "Did you know a new counselling centre opened up at the \nsecond floor of the office?";
                textbox.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                    0);
            }
            else if (isTalking && Input.anyKeyDown)
            {
                gt.text = "";
                textbox.position = new Vector3(textbox.position.x, textbox.position.y, -20);
                isTalking = false;
                Time.timeScale = 1;
            }
            if (isTalking)
                return;
        }
        if (transform.position.y > 2.5 && Mathf.Abs(movement.y - 1.0f) < 0.0001f)
            movement.y = Random.Range(0, 2) - 1;
        if (transform.position.y < -2.5 && Mathf.Abs(movement.y + 1.0f) < 0.0001f)
            movement.y = Random.Range(0, 2);

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
        rb.MovePosition(rb.position + movement*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isColliding = false;
        }
    }

    private void turn()
    {
        var player = GameObject.FindWithTag("Player").transform;
        var turnHorizontally = false;
        var Xdiff = transform.position.x - player.position.x;
        var Ydiff = transform.position.y - player.position.y;

        if (Mathf.Abs(Xdiff) > Mathf.Abs(Ydiff))
            turnHorizontally = true;
        if (turnHorizontally)
        {
            anim.SetFloat("inputY", 0);
            if (Xdiff > 0)
                anim.SetFloat("inputX", -1);
            else
                anim.SetFloat("inputX", 1);
        }
        else
        {
            anim.SetFloat("inputX", 0);
            if (Ydiff > 0)
                anim.SetFloat("inputY", -1);
            else
                anim.SetFloat("inputY", 1);
        }
    }

    private Vector2 randomDirection(int direction, int directionOnAxis)
    {
        //if 0, x axis. if 1, y axis
        if (direction == 0)
        {
            if (directionOnAxis == 0)
                return new Vector2(-1, 0);
            return new Vector2(1, 0);
        }
        if (directionOnAxis == 0)
            return new Vector2(0, 1);
        return new Vector2(0, -1);
    }
}