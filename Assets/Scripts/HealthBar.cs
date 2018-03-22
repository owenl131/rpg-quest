using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float barDisplay;
    public int currHealth = 5;
    public GUIStyle gs;
    private bool hidden;
    private bool lost;
    private Vector2 pos;
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;
    private Vector2 size;
    public int totalHealth = 5;

    private void Start()
    {
        pos = new Vector2(300, 20);
        size = new Vector2(200, 40);
        barDisplay = 1;
        hidden = true;
    }

    public void show()
    {
        if (hidden)
        {
            if (LevelTrack.indexToString(Application.loadedLevel).Equals("Quest7BossBattle"))
            {
                pos = new Vector2(550, 100);
            }
            else
            {
                pos = new Vector2(300, 20);
            }
            hidden = false;
        }
    }

    public void reset(int health)
    {
        currHealth = health;
        totalHealth = health;
    }

    public void reset()
    {
        reset(5);
    }

    public void hide()
    {
        if (!hidden)
            hidden = true;
    }


    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void OnGUI()
    {
        if (!hidden)
        {
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y + 50.0f));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
            GUI.Label(new Rect(0, 30.0f, size.x, size.y + 50.0f), "    Player: " + currHealth + "/" + totalHealth, gs);
            GUI.BeginGroup(new Rect(0, 0, size.x*barDisplay, size.y));
            GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);

            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            barDisplay = (float) currHealth/totalHealth;
            if (currHealth < 1 && !lost)
            {
                lost = true;
                MoneyCounter.reducePercentage(20);
                DayCounter.reduceDays();
                GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("FailQuest");
            }
            else if (currHealth < 1 && !Application.loadedLevelName.Equals("FailQuest"))
            {
                GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("FailQuest");
            }
        }
    }

    public void reduceHealth()
    {
        currHealth--;
    }
}