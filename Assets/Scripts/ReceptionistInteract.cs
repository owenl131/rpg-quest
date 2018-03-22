using UnityEngine;

public class ReceptionistInteract : MonoBehaviour
{
    public GameObject textbox;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.anyKeyDown)
        {
            textbox.transform.position = new Vector3(textbox.transform.position.x, textbox.transform.position.y, -20);
        }
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("text");
            textbox.transform.position = new Vector3(textbox.transform.position.x, textbox.transform.position.y, 0);
        }
    }
}