using UnityEngine;

public class Quest5Character : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.tag == "Player")
        {
            GameObject.Find("Quest5Textbox").GetComponent<TextboxQuest5>().showBox();
            Debug.Log("Player Collided Quest5");
        }
    }
}