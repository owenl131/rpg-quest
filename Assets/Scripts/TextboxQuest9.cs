using UnityEngine;

public class TextboxQuest9 : MonoBehaviour
{
    private int complete;
    private bool done;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    public GameObject player;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.05f, 0.22f, 0);
        text = new string[100];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        done = false;
        index = 0;
        var x = 0;
        text[x++] =
            "Mr Shade: Phew, thank goodness you're here...\nI was worried that I may have needed to spend the night here.";
        text[x++] = "Me: What are you doing in this horrible place, in any case?";
        text[x++] = "Mr Shade: Well, since I owe you a favour, I guess I also \nowe an explanation...";
        text[x++] =
            "Mr Shade: You see, my family is in deep need of money. We have \nnot reached the point of being in debt,";
        text[x++] = "Mr Shade: but we are already finding it difficult to pay our regular \nexpenses.";
        text[x++] = "Mr Shade: You would probably have guessed, this is all a \nconsequence of problem gambling.";
        text[x++] =
            "Mr Shade: This kind soul approached me with a \nsweet deal, a stroke of luck, come to think of it,";
        text[x++] =
            "and all I need to do is pass a packet of powder, I think it's a chemical \nfor a chemistry experiment,";
        text[x++] = "to this man when the request comes in.";
        text[x++] = "Me: Sounds suspicious...";
        text[x++] = "Mr Shade: Really? The pay is generous and workload is never too \nheavy.";
        text[x++] = "Me: I mean the powder could be anything! Baby powder, chemicals, \nmedicines or... drugs.";
        text[x++] = "Mr Shades: Huh? I never thought of that!";
        text[x++] =
            "Me: Well, I'm not in a position to give you any good advice, but there \nare many resources and help available.";
        text[x++] = "Me: MoneySense has several guides to managing your wealth, \nor lack of it.";
        text[x++] = "Me: One particularly useful one might be the one on managing \nyour resources.";
        text[x++] = "Mr Shade: That sounds promising...";
        text[x++] =
            "Me: There are also many organisations offering help. Remember \nto look for licenced ones though...";
        text[x++] = "Me: One of them is Credit Counselling Singapore, in short, CCS. ";
        text[x++] =
            "Me: CCS is a non-profit organisation which assists debt \ndistressed individuals with credit counselling,";
        text[x++] = "provides education on financial management and equips people with \ncredit management skills.";
        text[x++] = "Me: Oh, and last of all, try as much as possible to keep to honest \nmeans in repaying your debt.";
        text[x++] = "Mr Shade: Well then, we should hurry back, it's getting late.";

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            else if (index == complete && !done)
            {
                Time.timeScale = 1;
                done = true;
                MoneyCounter.addAmt(1000);
                DayCounter.reduceDays();
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
            }
        }
    }
}