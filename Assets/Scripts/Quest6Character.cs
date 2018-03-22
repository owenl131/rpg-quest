using UnityEngine;

public class Quest6Character : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (!LevelTrack.indexToString(LevelTrack.prevLevel).Equals("Phone"))
            transform.position = new Vector3(-30, 0, -1.6f);
    }

    private void Update()
    {
        if (transform.position.x < -13)
        {
            rb.MovePosition(transform.position + new Vector3(0.005f, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Quest6Textbox").GetComponent<TextboxQuest6>().showBox();
        }
    }
}