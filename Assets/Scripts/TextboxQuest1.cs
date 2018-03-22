using UnityEngine;

public class TextboxQuest1 : MonoBehaviour
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
        gt.transform.position = new Vector3(0.07f, 0.2f, 0);
        text = new string[20];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Mr A: Quick, come in, they're on the lookout for both of us...";
        text[x++] = "Me: Um..., I have a question. Why are you living in such a \nsecluded place?";
        text[x++] =
            "Mr A: Well, I only recently began my journey away from gambling \nand I must admit the urges to gambler have not yet ceased.";
        text[x++] =
            "Mr A: I was advised by a counsellor to seek a more conducive \nenvironment for recovery, under the behavioural therapy.";
        text[x++] =
            "Mr A: Ok, so... How should I start? To put it simply, I know \nabout these people because I once worked under them.";
        text[x++] =
            "Mr A: They became money lenders because they thought they would \nbe able to pay off their debts with the earnings.";
        text[x++] =
            "Mr A: They often send in applications for normal jobs though, but are \nalways rejected after the interview.";
        text[x++] =
            "Mr A: You see, it is of utmost importance that you repay your debt\nquickly, both for yourself and for many others.";
        text[x++] =
            "Mr A: I am lucky that I am fairly well educated and my friend \nmanaged to find a place for me in his company.";
        text[x++] = "Mr A: Oh yes! I must insist, do not resort to gambling to \nregain your losses.";
        text[x++] =
            "Mr A: Statistics have shown that there will be a net loss \nof money due to gambling. It's just not worth it.";
        text[x++] = "Mr A: I hope I  have not bored you with all this. \nGood luck on your endeavours!";
        complete = x;
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, 0,
                Camera.main.transform.position.z - 1.1f);
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
            if (Input.GetKeyDown(KeyCode.Space))
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