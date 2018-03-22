using UnityEngine;

public class TextboxQuest5 : MonoBehaviour
{
    private int complete;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.84f, 0);
        text = new string[20];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        var x = 0;
        text[x++] = "Boy: Mornin' Sir, good day to you!";
        text[x++] =
            "Boy: I'm in kinda difficult situation... \nYou see, my Dad went somewhere he probably shouldn't 'ave...";
        text[x++] =
            "Boy: No! I mean not in that way... I mean he must'av \ngone to the cas'no cos I saw him sneaking out with 'n";
        text[x++] =
            "unusually large 'mount of cash, and when he came back \nhe was really short tempered... Took it out on us that day...";
        text[x++] = "Boy: Da next day he came home after work, with his face \nall bloody 'n all...";
        text[x++] = "Boy: 'nyways, these guys in cloaks and masks 'ave been \nmessing around with my stuff, ...";
        text[x++] =
            "Boy: Today they are going ta hide my bag in a bin behind \nschool, and in the rest of the bins they 'r ";
        text[x++] = "all sorts of dangerous stuff... Then they'll shuffle \nthe bins around da whole mornin...";
        text[x++] =
            "Boy: But anyways, they 'r rough but honourable and they \nleft me a message that if I manage to retrieve my bag, ";
        text[x++] = "Boy: They'll stop botherin' us for a while...\nSo whatcha think about givin' a helpin' hand?";
        text[x++] =
            "Boy: I reckon a little extra will 'nable my Dad to repay most \nof the debt before the interest grows.";
        text[x++] = "Me: Sure thing! Let's go...";
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
            if (index == complete)
            {
                Time.timeScale = 1;
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Quest5");
            }
        }
    }
}