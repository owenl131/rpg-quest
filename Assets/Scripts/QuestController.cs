using UnityEngine;

public class QuestController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        var curr = QuestStatus.questIndex;
        for (var i = 0; i < 15; i++)
        {
            var g = GameObject.Find("Quest" + i);
            if (g != null)
                g.SetActive(curr == i);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        var curr = QuestStatus.questIndex;
        if (curr == 1)
        {
        }
        if (curr == 2)
        {
        }
    }
}