using System.Collections;
using UnityEngine;

public class Quest10Controller : MonoBehaviour
{
    private ArrayList addons;
    public Quest10Arrow arrow;
    private int boost;
    private string choice;
    private int complete;
    public GUIText gt;
    private readonly Vector3 gtPos = new Vector3(0.07f, 0.22f, 0);
    private int index = 1;
    private string[] intro;
    private int makeChoice;
    private readonly Vector3 opPos = new Vector3(0.05f, 0.75f, 0);
    public GUIText options;
    private int part;
    private bool part2;
    public GUIText score;
    private int stop;
    private int successful;
    private string[] t;
    private readonly Vector3 tbPos = new Vector3(0, -2.1f, -20f);
    public GameObject textbox;
    private int textIndex;
    private int total = 10;

    private void Start()
    {
        gt.transform.position = gtPos;
        textbox.transform.position = tbPos;
        options.transform.position = opPos;
        successful = 0;
        index = 0;
        part = 0;
        addons = new ArrayList();
        initAddOns();
        textIndex = 0;
        boost = 0;
        intro = new string[20];
        t = new string[20];
        GameObject.Find("Neuron").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Arrow").GetComponent<SpriteRenderer>().enabled = false;
    }

    public void next(bool won)
    {
        index++;
        if (index == 30)
        {
            part = 6;
            GameObject.Find("Neuron").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Arrow").GetComponent<SpriteRenderer>().enabled = false;
            arrow.deactivate();
            return;
        }
        if (index == 20 && part2)
        {
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Home");
        }
        boost = 0;
        GameObject.Find("Neuron").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("Neuron").GetComponent<BoxCollider2D>().enabled = true;
        Debug.Log("next loaded");
    }

    public void success()
    {
        successful++;
        if (successful >= 5 && (float) successful/index >= 0.5f)
        {
            //complete
            part = 5;
        }
    }

