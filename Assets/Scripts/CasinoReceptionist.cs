using UnityEngine;

public class CasinoReceptionist : MonoBehaviour
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
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            textbox.GetComponent<TextboxCasino>().showBox();
        }
    }
}