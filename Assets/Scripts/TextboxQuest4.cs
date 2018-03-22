using UnityEngine;

public class TextboxQuest4 : MonoBehaviour
{
    public Transform background;
    private int complete;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private int showBack;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.042f, 0.223f, 0);
        text = new string[20];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Me: Found you! Let's go. Mom's waiting.";
        text[x++] = "Boy: Wait, 5 more minutes, I must win the 'spin the wheel' challenge...";
        text[x++] = "...";
        showBack = x;
        text[x++] =
            "Mrs Sugars: How should I express my gratitude!? My boy is so terrible \nat controlling himself, it's as if he's a gambler.";
        text[x++] = "Me: Well, if the game is affecting him in such a negative way, \n it is best to avoid these games.";
        text[x++] =
            "Me: I recently read a book, when I was passing time in the library, \nthat humans, especially teenagers, are thrilled by the";
        text[x++] =
            "Me: experience of gambling, thus if measures are not taken in time, \ngambling can become popular among them. ";
        text[x++] =
            "Mrs Sugars: Indeed, the web stated that some developers take advantage of \nthis and hide gambling elements in the games.";
        text[x++] =
            "Me: Hey, that sounds possible, on the surface it seems \nharmless, but in the long run even games";
        text[x++] = "Me: like these can have adverse effects on the player.";
        text[x++] = "Mrs Sugars: Boy, come here. You need to be educated, but my \nlectures are useless against you...";
        text[x++] =
            "Me: Luckily, I found this game online which seems really \neducational and fun at the same time!";
        text[x++] =
            "Me: What is it called again? ... \nOh yes! It's called 'rPG Quest'! Have fun!";
        text[x++] = "Me: Sayonara!";
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
            if (index == showBack)
            {
                GameObject.Find("Darkness").GetComponent<GUITexture>().enabled = false;
                background.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            if (index == complete)
            {
                DayCounter.reduceDays();
                MoneyCounter.addAmt(1200);
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
                QuestStatus.questIndex = -1;
                QuestStatus.questLoc = -1;
                index++;
                Time.timeScale = 1;
            }
        }
    }
}