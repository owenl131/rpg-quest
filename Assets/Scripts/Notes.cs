using UnityEngine;

public class Notes : MonoBehaviour
{
    public static int storyMode;
    public static int index;
    public Camera cameraMain;
    public Camera cameraNote;
    public GUIText gt;
    private bool isTriggered;
    public string[,] story;
    // Use this for initialization
    private void Start()
    {
        storyMode = TextBox1.choice1 - 1;
        story = new string[3, 9];
        cameraNote.gameObject.SetActive(false);
        story[0, 0] = "";
        story[0, 1] =
            "From young, my friends\nand I have been playing\npoker and were betting\nwith small amounts… 10\ncents, 20 cents… but it got\nlarger and larger…";
        story[0, 2] = "";
        story[0, 3] =
            "It became boring playing\namong ourselves with small\namounts, so we went to\ngambling dens and\ncasinos…";
        story[0, 4] = "";
        story[0, 5] =
            "Sometimes, we won a little\nprize money but \neventually we ended up losing\nmore. But with the feeling\nthat my luck might change\nwith the next hand, I\ncould never stop…";
        story[0, 6] = "";
        story[0, 7] =
            "I approached loan sharks\nfor money and rumors\nspread about them coming\nto my doorstep… Now, I\nneed to get out of this\ndebt…";
        story[0, 8] = "";

        story[1, 0] = "";
        story[1, 1] =
            "I had a decent income,\nworking at the same\ncompany for many years \nnow. But…  I have never\nreceived a promotion since\nthen, nonetheless, I’ve\nnever complained.";
        story[1, 2] = "";
        story[1, 3] =
            "During the years of\neconomic crisis, the\ncompany had a sudden\nretrenchment, and I lost\nmy job. The years of\nservice I had provided was\nunappreciated, all lost.";
        story[1, 4] = "";
        story[1, 5] =
            "Unable to find another job,\nI soon had little money left.\nFeeling angry and\ndesperate, I gave gambling\na shot in hopes of earning\nsome quick cash.";
        story[1, 6] = "";
        story[1, 7] =
            "But... I went on a losing\nstreak and lost all my\nsavings, bank loans,\neverything in my\npossessions… In the end, I\nhad no choice but to go to\nthe Ah Longs...";
        story[1, 8] = "";

        story[2, 0] = "";
        story[2, 1] =
            "I woke up at the hospital,\nhaving no memories of my\npast. A man who said he’s\nmy friend told me that I\ntried to commit suicide,\nbut failed and ended\nup suffering from amnesia\ndue to brain damage…";
        story[2, 2] = "";
        story[2, 3] =
            "I went back home and\nfound pictures of what I\nthink is my family… But\nsomehow, I only feel a\nstinging pain in my heart\nwhen I look at them.";
        story[2, 4] = "";
        story[2, 5] =
            "My friend told me that my\nfather died when I was\nborn and my mother got\ninto gambling and\nborrowed money from the\nloan sharks. Eventually, she\ncouldn’t pay up and sold\nme to the loan sharks.";
        story[2, 6] = "";
        story[2, 7] =
            "After working a few years\nwith them, I couldn’t stand\nhow ugly the job is and\nattempted suicide… Now,\nthe loan sharks are coming\nback for the debts I’m\nsupposed to pay.";
        story[2, 8] = "";

        gt.text = story[storyMode, index];
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (Input.anyKeyDown)
            {
                cameraNote.gameObject.SetActive(false);
                cameraMain.gameObject.SetActive(true);
                Time.timeScale = 1;
                index++;
                update();
                isTriggered = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            index++;
            update();
            Time.timeScale = 0;
            isTriggered = true;
            cameraMain.gameObject.SetActive(false);
            cameraNote.gameObject.SetActive(true);
        }
    }

    private void update()
    {
        gt.GetComponent<GUIText>().text = story[storyMode, index];
    }
}