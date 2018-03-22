using UnityEngine;

public class ToDungeon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (QuestStatus.questLoc != 2)
            {
                Debug.Log("No Entry to Dungeon");
                GameObject.Find("Textbox_Dungeon").GetComponent<Textbox>().showBox();
            }
            else
            {
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Dungeon");
            }
        }
    }
}