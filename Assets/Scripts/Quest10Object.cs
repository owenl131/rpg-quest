using UnityEngine;

public class Quest10Object : MonoBehaviour
{
    public Quest10Controller controller;

    private int dir;
    private readonly float speed = 2f;

    // Use this for initialization
    private void Start()
    {
        dir = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        if (dir == 1)
        {
            if (transform.position.y > 1)
                dir = -dir;
        }
        else
        {
            if (transform.position.y < -1.5)
                dir = -dir;
        }
        transform.position += new Vector3(0, dir*Time.deltaTime*speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var ps = GameObject.Find("Destroy");
        ps.transform.position = transform.position;
        ps.GetComponent<ParticleSystem>().Play();
        controller.success();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}