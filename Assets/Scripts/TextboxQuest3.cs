using UnityEngine;

public class TextboxQuest3 : MonoBehaviour
{
    public Transform background;
    private int choice;
    private int complete;
    public Font f;
    private int getChoice;
    public GUIText gt;
    private bool hidden;
    private int index;
    private int showBack;
    private string[] text;
    // Use this for initialization
    private void Start()
    {
        gt.transform.position = new Vector3(0.042f, 0.223f, 0);
        text = new string[15];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Me: (I should hurry back now...)";
        showBack = x;
        text[x++] =
            "Mr Smokey: Ah, Thanks! You are an ex-gambler changing for the better?\nMe too! Let me share my success story.";
        text[x++] =
            "Mr Smokey: I was constantly losing money in the casino, and soon \nfell into depression and anxiety.";
        text[x++] =
            "Mr Smokey: Realising that I was unable to cope, I was determined \nto change. Soon, I found myself smoking.";
        getChoice = x;
        text[x++] = "Mr Smokey: Can you sponsor me $50 for my supply of cigarettes?\nY: Yes\t\tN: No";
        text[x++] = "";
        text[x++] =
            "Me: (This guy must have become addicted to smoking in order to \ndistract himself from the painful reality...)";
        text[x++] = "Me: (Addictions are difficult to let go of, aren't they?)";
        text[x++] = "Me: Smoking, like gambling, has tons more negative effects than \npositive ones.";
        text[x++] = "Me: I can only suggest that you stop before its too late.";
        text[x++] = "Me: Farewell.";
        complete = x;
        choice = -1;
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
            if (index == showBack)
            {
                background.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
            }
            if (index == getChoice)
            {
                if (Input.GetKeyDown(KeyCode.Y))
                {
                    choice = 0;
                    text[getChoice + 1] =
                        "Mr Smokey: Thanks again! This would be enough for 5 sticks a day, \nI guess...";
                    MoneyCounter.reduceAmt(50);
                    index++;
                }
                else if (Input.GetKeyDown(KeyCode.N))
                {
                    choice = 1;
                    text[getChoice + 1] =
                        "Mr Smokey: Huh? Well, suppose you're low on budget too...";
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
                MoneyCounter.addAmt(1000);
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
                QuestStatus.questIndex = -1;
                QuestStatus.questLoc = -1;
                index++;
                Time.timeScale = 1;
            }
        }
    }
}