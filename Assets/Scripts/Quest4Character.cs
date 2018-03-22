using UnityEngine;

public class Quest4Character : MonoBehaviour
{
    public int counter;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        counter = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Quest4Textbox").GetComponent<TextboxQuest4>().showBox();
            Debug.Log("Player Collided Quest4");
        }
    }

    private void Update()
    {
        counter++;
        if (transform.position.z > -6)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6);
        }
        if (transform.position.z < -11.8)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -11.8f);
        }
        if (counter <= 50)
        {
            rb.MovePosition(transform.position + new Vector3(0, 0, 2)*Time.deltaTime*(Random.Range(-1, 1)));
        }
        else if (counter > 100)
        {
            counter = 0;
        }
    }
}