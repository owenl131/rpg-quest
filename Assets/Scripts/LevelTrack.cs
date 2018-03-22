using UnityEngine;

public class LevelTrack : MonoBehaviour
{
    public static int prevLevel;
    private static string[] levelString;
    private static int end;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        prevLevel = 0;
        levelString = new string[40];
        var x = 0;
        levelString[x++] = "StartPage";
        levelString[x++] = "Menu";
        levelString[x++] = "Credits";
        levelString[x++] = "Instructions_1";
        levelString[x++] = "Instructions_2";
        levelString[x++] = "Instructions_3";
        levelString[x++] = "Instructions_4";
        levelString[x++] = "Instructions_5";
        levelString[x++] = "Introduction";
        levelString[x++] = "Home";
        levelString[x++] = "Town";
        levelString[x++] = "Casino";
        levelString[x++] = "Office";
        levelString[x++] = "Computer";
        levelString[x++] = "Forest3D";
        levelString[x++] = "Dungeon";
        levelString[x++] = "Phone";
        levelString[x++] = "HomeTV";
        levelString[x++] = "4D";
        levelString[x++] = "CompleteQuest";
        levelString[x++] = "ExitQuest";
        levelString[x++] = "FailQuest";
        levelString[x++] = "EndGame";
        levelString[x++] = "Quest5";
        levelString[x++] = "Sleep";
        levelString[x++] = "Quest7BossBattle";
        levelString[x++] = "CounsellingCentre";
        levelString[x++] = "Quest10";
        levelString[x++] = "Bank";
        levelString[x++] = "Instructions_6";
        levelString[x++] = "Instructions_7";
        levelString[x++] = "Instructions_8";
        levelString[x++] = "slotmachine";
        end = x;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.M))
        {
            Application.LoadLevel("slotmachine");
        }
        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.P))
        {
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Phone");
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.N))
        {
            MoneyCounter.addAmt(10000);
        }
        if (Input.GetKey(KeyCode.L) && Input.GetKeyDown(KeyCode.O))
        {
            DayCounter.reduceDays();
        }
        if (Input.GetKey(KeyCode.T) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.N))
        {
            Application.LoadLevel("Town");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                QuestStatus.questIndex = 0;
                QuestStatus.questLoc = 4;
                Application.LoadLevel("Casino");
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                QuestStatus.questIndex = 1;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                QuestStatus.questIndex = 2;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                QuestStatus.questIndex = 3;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {
                QuestStatus.questIndex = 4;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha5))
            {
                QuestStatus.questIndex = 5;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha6))
            {
                QuestStatus.questIndex = 6;
                QuestStatus.questLoc = 1;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha7))
            {
                QuestStatus.questIndex = 7;
                QuestStatus.questLoc = 0;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha8))
            {
                QuestStatus.questIndex = 8;
                QuestStatus.questLoc = 3;
                Application.LoadLevel("Town");
            }
            if (Input.GetKey(KeyCode.Alpha9))
            {
                QuestStatus.questIndex = 9;
                QuestStatus.questLoc = 2;
                Application.LoadLevel("Town");
            }
        }
        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.R))
        {
            Application.LoadLevel("Forest3D");
        }
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.I))
        {
            Application.LoadLevel("Office");
        }
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            Application.LoadLevel("Casino");
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.N))
        {
            Application.LoadLevel("Dungeon");
        }
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.K))
        {
            Application.LoadLevel("Bank");
        }
    }

    public static int stringToIndex(string s)
    {
        for (var i = 0; i < end; i++)
        {
            if (levelString[i].Equals(s))
                return i;
        }
        return -1;
    }

    public static string indexToString(int index)
    {
        return levelString[index];
    }
}