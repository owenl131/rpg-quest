using UnityEngine;

public class TownToHouse : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Home");
        }
    }
}