using UnityEngine;

public class ToSouthQuests : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (QuestStatus.questIndex == 7)
            {
                GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Quest7BossBattle");
            }
            else
            {
                GameObject.Find("Textbox_South").GetComponent<Textbox>().showBox();
            }
        }
    }
}