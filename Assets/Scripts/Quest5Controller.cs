using UnityEngine;

public class Quest5Controller : MonoBehaviour
{
    private readonly int total = 30;
    public GameObject[] bins;
    public Font change;
    private int count;
    private int count2;
    private float dir;
    private int[] indices;
    private int section;
    private float speed;
    private float[] xpos;
    private float[] ypos;

    private void Start()
    {
        section = 0;
        count = 0;
        count2 = 0;
        speed = 0.05f;
        dir = 1;
        xpos = new[] {-2.5f, -1.25f, 0f, 1.25f, 2.5f};
        ypos = new[] {-0.5f, -1.5f, -0.5f, -1.5f, -0.5f};
        bins = new GameObject[5];
        for (var i = 0; i < 5; i++)
        {
            bins[i] = GameObject.Find("Bin (" + i + ")");
        }
        indices = new[] {0, 1, 2, 3, 4};
    }

    private void Update()
    {
        if (section == 0)
        {
            if (Input.anyKeyDown)
            {
                Destroy(GameObject.Find("Bag"));
                GetComponent<GUIText>().text = "";
                section++;
                for (var i = 0; i < 5; i++)
                    Debug.Log(bins[i]);
            }
        }
        else if (section == 1)
        {
            for (var i = 0; i < 5; i++)
            {
                bins[i].transform.position = Vector3.MoveTowards(bins[i].transform.position,
                    new Vector3(xpos[indices[i]], ypos[indices[i]], 0), speed);
            }
            if (reachedLoc())
            {
                section = 2;
                count++;
            }
        }
        else if (section == 2)
        {
            Debug.Log(speed);
            speed += dir*0.02f;
            if (speed > 0.32f && dir > 0)
                dir = -dir;
            if (speed < 0.20f && dir < 0)
                dir = -dir;
            if (count >= total)
                section = 3;
            else
            {
                shuffle();
                section = 4;
            }
        }
        else if (section == 3)
        {
            for (var i = 0; i < 5; i++)
            {
                bins[i].GetComponent<Quest5Bins>().setCheck(this, true);
            }
            section = 5;
        }
        else if (section == 4)
        {
            count2++;
            if (count2 > 20)
            {
                count2 = 0;
                section = 1;
            }
        }
    }

    public void selectionMade(string name)
    {
        for (var i = 0; i < 5; i++)
        {
            bins[i].GetComponent<Quest5Bins>().setCheck(this, false);
        }
        if (name.Equals("Bin (2)"))
        {
            var gt = GetComponent<GUIText>();
            gt.font = change;
            gt.fontSize = 40;
            gt.color = Color.white;
            gt.text = "Thanks for \nyour help!";
            MoneyCounter.addAmt(1500);
            DayCounter.reduceDays();
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
        }
        else
        {
            Debug.Log(name);
            var gt = GetComponent<GUIText>();
            gt.font = change;
            gt.fontSize = 40;
            gt.color = Color.white;
            gt.text = "You were caught \nand attacked \nby an Ah Long...";
            MoneyCounter.reduceAmt(200);
            DayCounter.reduceDays();
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("FailQuest");
        }
    }

    private bool reachedLoc()
    {
        for (var i = 0; i < 5; i++)
        {
            if (!(Mathf.Abs(bins[i].transform.position.x - xpos[indices[i]]) < 0.001f &&
                  Mathf.Abs(bins[i].transform.position.y - ypos[indices[i]]) < 0.001f))
                return false;
        }
        return true;
    }

    public void shuffle()
    {
        for (var i = 0; i < 50; i++)
        {
            var a = Random.Range(0, 5);
            var b = Random.Range(0, 5);
            var temp = indices[a];
            indices[a] = indices[b];
            indices[b] = temp;
        }
    }
}