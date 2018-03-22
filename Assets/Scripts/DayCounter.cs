using UnityEngine;

public class DayCounter : MonoBehaviour
{
    private static int daysLeft;
    public static bool hide;
    private static bool lose;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        daysLeft = GameProperties.deadline;
        hide = false;
        lose = false;
    }

    private void Update()
    {
        var ll = LevelTrack.indexToString(Application.loadedLevel);
        if (ll.Equals("StartPage") || ll.Equals("Phone") || ll.Equals("HomeTV") || ll.Equals("Credits") ||
            ll.Equals("Instructions_1") || ll.Equals("Instructions_2") || ll.Equals("Instructions_3") ||
            ll.Equals("Instructions_4") || ll.Equals("Instructions_5") || ll.Equals("Computer") ||
            ll.Equals("4D") || ll.Equals("CompleteQuest") || ll.Equals("FailQuest") || ll.Equals("ExitQuest") ||
            ll.Equals("EndGame") || ll.Equals("Phone") || ll.Equals("HomeTV") || ll.Equals("Menu") ||
            ll.Equals("Instructions_6") || ll.Equals("Instructions_7") || ll.Equals("Instructions_8"))
        {
            hide = true;
        }
        else
        {
            hide = false;
        }
        if (gameObject.tag == "Text")
        {
            GetComponent<GUIText>().text = "Days Left: " + daysLeft;
            if (hide)
                GetComponent<GUIText>().text = "";
        }
        if ((ll.Equals("Home") || ll.Equals("Town") || ll.Equals("Office")) && daysLeft <= 0 && (!lose || !LevelTrack.indexToString(Application.loadedLevel).Equals("EndGame")))
        {
            lose = true;
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("EndGame");
        }
    }

    public static void reset()
    {
        daysLeft = GameProperties.deadline;
        hide = false;
        lose = false;
    }

    public static bool getResult()
    {
        return lose;
    }

    public static int getDays()
    {
        return daysLeft;
    }

    public static void reduceDays()
    {
        Debug.Log("reloading data");
        daysLeft--;
        QuestStatus.questLoc = -1;
        QuestStatus.questIndex = -1;
        GameObject.Find("Computer").GetComponent<ComputerData>().reloadData();
        GameObject.Find("TextboxBank").GetComponent<TextBoxBank>().interest();
        if (daysLeft%3 == 0)
        {
            WinningNumber.generateNum();
        }
    }
}