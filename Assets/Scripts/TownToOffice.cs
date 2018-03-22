using UnityEngine;

public class TownToOffice : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Office");
    }
}