using UnityEngine;

public class TextBox1 : MonoBehaviour
{
    public static int choice1 = 1;
    private int checkJob = -1;
    public int choice2 = -1;
    private int chooseJob = -1;
    private int chooseStory = -1;
    private int count;
    public GUIText gt;
    private int index;
    public string[,] job;
    public string[] story;
    public string[] text;

    private void Start()
    {
        text = new string[50];
        story = new string[10];
        job = new string[30, 2];
        var x = 0;
        //0
        text[x++] = "Greetings! You may not have heard of me, but I am \nDr Watson the wise... \t\t<Press Spacebar to continue...>";
        text[x++] = "I see you've stumbled upon the world of \nproblem gambling, my area of expertise, in fact.";
        text[x++] = "I notice you have a debt of $" + GameProperties.debt + " and \nyou have only " +
                    GameProperties.deadline + " days to your deadline.";
        text[x++] = "Actually, I would like to offer my help in \nrelation to your big problems.";
        text[x++] = "Um, if you don't mind, can you recall how or why \nyou became a problem gambler?";
        //5
        text[x++] = "This would help greatly in my studies and research.";
        chooseStory = x;
        text[x++] = "1: Entertainment and Addiction\n" +
                    "2: Stress and Anxiety    3: Can't remember";
        text[x++] = "";
        story[1] =
            "I see... indeed, many tend to regard light gambling as \nharmless, and only realise they're addicted when its too late.";
        story[2] =
            "The jobless and troubled, the immense stress from the lack\nof money often causes one to succumb to temptations.";
        story[3] =
            "It seems you suffer from amnesia? It might have been a \nresult of depression, but I doubt you remember the reason.";
        text[x++] =
            "It seems like you've accumulated the huge debt from \nborrowing money from unlicensed money lenders...";
        text[x++] =
            "First of all, I have submitted a few applications \nfor jobs...";
        chooseJob = x;
        //10
        text[x++] = "Would you like to choose 1 of them?\n" +
                    "1: Trigonal Bank    2: Delivery Inc.    3: Tasukete Co.";
        text[x++] = "";
        text[x++] = "";
        job[1, 0] =
            "Trigonal Representative: Sorry, but we'll have to reject \nyour application, for us who deal with money, integrity ";
        job[1, 1] = "and account management are key. Come back next year \nwith a cleaner record and we'll reconsider.";
        job[2, 0] =
            "Delivery Inc Representative: My deepest apologies for the \nrejection. I understand your plight, but as you know our company is";
        job[2, 1] =
            "highly famed for reliability, so we cannot risk someone \nlike you working with us. I hope you understand too.";
        job[3, 0] =
            "Welcome to our company! We at Tasukete welcomes anyone with \nwill and passion. I hope you feel at home!";
        job[3, 1] = "Judging from the address you submitted, our hq \nis fairly near to your home. See you on Monday!";
        checkJob = x;
        text[x++] = "Job application for Tasukete successful... \nGood luck on your journey...";
        //14

        update();
    }

    private void Update()
    {
        count++;
        if (index == checkJob && (choice2 == 1 || choice2 == 2))
        {
            index = checkJob - 3;
        }
        else if (index == chooseStory)
        {
            var x = numInput();
            if (x != -1)
            {
                choice1 = x;
                text[chooseStory + 1] = story[choice1];
                index++;
            }
        }
        else if (index == chooseJob)
        {
            var x = numInput();
            if (x != -1)
            {
                choice2 = x;
                text[chooseJob + 1] = job[choice2, 0];
                text[chooseJob + 2] = job[choice2, 1];
                index++;
            }
        }
        else if (Input.GetKey(KeyCode.Space) && count > 10)
        {
            count = 0;
            index++;
        }
        if (index > checkJob)
        {
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Home");
        }
        else
        {
            update();
        }
    }

    private void update()
    {
        gt.GetComponent<GUIText>().text = text[index];
    }

    public int numInput()
    {
        bool a = false, b = false, c = false, d = false, e = false;
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            a = true;
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            b = true;
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            c = true;
        /*if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            d = true;
        if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
            e = true;*/
        if (a && !(b || c || d || e))
            return 1;
        if (b && !(a || c || d || e))
            return 2;
        if (c && !(a || b || d || e))
            return 3;
        /*if (d && !(a || b || c || e))
            return 4;
        if (e && !(a || b || c || d))
            return 5;*/
        return -1;
    }
}