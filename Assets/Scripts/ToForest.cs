using UnityEngine;

public class ToForest : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (QuestStatus.questLoc != 1)
            {
                GameObject.Find("Textbox_Forest").GetComponent<Textbox>().showBox();
            }
            else
            {
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Forest3D");
            }
        }
    }
}