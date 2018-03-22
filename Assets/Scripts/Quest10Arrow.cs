using UnityEngine;

public class Quest10Arrow : MonoBehaviour
{
    private bool active;
    private Quest10Controller controller;
    private int dir;
    private bool isMoving;
    private float rotation;
    private Rigidbody2D rb;
    private float speed;
    private float speed2;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        speed = 400;
        speed2 = 300;
        isMoving = false;
        active = false;
        dir = 1;
        rotation = 0;
        transform.position = new Vector3(-3f, -1.5f, 0);
        controller = GameObject.Find("Controller").GetComponent<Quest10Controller>();
    }

    public void activate()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }

    public void reset()
    {
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0, 0);
        isMoving = false;
        dir = 1;
        active = true;
        transform.position = new Vector3(-3f, -1.5f, 0);
        rotation = 0;
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }

    public void boost(int mag)
    {
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(1, 1).normalized*mag);
    }

    private void Update()
    {
        if (active)
        {
            if (!isMoving)
            {
                rotation += Time.deltaTime*dir*100f;
                transform.eulerAngles = new Vector3(0, 0, rotation);
                if (dir == 1 && rotation >= 89)
                {
                    dir = -1;
                }
                if (dir == -1 && rotation <= 1)
                {
                    dir = 1;
                }
            }
            else
            {
                var vel = rb.velocity;
                var angle = Mathf.Atan2(vel.y, vel.x)*Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angle);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    controller.boostClicked();
                }
            }
            if (!isMoving && Input.GetKeyDown(KeyCode.Space))
            {
                rb.gravityScale = 1f;
                var rad = Mathf.Deg2Rad*transform.eulerAngles.z;
                rb.AddForce(new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized*speed);
                isMoving = true;
            }
            if (transform.position.y < -10)
            {
                active = false;
                reset();
                controller.next(false);
            }
        }
    }
}