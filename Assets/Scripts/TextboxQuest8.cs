using UnityEngine;

public class TextboxQuest8 : MonoBehaviour
{
    private string[] ans;
    private int[] choose;
    private int complete;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private int[,] opp;
    public GameObject player;
    private int qIndex;
    private int[] qtype;
    private int[] score;
    public GUIText scoreboard;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.05f, 0.22f, 0);
        scoreboard.transform.position = new Vector3(0.5f, 0.7f, 0);
        text = new string[100];
        opp = new int[15, 5];
        for (var i = 0; i < 15; i++)
            opp[i, 0] = 0;
        choose = new int[15];
        ans = new string[15];
        score = new int[15];
        qtype = new int[15];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        index = 0;
        qIndex = 0;
        var x = 0;
        var q = 0;
        text[x++] = "Host: Welcome to this year's Fact or Fiction contest! \n$800 is up for grabs and it could easily";
        text[x++] = "be yours, if you answer all these questions correctly!";
        text[x++] =
            "Host: Well, then let's begin! Assembled here, we have Bob the builder, \nEdward Thorp, Richard Marcus, Ron Harris and many more!";
        text[x++] = "Host: Looks like many infamous gamblers have gathered today! \nAre you ready???";
        ans[q] = "T";
        qtype[q] = 0;
        opp[q, 1] = 1;
        opp[q, 2] = 1;
        opp[q, 3] = 0;
        choose[q++] = x;
        text[x++] =
            "Question 1: You don't have to gamble everyday to be a \nproblem gambler.   (T): True or (F): false?";
        text[x++] = "Richard: Of course you do! Why else would they be called Problem \nGamblers?";
        text[x++] = "Me: ...";
        text[x++] = "Host: and the answer is...";
        text[x++] = "Host: True! Problem gambling could occur frequently or infrequently.";
        text[x++] = "Host: The main defining characteristic of problem gambling is that it \ncauses problems.";
        text[x++] = "Ron: If gambling made me go to jail, is that considered a problem?";
        text[x++] = "Host: Well, ... never mind. Next,";
        ans[q] = "F";
        opp[q, 1] = 1;
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        qtype[q] = 0;
        choose[q++] = x;
        text[x++] =
            "Question 2: Problem gambling is only a problem if the gambler \ncan't afford it.   (T): True or (F): False";
        text[x++] = "Edward: How would I know? I've got more than enough savings now...";
        text[x++] = "Richard: Same here...";
        text[x++] = "Me: (These guys must be pros)";
        text[x++] = "Host: and the answer is...";
        text[x++] = "Host: False! Problem gambling doesn't only cause financial problems.";
        text[x++] = "Host: Relationship breakdowns are also prominent effects of \nproblem gambling.";
        text[x++] = "Ron: Good point, but winnings from casinos can also 'improve' \nrelationships...";
        text[x++] = "Host: Um... Anyway, next question...";
        ans[q] = "F";
        qtype[q] = 0;
        opp[q, 1] = 1;
        opp[q, 2] = 1;
        opp[q, 3] = 0;
        choose[q++] = x;
        text[x++] =
            "Question 3: If a problem gambler builds up debt, you should help him \ntake care of it.   (T): True or (F): False";
        text[x++] = "Edward: Of course you should, it is only right to help those in trouble!";
        text[x++] = "Ron: On the other hand, there is always the saying: Do not stick \nyour nose up others' business!";
        text[x++] = "Host: Well, unfortunately... the answer is False.";
        text[x++] = "Richard: Huh?";
        text[x++] = "Host: The quick fix solution looks the most homogenous. \nA homogenous solution you see, haha...";
        text[x++] = "Host: but, these will do nothing to stop their gambling impulses.";
        text[x++] = "Host: Next, ...";
        ans[q] = "F";
        qtype[q] = 0;
        opp[q, 1] = 1;
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        choose[q++] = x;
        text[x++] = "Question 4: Only irresponsible people become addicted to gambling.\n(T): True or (F): False";
        text[x++] =
            "Ron: Logically speaking, a responsible, honourable man will stop \nhimself from being addicted to gambling.";
        text[x++] = "Edward: On the contrary, many studies have shown that anyone \ncan be addicted to things.";
        text[x++] = "Richard: Very true. Especially since gambling is so thrilling.";
        text[x++] =
            "Host: Anyway, the answer is False. Of course, most of the time, \nweak-willed or irresponsible people are more likely to";
        text[x++] =
            "fall prey to problem gambling. However, remembering that problem \ngambling is an addiction, anyone can become addicted.";
        ans[q] = "T";
        opp[q, 1] = 1;
        opp[q, 2] = 1;
        opp[q, 3] = 0;
        qtype[q] = 0;
        choose[q++] = x;
        text[x++] = "Question 5: It's difficult to recognise a problem gambler.\n(T): True or (F): False";
        text[x++] =
            "Ron: I don't think so. Some of the gamblers whom I noticed had \nsuffered considerable losses stopped coming to the casino.";
        text[x++] = "I think that is quite an obvious effect of problem gambling, isn't it?";
        text[x++] =
            "Host: Well, that certainly is worth debating, but gambling addiction \nis also widely known as the hidden addiction.";
        text[x++] =
            "Host: For a fact, many gamblers themselves do not recognise the \nissue or are in self-denial. On to the next question, ...";
        ans[q] = "F";
        opp[q, 1] = 1;
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        qtype[q] = 0;
        choose[q++] = x;
        text[x++] = "Question 6: Skill is a factor in winning slot machines.\n(T): True or (F): False";
        text[x++] = "Ron: Ah! I know this one, I put my skill to good use in those days. \nI certainly made a killing!";
        text[x++] =
            "Edward: For slot machines? Hmm... Not so sure. I'll choose the option \nwith the highest perceived odds.";
        text[x++] =
            "Richard: I once read that some people make big winnings at the slot \nmachine with their exceptional eyesight and reflexes...";
        text[x++] = "Host: Well, the answer is False. In gambling, just as persistance \ndoesn't pay off over time,";
        text[x++] = "the results are entirely up to random chance. ";
        text[x++] =
            "Question 7: Suppose the chance of winning the jackpot is n%. \nIf you have 1000 consecutive losses,";
        ans[q] = "3";
        qtype[q] = 1;
        opp[q, 1] = 1;
        opp[q, 2] = 1;
        opp[q, 3] = 1;
        choose[q++] = x;
        text[x++] = "chance of winning in your next try?\n(1): >n%   (2): <n%   (3): n%   (4): Can't tell";
        text[x++] = "Ron: Well, depends on n right? The larger of (n, 100%] and [0%, n) \nwould be most likely...";
        text[x++] =
            "Edward: No, your argument is so unconvincing. I wonder if the jackpot \nmachine is genuinely random or pseudorandom?";
        text[x++] = "Host: Perhaps so, perhaps not, but whatever the case, the answer \nis (3), n%.";
        text[x++] =
            "Host: Just like how the probability of getting heads on the flip of a \ncoin is always 50% for a fair dice, ";
        text[x++] = "previous winnings or losings have no effect on upcoming ones.";
        ans[q] = "Y";
        qtype[q] = 2;
        opp[q, 1] = 1;
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        choose[q++] = x;
        text[x++] = "Question 8: Can problem gambling be treated? \n(Y): Yes    (N): No";
        text[x++] = "Richard: How can an addiction be treated? It's not an illness or \nanything...";
        text[x++] = "Ron: The statistics show it all.";
        text[x++] =
            "Edward: Of course, I heard that there are casino exclusions, but there \ncould be severe withdrawal symptomes.";
        text[x++] =
            "Host: Valid arguments of course, but the answer is Yes. Help will \nalways be given at NCPG for those who ask for it.";
        text[x++] = "It is merely a phone call away, at 1800-6-668-668.";
        ans[q] = "N";
        qtype[q] = 2;
        opp[q, 1] = Random.Range(0, 2);
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        choose[q++] = x;
        text[x++] = "Question 9: Make a good guess. Is this the last question? \n(Y): Yes   (N): No";
        text[x++] =
            "Ron: Based on experience, the last question would be question 10, if \nthis is near the end of the quiz...";
        text[x++] = "Edward: and yet we cannot exclude the possibility of a troll.";
        text[x++] = "Richard: An educated guess tells me... <Boom!> Must've been an \ninfinite loop in my system...";
        text[x++] =
            "Host: Hahaha... An absolutely hilarious question... Unfortunately for \nsome of you... the answer is No.";
        text[x++] = "Host: No further explanation needed right?";
        text[x++] =
            "Question 10: What was the first question? \n(1): You have to gamble everyday to be called a problem gambler.";
        ans[q] = "3";
        qtype[q] = 3;
        opp[q, 1] = 0;
        opp[q, 2] = 0;
        opp[q, 3] = 1;
        choose[q++] = x;
        text[x++] = "(2): Do you want to take this quiz? \n(3): None of the above.";
        text[x++] = "Edward: The questions certainly have taken a turn for the worse.";
        text[x++] = "Ron: All I know is it's about problem gambling...";
        text[x++] = "Richard: ...";
        text[x++] = "Host: and the answer is...";
        text[x++] =
            "Host: (3), none of the above! The first question is actually \n'You don't have to gamble everyday to be a problem gambler.'";
        text[x++] = "Host: That's it folks! I sincerely hope you've enjoyed youselves.";
        text[x++] =
            "Host: Above all, I hope we have all gained insights on the ever \naggravating issue of problem gambling.";
        complete = x;
    }

    public void UpdateScore()
    {
        var s = "E.T - R.H - R.M - B.B\n";
        s += string.Format("{0, -6:D}{1, -6:D}{2, -6:D}{3, -6:D}", score[3], score[1], score[2], score[0]);
        scoreboard.text = s;
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            hidden = false;
            Time.timeScale = 0;
        }
    }

    private string getChoice()
    {
        if (qtype[qIndex] == 2)
        {
            if (Input.GetKeyDown(KeyCode.Y))
                return "Y";
            if (Input.GetKeyDown(KeyCode.N))
                return "N";
        }
        if (qtype[qIndex] == 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
                return "T";
            if (Input.GetKeyDown(KeyCode.F))
                return "F";
        }
        if (qtype[qIndex] == 1 || qtype[qIndex] == 3)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                return "1";
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                return "2";
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                return "3";
            if (qtype[qIndex] == 1)
            {
                if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
                    return "4";
            }
        }
        return "";
    }

    private void Update()
    {
        if (!hidden)
        {
            if (text[index] != null)
                gt.text = text[index];
            UpdateScore();
            if (index == complete)
            {
                Time.timeScale = 1;
                scoreboard.text = "";
                hidden = true;
                index++;
                DayCounter.reduceDays();
                if (score[0] > score[1])
                    MoneyCounter.addAmt(1000);
                else if (score[0] == score[1])
                    MoneyCounter.addAmt(500);
                else
                    MoneyCounter.addAmt(100);
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
            }
            if (index == choose[qIndex])
            {
                var choice = getChoice();
                Debug.Log(choice);
                if (choice.Equals(""))
                    return;
                if (choice.Equals(ans[qIndex]))
                {
                    index++;
                    for (var i = 1; i < 4; i++)
                        score[i] += opp[qIndex, i];
                    qIndex++;
                    score[0]++;
                }
                else
                {
                    index++;
                    for (var i = 1; i < 4; i++)
                        score[i] += opp[qIndex, i];
                    qIndex++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                //index--;
            }
        }
    }
}