using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    private static int amt;
    public static bool hide;
    private static bool win;

    private void Start()
    {
        amt = 100;
        hide = false;
        win = false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
            GetComponent<GUIText>().text = "Money: $" + amt + "\nDebt: $" + GameProperties.debt;
            if (hide)
                GetComponent<GUIText>().text = "";
        }
        if ((ll.Equals("Home") || ll.Equals("Town") || ll.Equals("Office")) && amt + TextBoxBank.getBalance() > GameProperties.debt && (!win || !Application.loadedLevelName.Equals("EndGame")))
        {
            Debug.Log("win by money");
            win = true;
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("EndGame");
        }
        else if (amt < 0)
        {
            GameProperties.debt -= amt;
            amt = 0;
        }
    }

    public static void reset()
    {
        amt = 100;
        hide = false;
        win = false;
    }

    public static bool getResult()
    {
        return win;
    }

    public static int getAmt()
    {
        return amt;
    }

    public static void reduceAmt(int x)
    {
        if (x > 0)
            amt -= x;
    }

    public static void reducePercentage(int x)
    {
        if (x >= 0 && x <= 100)
        {
            amt = amt*(100 - x)/100;
        }
    }

    public static void setAmt(int x)
    {
        amt = x;
    }

    public static void addAmt(int x)
    {
        amt += x;
    }
}