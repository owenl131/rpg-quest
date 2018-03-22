using UnityEngine;

public class Quest9Character : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collided");
            GameObject.Find("Quest9Textbox").GetComponent<TextboxQuest9>().showBox();
        }
    }
}