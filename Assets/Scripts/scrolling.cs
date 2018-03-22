using UnityEngine;

public class scrolling : MonoBehaviour
{
    public static int timestop;
    public static float pos1, pos2;
    private bool check = true, check2 = true;
    public int choice;
    public GameObject go;
    public int reelSpeed = 100, time;
    //1=-2.29f, 2=0, 3=2.24
    // Use this for initialization
    private void Start()
    {
        reelSpeed = 0;
        timestop = 0;
        time = 0;
        if (choice == 1)
            go.transform.position = new Vector3(-2.7f, -5.92f);
        if (choice == 2)
            go.transform.position = new Vector3(-2.7f, -23.76f);
        pos1 = -5.92f;
        pos2 = -23.76f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (check && choice == 1)
        {
            timestop = Random.Range(50, 101);
            check = false;
        }
        if (choice == 1)
            pos1 = go.transform.position.y;
        if (choice == 2)
            pos2 = go.transform.position.y;
        Spin();
        if (reelSpeed != 0 && time > timestop)
            reelSpeed--;
        if (reelSpeed == 0 && check2)
        {
            if ((int)Mathf.Round(go.transform.position.y)%2 == 0)
            {
                reelSpeed = 0;
                check2 = false;
                go.transform.position = new Vector3(go.transform.position.x, Mathf.Round(go.transform.position.y));
            }
        }
        if (reelSpeed == 0)
        {
            if ((int)Mathf.Round(go.transform.position.y)%2 == 0)
                go.transform.position = new Vector3(go.transform.position.x, Mathf.Round(go.transform.position.y));
            else
                go.transform.position = new Vector3(go.transform.position.x, Mathf.Round(go.transform.position.y - 1));
        }
        if (choice == 2)
        {
            if ((int)pos1 == -8 && (int)go.transform.position.y == 12)
                go.transform.position = new Vector3(go.transform.position.x, 10);
            if ((int)pos1 == -12 && (int)go.transform.position.y == 8)
                go.transform.position = new Vector3(go.transform.position.x, 6);
            if ((int)pos1 == 10 && go.transform.position.y == -6)
                go.transform.position = new Vector3(go.transform.position.x, -8);
            if (pos1 == 8 && go.transform.position.y == -8)
                go.transform.position = new Vector3(go.transform.position.x, -10);
            if (pos1 == 6 && go.transform.position.y == -10)
                go.transform.position = new Vector3(go.transform.position.x, -12);
        }
        if (choice == 1)
        {
            if (pos2 == -8 && go.transform.position.y == 12)
                go.transform.position = new Vector3(go.transform.position.x, 10);
            if (pos2 == -12 && go.transform.position.y == 8)
                go.transform.position = new Vector3(go.transform.position.x, 6);
            if (pos2 == 10 && go.transform.position.y == -6)
                go.transform.position = new Vector3(go.transform.position.x, -8);
            if (pos2 == 8 && go.transform.position.y == -8)
                go.transform.position = new Vector3(go.transform.position.x, -10);
            if (pos2 == 6 && go.transform.position.y == -10)
                go.transform.position = new Vector3(go.transform.position.x, -12);
        }
        time++;
        if (((pos1 == -6 || pos2 == -6) && (scrolling2.pos1 == 4 || scrolling2.pos2 == 4) &&
             (scrolling3.pos1 == 4 || scrolling3.pos2 == 4))
            ||
            ((pos1 == -8 || pos2 == -8) && (scrolling2.pos1 == 2 || scrolling2.pos2 == 2) &&
             (scrolling3.pos1 == 2 || scrolling3.pos2 == 2))
            ||
            ((pos1 == -10 || pos2 == -10) && (scrolling2.pos1 == 0 || scrolling2.pos2 == 0) &&
             (scrolling3.pos1 == 0 || scrolling3.pos2 == 0))
            )
            MoneyCounter.addAmt(150);

        if (((pos1 == -6 || pos2 == -6) && (scrolling2.pos1 == -6 || scrolling2.pos2 == -6) &&
             (scrolling3.pos1 == -2 || scrolling3.pos2 == -2))
            ||
            ((pos1 == -8 || pos2 == -8) && (scrolling2.pos1 == -8 || scrolling2.pos2 == -8) &&
             (scrolling3.pos1 == -4 || scrolling3.pos2 == -4))
            ||
            ((pos1 == -4 || pos2 == -4) && (scrolling2.pos1 == -4 || scrolling2.pos2 == -4) &&
             (scrolling3.pos1 == 0 || scrolling3.pos2 == 0))
            )
            MoneyCounter.addAmt(200);
        if (((pos1 == -2 || pos2 == -2) && (scrolling2.pos1 == 6 || scrolling2.pos2 == 6) &&
             (scrolling3.pos1 == 2 || scrolling3.pos2 == 2))
            ||
            ((pos1 == -4 || pos2 == -4) && (scrolling2.pos1 == 4 || scrolling2.pos2 == 4) &&
             (scrolling3.pos1 == 0 || scrolling3.pos2 == 0))
            ||
            ((pos1 == -6 || pos2 == -6) && (scrolling2.pos1 == 2 || scrolling2.pos2 == 2) &&
             (scrolling3.pos1 == -2 || scrolling3.pos2 == -2))
            )
            MoneyCounter.addAmt(500);
        if (((pos1 == 0 || pos2 == 0) && (scrolling2.pos1 == 8 || scrolling2.pos2 == 8) &&
             (scrolling3.pos1 == -6 || scrolling3.pos2 == -6))
            ||
            ((pos1 == -2 || pos2 == -2) && (scrolling2.pos1 == 6 || scrolling2.pos2 == 6) &&
             (scrolling3.pos1 == -8 || scrolling3.pos2 == -8))
            ||
            ((pos1 == -4 || pos2 == -4) && (scrolling2.pos1 == 4 || scrolling2.pos2 == 4) &&
             (scrolling3.pos1 == -10 || scrolling3.pos2 == -10))
            )
            MoneyCounter.addAmt(250);
        if (((pos1 == 2 || pos2 == 2) && (scrolling2.pos1 == 2 || scrolling2.pos2 == 2) &&
             (scrolling3.pos1 == 6 || scrolling3.pos2 == 6))
            ||
            ((pos1 == 0 || pos2 == 0) && (scrolling2.pos1 == 0 || scrolling2.pos2 == 0) &&
             (scrolling3.pos1 == 4 || scrolling3.pos2 == 4))
            ||
            ((pos1 == -2 || pos2 == -2) && (scrolling2.pos1 == -2 || scrolling2.pos2 == -2) &&
             (scrolling3.pos1 == 2 || scrolling3.pos2 == 2))
            )
            MoneyCounter.addAmt(3000);
        if (((pos1 == 4 || pos2 == 4) && (scrolling2.pos1 == -6 || scrolling2.pos2 == -6) &&
             (scrolling3.pos1 == 8 || scrolling3.pos2 == 8))
            ||
            ((pos1 == 2 || pos2 == 2) && (scrolling2.pos1 == -8 || scrolling2.pos2 == -8) &&
             (scrolling3.pos1 == 6 || scrolling3.pos2 == 6))
            ||
            ((pos1 == 0 || pos2 == 0) && (scrolling2.pos1 == -10 || scrolling2.pos2 == -10) &&
             (scrolling3.pos1 == 4 || scrolling3.pos2 == 4))
            )
            MoneyCounter.addAmt(350);
        if (((pos1 == 6 || pos2 == 6) && (scrolling2.pos1 == -2 || scrolling2.pos2 == -2) &&
             (scrolling3.pos1 == -2 || scrolling3.pos2 == -2))
            ||
            ((pos1 == 4 || pos2 == 4) && (scrolling2.pos1 == -4 || scrolling2.pos2 == -4) &&
             (scrolling3.pos1 == -4 || scrolling3.pos2 == -4))
            ||
            ((pos1 == 2 || pos2 == 2) && (scrolling2.pos1 == -6 || scrolling2.pos2 == -6) &&
             (scrolling3.pos1 == -6 || scrolling3.pos2 == -6))
            )
            MoneyCounter.addAmt(400);
        if (((pos1 == 8 || pos2 == 8) && (scrolling2.pos1 == 0 || scrolling2.pos2 == 0) &&
             (scrolling3.pos1 == -4 || scrolling3.pos2 == -4))
            ||
            ((pos1 == 6 || pos2 == 6) && (scrolling2.pos1 == -2 || scrolling2.pos2 == -2) &&
             (scrolling3.pos1 == -6 || scrolling3.pos2 == -6))
            ||
            ((pos1 == 4 || pos2 == 4) && (scrolling2.pos1 == -4 || scrolling2.pos2 == -4) &&
             (scrolling3.pos1 == -8 || scrolling3.pos2 == -8))
            )
            MoneyCounter.addAmt(1000);
        if (((pos1 == 10 || pos2 == 10) && (scrolling2.pos1 == 10 || scrolling2.pos2 == 10) &&
             (scrolling3.pos1 == 10 || scrolling3.pos2 == 10))
            ||
            ((pos1 == 8 || pos2 == 8) && (scrolling2.pos1 == 8 || scrolling2.pos2 == 8) &&
             (scrolling3.pos1 == 8 || scrolling3.pos2 == 8))
            ||
            ((pos1 == 6 || pos2 == 6) && (scrolling2.pos1 == 6 || scrolling2.pos2 == 6) &&
             (scrolling3.pos1 == 6 || scrolling3.pos2 == 6))
            )
            MoneyCounter.addAmt(450);
    }

    private void Spin()
    {
        var currentReelSpeed = reelSpeed*Time.deltaTime;
        go.transform.Translate(Vector3.up*currentReelSpeed);
        //go.transform.Translate (Vector3.up * Time.deltaTime);
        if (go.transform.position.y >= 11.8 && choice == 1)
            go.transform.position = new Vector3(go.transform.position.x, pos2 - 17f);
        if (go.transform.position.y >= 23.4 && choice == 2)
            go.transform.position = new Vector3(go.transform.position.x, pos1 - 17f);
        //-23.76f
    }

    public void leverPulled()
    {
        reelSpeed = 100;
        check = true;
        time = 0;
    }
}