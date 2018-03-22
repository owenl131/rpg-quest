using UnityEngine;

public class TextboxQuest2 : MonoBehaviour
{
    private int choice;
    private int complete;
    public Font f;
    private int getChoice;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[] text;
    // Use this for initialization
    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.22f, 0);
        text = new string[10];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Mr Bets: You're here to save me? How can I ever repay you?";
        text[x++] =
            "Mr Bets: I'm so sorry, but... erm... how should I say it?\nMy family is struggling with its finances.";
        text[x++] = "Mrs Bets: I should never have allowed him to enter \nthe casino in the first place...";
        getChoice = x;
        text[x++] = "Mr Bets: Would $500 as the reward be sufficient for you?\nY: Yes\t\tN: No";
        text[x++] = "";
        text[x++] = "Me: Let's head back... Goodbye!";
        complete = x;
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, 0,
                Camera.main.transform.position.z - 1.4f);
            hidden = false;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            if (text[index] != null)
                gt.text = text[index];
            if (index == getChoice)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    choice = 0;
                    text[getChoice + 1] =
                        "Mr Bets: Your sincerity is too touching! I'll give you $1000 instead.\nI'll work hard to earn it back.";
                    index++;
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    choice = 1;
                    text[getChoice + 1] =
                        "Mr Bets: I see, you're in debt too... I'm so sorry my friend, \nbut my debt is double yours. Forgive me...";
                    index++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            if (index == complete)
            {
                DayCounter.reduceDays();
                if (choice == 0)
                    MoneyCounter.addAmt(1000);
                else if (choice == 1)
                    MoneyCounter.addAmt(500);
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
                QuestStatus.questIndex = -1;
                QuestStatus.questLoc = -1;
                index++;
                Time.timeScale = 1;
            }
        }
    }
}