    private void Update()
    {
        if (index != 0)
            score.text = successful + " / " + index + " : " + (successful*100f/index) + "%";
        if (part == 0) //initialise
        {
            showBox();
            var x = 0;
            intro[x++] = "Me: Where am I?";
            intro[x++] = "Me: It looks like a brain... within someone's mind...";
            intro[x++] = "...";
            intro[x++] =
                "Mr CIP: You have gathered quite a number of gamblers, \nconsisting of both managing gamblers and problem gamblers.";
            intro[x++] = "Mr CIP: Your mission is to convince them to apply for a casino \nself-exclusion.";
            intro[x++] = "Me: Huh? What is that?";
            intro[x++] =
                "Mr CIP: Casino self-exclusions are procedures by which gamblers \ncan prohibit themselves from entering a casino.";
            intro[x++] =
                "Mr CIP: It is completely voluntary and aims to aid gamblers in \nlimiting or possibility ceasing their gambling problem.";
            intro[x++] =
                "Mr CIP: Studies have shown this measure to be fairly effective \nin changing gamblers' mindsets.";
            intro[x++] =
                "Mr CIP: If you have more questions, the NCPG and other problem \ngambling sites welcome you.";
            intro[x++] = "Mr CIP: So let's begin!";
            intro[x++] = "[Instructions]";
            intro[x++] =
                "Shoot the arrow into the gambling impulse to distract the person \nfrom gambling and to make your message sink in.";
            intro[x++] = "Aim and press the spacebar to shoot.";
            intro[x++] =
                "While the arrow is flying you can press the spacebar again, to \ngive your message an extra boost with a catchphrase.";
            intro[x++] =
                "Good luck! Convince at least 5 gamblers at a minimum of a \n50% success rate to complete this quest.";
            complete = x;
            part++;
        }
        else if (part == 1) //show introductory text
        {
            gt.text = intro[textIndex];
            if (textIndex == complete)
            {
                part++;
                GameObject.Find("Neuron").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Arrow").GetComponent<SpriteRenderer>().enabled = true;
                hideBox();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                textIndex++;
            }
        }
        else if (part == 2) //start game
        {
            arrow.activate();
            part++;
        }
        else if (part == 3) //if boost selected
        {
            if (boost == 1)
            {
                Time.timeScale = 0;
                showOptions();
                part++;
            }
            else if (boost == 0)
            {
                options.text = "Press the spacebar for a boost!";
            }
        }
        else if (part == 4) //make selection for boost
        {
            var x = GetInput(0);
            if (!x.Equals(""))
            {
                //100, 150, 200, 250, 300
                var mag = Random.Range(0, 5)*50;
                mag += 100;
                arrow.boost(mag);
                part = 3;
                boost = 2;
                Time.timeScale = 1;
                options.text = "";
            }
        }
        else if (part == 5)
        {
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("CompleteQuest");
            MoneyCounter.addAmt(1500);
            DayCounter.reduceDays();
            part = 100;
        }
        else if (part == 6)
        {
            var x = 0;
            t[x++] = "Mr CIP: Looks like the gamblers here are rather stubborn...";
            t[x++] = "Mr CIP: Well, there are two choices - ";
            makeChoice = x;
            t[x++] =
                "1) Abort this quest or 2) Donate $100 to the problem gamblers' \nfund and go on to the next room, where there are 20 gamblers.";
            t[x++] = "Better not to take the risk. Bye!";
            complete = x;
            part++;
            showBox();
            textIndex = 0;
        }
        else if (part == 7)
        {
            gt.text = t[textIndex];
            if (textIndex == makeChoice)
            {
                choice = GetInput(1);
                if (!choice.Equals(""))
                {
                    if (choice.Equals("1"))
                        t[textIndex + 1] = "Better not to take the risk, right? Bye!";
                    else
                        t[textIndex + 1] = "Sure! It's worth a try, let's go!";
                    textIndex++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
                textIndex++;
            if (textIndex == complete)
            {
                if (choice.Equals("2"))
                {
                    successful = 0;
                    index = 1;
                    part++;
                    GameObject.Find("Neuron").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Arrow").GetComponent<SpriteRenderer>().enabled = true;
                    arrow.reset();
                    hideBox();
                    gt.text = "";
                    part2 = true;
                    MoneyCounter.reduceAmt(100);
                }
                else if (choice.Equals("1"))
                {
                    GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Home");
                }
            }
        }
        else if (part == 8)
        {
            if (boost == 1)
            {
                Time.timeScale = 0;
                showOptions();
                part++;
            }
            else if (boost == 0)
            {
                options.text = "Press the spacebar for a boost!";
            }
        }
        else if (part == 9)
        {
            var x = GetInput(0);
            if (!x.Equals(""))
            {
                //100, 150, 200, 250, 300
                var mag = Random.Range(0, 5)*50;
                mag += 100;
                arrow.boost(mag);
                part = 3;
                boost = 2;
                Time.timeScale = 1;
                options.text = "";
            }
        }
    }

    private string GetInput(int type)
    {
        if (type == 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                return "1";
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                return "2";
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                return "3";
        }
        else if (type == 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                return "1";
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                return "2";
        }
        return "";
    }

    private void initAddOns()
    {
        addons.Add("There is but one good throw upon the dice, \nwhich is, to throw them way.");
        addons.Add("The more accurate definition of lottery: \nA tax on people who are bad at Math.");
        addons.Add("The only way to return from the casino with a \nsmall fortune is to go there with a large one.");
        addons.Add(
            "It's hard to walk away from a winning streak, \neven harder to leave the table when you're on a losing one.");
        addons.Add("There is no magical formula to beat the casino.");
        addons.Add("Impulses to gamble are like Tissues. \nPull one out and another appears.");
        addons.Add("If you gamble long enough, you'll always lose -- \nthe gambler is always ruined.");
        addons.Add("A mistaken notion connected with the flaw \nof large numbers is the idea " +
                   "\nthat an event is more or less likely to appear \nbecause it has or has not occured recently.");
        addons.Add("The more accurate definition of gambling: \nThe sure way of getting nothing out of something.");
        addons.Add("In a bet there is fool and a thief.");
        addons.Add("The house doesn't beat the player. \nIt just gives him the opportunity to beat himself.");
        addons.Add("By gambling we lose both our time and treasure - \ntwo things most precious to the life of man.");
        addons.Add("Luck never gives; it only lends.");
        addons.Add("Horse sense is a good judgement which keeps \nhorses from betting on people.");
        addons.Add("Quit while you're ahead. All the best gamblers do.");
        addons.Add("Those who can afford to gamble don't need the money; \nThose who need money can't afford to gamble.");
        addons.Add("Gamblers never make the same mistake twice, \nusually two or three times.");
    }

    private void showOptions()
    {
        shuffle();
        var s = "Choose!\n\n";
        for (var i = 0; i < 3; i++)
        {
            s += (i + 1) + ". " + addons[i] + "\n\n";
        }
        options.text = s;
    }

    private void shuffle()
    {
        var len = addons.Count;
        for (var i = 0; i < 100; i++)
        {
            var a = Random.Range(0, len);
            var b = Random.Range(0, len);
            var temp = (string) addons[a];
            addons[a] = addons[b];
            addons[b] = temp;
        }
    }

    private void showBox()
    {
        textbox.transform.position += new Vector3(0, 0, 20f);
    }

    private void hideBox()
    {
        textbox.transform.position = tbPos;
    }

    public void boostClicked()
    {
        if (boost == 0)
            boost = 1;
    }
}