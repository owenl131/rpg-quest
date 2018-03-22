using UnityEngine;

public class BankMoney : MonoBehaviour
{
    private bool isTriggered;

    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //isTriggered = false;
                GameObject.Find("TextboxBank").GetComponent<TextBoxBank>().showBox();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isTriggered = false;
    }
}