using UnityEngine;

public class TextboxQuest6 : MonoBehaviour
{
    private int complete;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[] text;
    private bool won;

    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.84f, 0);
        won = false;
        text = new string[20];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Scaredy: Ah! Sorry I'm late... You see, I was at the casino for a while.";
        text[x++] = "Scaredy: Don't tell my wife, of course, or she'll be mad at me.";
        text[x++] = "Scaredy: Well, anyway I was only there for an hour, I reached \nat 10am and now its 5pm...";
        text[x++] = "Me: That's not just an hour!";
        text[x++] =
            "Scaredy: Um... Hey, it was a worth it investment of my time, \nat least, I started off with $1000 and now...";
        text[x++] = "Scaredy: I have... $100, $200, $300, $400, $500 bucks!";
        text[x++] = "Me: ... (Should I tell him that 500 is less than 1000?)";
        text[x++] = "Scaredy: Let's go anyway... I'll lead the way...";
        complete = x;
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, 0,
                Camera.main.transform.position.z + 1.1f);
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
            if (index == complete && !won)
            {
                Time.timeScale = 1;
                won = true;
                DayCounter.reduceDays();
                MoneyCounter.addAmt(1800);
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
            }
        }
    }
}