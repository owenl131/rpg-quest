using UnityEngine;

public class TownToCasino : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Casino");
    }
}