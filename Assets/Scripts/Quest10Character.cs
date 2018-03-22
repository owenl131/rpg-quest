using UnityEngine;

public class Quest10Character : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collided");
            GameObject.Find("Quest10Textbox").GetComponent<TextboxQuest10>().showBox();
        }
    }
}