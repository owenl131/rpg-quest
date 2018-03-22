using UnityEngine;

public class PhoneMapSetter : MonoBehaviour
{
    public Sprite dungeonMap;
    public Sprite forestMap;
    private SpriteRenderer rend;
    public Sprite townMap;
    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void hide()
    {
        rend.sprite = null;
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }

    public void set()
    {
        var prev = LevelTrack.indexToString(LevelTrack.prevLevel);
        Debug.Log(prev);
        if (prev.Equals("Town") || prev.Equals("Home") || prev.Equals("Casino") || prev.Equals("Office"))
        {
            rend.sprite = townMap;
        }
        else if (prev.Equals("Forest3D"))
        {
            rend.sprite = forestMap;
        }
        else if (prev.Equals("Dungeon"))
        {
            rend.sprite = dungeonMap;
        }
        else
        {
            rend.sprite = null;
        }
    }

    public void showQuest()
    {
        var s = Resources.Load("JobBoxQuest" + QuestStatus.questIndex, typeof (Sprite)) as Sprite;
        Debug.Log(QuestStatus.questIndex);
        transform.localScale = new Vector3(0.85f, 0.85f, 1);
        if (s != null)
            rend.sprite = s;
    }
}