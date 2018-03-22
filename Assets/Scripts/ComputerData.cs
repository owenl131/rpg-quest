using UnityEngine;

public class ComputerData : MonoBehaviour
{
    public float posx;
    public float[] posy;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        posy = new[] {1.2f, -0.3f, -1.8f};
        posx = -1.1f;
    }

    public void showScreen()
    {
        var qm = GetComponent<QuestManager>();
        Debug.Log("Updating screen");
        for (var i = 0; i < 3; i++)
        {
            if (qm.getList()[i] != null)
            {
                var g = new GameObject("Quest" + qm.getList()[i].index);
                Debug.Log(g.gameObject.name);
                g.AddComponent<SpriteRenderer>();
                g.gameObject.tag = "listItem";
                g.GetComponent<SpriteRenderer>().sprite = qm.getList()[i].sprite;
                g.GetComponent<SpriteRenderer>().sortingOrder = qm.getList()[i].location;
                g.AddComponent<SelectQuest>();
                var t = g.GetComponent<Transform>();
                t.position = new Vector3(posx, posy[i], 0);
            }
        }
    }

    public void reloadData()
    {
        var qm = GetComponent<QuestManager>();
        qm.shuffle();
    }
}