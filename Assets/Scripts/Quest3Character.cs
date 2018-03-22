using UnityEngine;

public class Quest3Character : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Quest3Textbox").GetComponent<TextboxQuest3>().showBox();
        }
    }
}