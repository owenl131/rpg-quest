using UnityEngine;

public class CasinoNPCs : MonoBehaviour
{
    public string[] convo;
    public GUIText gt;
    private bool isTriggered;
    private Sprite normal;
    public int NPCnum;
    private bool spoken;
    private SpriteRenderer sr;
    public Transform textbox;
    public Sprite[,] turnSprites;

    // Use this for initialization
    private void Start()
    {
        isTriggered = false;
        spoken = false;
        gt.GetComponent<GUIText>().text = "";
        convo = new string[7];
        convo[0] =
            "Did you see that? That was so close! I nearly got jackpot! I'm so\ngonna get it this time... Oh, this is so exciting!";
        convo[1] = "Hey! Don't bother me! You're gonna jinx my luck!";
        convo[2] =
            "This is the last of my daughter's savings... I swear that this last try\nwill get all the money back and I'll be able to return it to her...";
        convo[3] = "My boss says that I have money management problems and fired me,\nbut I'll show him he's wrong!";
        convo[4] =
            "Gambling is all I have left... My family left me and I lost all I had... I\nhope I'll get it with the next try";
        convo[5] =
            "*#^%! Today's luck is rotten again! I already told my wife not to sweep\nthe floor and sweep my luck away! She's so gonna get it this time...";
        convo[6] =
            "Heh heh heh... Look at these foolish people burn away their money...\nHeh heh heh... Hey! Who are you? What do you want?";
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
        turnSprites = new Sprite[4, 4];
        turnSprites[0, 0] = Resources.Load("NPC Down Idle", typeof (Sprite)) as Sprite;
        turnSprites[0, 1] = Resources.Load("NPC Up Idle", typeof (Sprite)) as Sprite;
        turnSprites[0, 2] = Resources.Load("NPC Left Idle", typeof (Sprite)) as Sprite;
        turnSprites[0, 3] = Resources.Load("NPC Right Idle", typeof (Sprite)) as Sprite;
        turnSprites[1, 0] = Resources.Load("Jobless Down Idle", typeof (Sprite)) as Sprite;
        turnSprites[1, 1] = Resources.Load("Jobless Up Idle", typeof (Sprite)) as Sprite;
        turnSprites[1, 2] = Resources.Load("Jobless Left Idle", typeof (Sprite)) as Sprite;
        turnSprites[1, 3] = Resources.Load("Jobless Right Idle", typeof (Sprite)) as Sprite;
        turnSprites[2, 0] = Resources.Load("Hobo Down Idle", typeof (Sprite)) as Sprite;
        turnSprites[2, 1] = Resources.Load("Hobo Up Idle", typeof (Sprite)) as Sprite;
        turnSprites[2, 2] = Resources.Load("Hobo Left Idle", typeof (Sprite)) as Sprite;
        turnSprites[2, 3] = Resources.Load("Hobo Right Idle", typeof (Sprite)) as Sprite;
        turnSprites[3, 0] = Resources.Load("Ah long Down Idle", typeof (Sprite)) as Sprite;
        turnSprites[3, 1] = Resources.Load("Ah long Up Idle", typeof (Sprite)) as Sprite;
        turnSprites[3, 2] = Resources.Load("Ah long Left Idle", typeof (Sprite)) as Sprite;
        turnSprites[3, 3] = Resources.Load("Ah long Right Idle", typeof (Sprite)) as Sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered && Input.GetKeyDown(KeyCode.Space))
        {
            turn();
            textbox.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f, 0);
            gt.GetComponent<GUIText>().text = convo[NPCnum - 1];
            spoken = true;
            Time.timeScale = 0;
        }
        else if (spoken && Input.anyKeyDown)
        {
            textbox.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                -20f);
            gt.GetComponent<GUIText>().text = "";
            spoken = false;
            sr.sprite = normal;
            Time.timeScale = 1;
        }
    }

    private void turn()
    {
        var NPCtype = 0;
        switch (NPCnum)
        {
            case 1:
            case 2:
                NPCtype = 0;
                break;
            case 3:
            case 4:
                NPCtype = 1;
                break;
            case 5:
            case 6:
                NPCtype = 2;
                break;
            case 7:
                NPCtype = 3;
                break;
        }

        var player = GameObject.Find("Player").transform;
        var turnHorizontally = false;
        var Xdiff = transform.position.x - player.position.x;
        var Ydiff = transform.position.y - player.position.y;

        if (Mathf.Abs(Xdiff) > Mathf.Abs(Ydiff))
            turnHorizontally = true;
        else
            turnHorizontally = false;

        if (!turnHorizontally && Ydiff < 0)
            sr.sprite = turnSprites[NPCtype, 1];
        else if (!turnHorizontally && Ydiff > 0)
            sr.sprite = turnSprites[NPCtype, 0];
        else if (turnHorizontally && Xdiff > 0)
            sr.sprite = turnSprites[NPCtype, 2];
        else if (turnHorizontally && Xdiff < 0)
            sr.sprite = turnSprites[NPCtype, 3];
    }
}