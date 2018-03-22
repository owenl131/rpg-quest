using UnityEngine;

public class TextboxBossOffice : MonoBehaviour
{
    private int choice = -1;
    private int complete = -1;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[,] news;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.08f, 0.215f, 0);
        text = new string[20];
        news = new string[2, 8];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        if (MoneyCounter.getResult())
        {
            var x = 0;
            text[x++] = "Boss: It has been a while, Bob, and my, how you've changed!";
            text[x++] = "Boss: When I first met you, you constantly had this \ninclination to gamble whenever possible.";
            text[x++] = "Me: Indeed, I can't deny these recent experiences have \nbeen memorable.";
            text[x++] = "Boss: I've got some good and bad news for you. \nWhich do you want first?";
            choice = x;
            text[x++] = "Choose: 1. Good news   2. Bad news";
            //choice 1
            news[0, 0] = "Boss: For the good news, you've cleared your debt \nand you've been promoted!";
            news[0, 1] = "Me: Wow! Gee, thanks. I'll be ever grateful for your \nsupport in this job.";
            news[0, 2] = "Boss: Of course, this would not be possible without your \nhardwork and perseverance.";
            news[0, 3] = "Boss: Now, for the bad news... You're fired. (Huh!?)";
            news[0, 4] = "Boss: Not how you understand it. In this company there are the \nemployees and the boss.";
            news[0, 5] = "Boss: Now that you've been promoted, I've found you a job \nin a Creative Enterprise.";
            news[0, 6] =
                "Boss: The pay is good, colleagues are active and friendly, \nenvironment is clean and of course it's stable.";
            news[0, 7] = "Boss: Life would never be boring again. \nGood Luck in your new life!";
            //choice 2
            news[1, 0] = "Boss: Nah, I'll tell you the good news first. \nGood to be optimistic you know...";
            news[1, 1] = "Boss: You've cleared your debt and you've been \npromoted!";
            news[1, 2] = "Me: Wow! Gee, thanks.";
            news[1, 3] = "Boss: Now, for the bad news... You're fired. (Huh!?)";
            news[1, 4] = "Boss: Not how you understand it. In this company there are \nthe employees and the boss.";
            news[1, 5] = "Boss: Now that you've been promoted, I've found you a job \nin a Creative Enterprise.";
            news[1, 6] =
                "Boss: The pay is good, colleagues are active and friendly, \nenvironment is clean and of course it's stable.";
            news[1, 7] = "Boss: Life would never be boring again. \nGood Luck in your new life!";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "";
            text[x++] = "...";
            text[x++] =
                "Your journey doesn't end here. Discourage problem gambling \nin your society through various means, ";
            text[x++] = "promote this game, create a campaign, spread the news, etc.";
            complete = x;
        }
        else
        {
            var x = 0;
            text[x++] = "Boss: I haven't met you for so long, Bob, and my, \nhow you've changed!";
            text[x++] = "Boss: I don't think I need to remind you, but your \ndeadline is up and you're in trouble.";
            text[x++] = "Me: Huh? Did anything happen?";
            text[x++] = "Boss: Your mother is in the hospital. It seems \nlike she was attacked by the ah longs...";
            text[x++] = "Boss: Thankfully I had sent some men there to take \ncare of the situation.";
            text[x++] = "Boss: Anyway, they finally agreed to extend your \ndeadline by another 7 days, ";
            text[x++] = "With the condition that the interest is increased \nfurther.";
            text[x++] =
                "Boss: Now your debt is roughly... $10000 with your house \nmortgaged... Back to square one, I see...";
            text[x++] = "Boss: I am willing to extend your contract, but I must warn \nyou, should the interest";
            text[x++] = "increase any further, you will never be able to pay it back \nby honest means.";
            text[x++] = "Me: I get it... 100% was not sufficient, I will have to put \nin 110% to succeed...";
            complete = x;
        }
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
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
            if (index == choice)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    for (var i = 0; i < 8; i++)
                    {
                        text[choice + i + 1] = news[0, i];
                    }
                    index++;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    for (var i = 0; i < 8; i++)
                    {
                        text[choice + i + 1] = news[1, i];
                    }
                    index++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            if (index == complete)
            {
                Time.timeScale = 1;
                gt.text = "";
                hidden = true;
                Camera.main.transform.position = new Vector3(0, 0, -10);
                GameObject.Find("Number").GetComponent<textbox3>().show();
            }
        }
    }
}