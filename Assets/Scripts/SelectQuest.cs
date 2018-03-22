using System;
using UnityEngine;

public class SelectQuest : MonoBehaviour
{
    private bool isOver;
    private Rect r;

    private void Start()
    {
        var size = GetComponent<Renderer>().bounds.size;
        var position = transform.position;
        r = new Rect(position.x - size.x/2, position.y - size.y/2, size.x, size.y);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                if (QuestStatus.questIndex == -1)
                {
                    QuestStatus.questLoc = GetComponent<SpriteRenderer>().sortingOrder;
                    QuestStatus.questIndex = Convert.ToInt32(gameObject.name[5] + "");
                    Destroy(transform.gameObject);
                    GameObject.Find("Computer").GetComponent<QuestManager>().deleteIndex(QuestStatus.questIndex);
                }
                else
                {
                    GameObject.Find("MultipleQuests").GetComponent<MultipleQuests>().show();
                }
            }
        }
    }
}