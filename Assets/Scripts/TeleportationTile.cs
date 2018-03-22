using UnityEngine;

public class TeleportationTile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
                GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Home");
        }
    }
}