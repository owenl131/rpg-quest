using UnityEngine;

public class NextButton : MonoBehaviour
{
    private bool isOver;
    private Rect r;
    // Use this for initialization
    private void Start()
    {
        var size = GetComponent<Renderer>().bounds.size;
        var position = transform.position;
        r = new Rect(position.x - size.x/2, position.y - size.y/2, size.x, size.y);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                var s = LevelTrack.indexToString(Application.loadedLevel);
                if (s.Equals("Instructions_1"))
                    Application.LoadLevel("Instructions_2");
                else if (s.Equals("Instructions_2"))
                    Application.LoadLevel("Instructions_3");
                else if (s.Equals("Instructions_3"))
                    Application.LoadLevel("Instructions_4");
                else if (s.Equals("Instructions_4"))
                    Application.LoadLevel("Instructions_5");
                else if (s.Equals("Instructions_5"))
                    Application.LoadLevel("Instructions_6");
                else if (s.Equals("Instructions_6"))
                    Application.LoadLevel("Instructions_7");
                else if (s.Equals("Instructions_7"))
                    Application.LoadLevel("Instructions_8");
                else if (s.Equals("Instructions_8"))
                    GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade(LevelTrack.prevLevel);
                else if (s.Equals("EndGame"))
                {
                    GameObject.Find("WinningNumber").GetComponent<WinningNumber>().reset();
                    GameObject.Find("Computer").GetComponent<QuestManager>().reset();
                    MoneyCounter.reset();
                    DayCounter.reset();
                    TextBoxBank.reset();
                    GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Menu");
                }
            }
        }
        if (!isOver && r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isOver = true;
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        if (isOver && !r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isOver = false;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
}