using UnityEngine;

public class ShowComputer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKeyUp(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Computer");
        }
    }
}