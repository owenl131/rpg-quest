using UnityEngine;

public class Quest2Character : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("TextboxQuest2").GetComponent<TextboxQuest2>().showBox();
        }
    }
}