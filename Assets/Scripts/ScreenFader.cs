using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    private readonly float fadeSpeed = 0.02f;
    private readonly float timing = 0.0015f;
    private float alpha;
    private int check;
    private int curr; //0 for not fading, 1 for fading to black, 2 for fading to white
    private GUITexture gt;
    private bool isFading;
    private string nextLevel;

    private void Awake()
    {
        if (gt == null)
            gt = GetComponent<GUITexture>();
        DontDestroyOnLoad(transform.gameObject);
        gt.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    private void Start()
    {
        if (gt == null)
            gt = GetComponent<GUITexture>();
        isFading = false;
        curr = 0;
        alpha = 0;
        nextLevel = "";
        gt.color = new Color(0, 0, 0, alpha);
    }

    public void Update()
    {
        if (alpha > 0.5f && Time.timeScale < 0.1)
        {
            check++;
        }
        else
        {
            check = 0;
        }
        if (check > 200)
        {
            Time.timeScale = 1;
            gt.color = new Color(0, 0, 0, 0);
        }
    }

    public void fade(string level)
    {
        if (isFading)
            return;
        var s = LevelTrack.indexToString(Application.loadedLevel);
        if (!s.Equals("4D") && !s.Equals("Instructions_1") &&
            !s.Equals("Instructions_2") && !s.Equals("Instructions_3") &&
            !s.Equals("Instructions_4") && !s.Equals("Instructions_5") &&
            !s.Equals("Instructions_6") && !s.Equals("Instructions_7") &&
            !s.Equals("Instructions_8"))
            LevelTrack.prevLevel = Application.loadedLevel;
        Debug.Log("Fade called " + level);
        curr = 1;
        nextLevel = level;
        isFading = true;
        fadeToBlack();
    }

    public void fade(int level)
    {
        var s = LevelTrack.indexToString(Application.loadedLevel);
        if (!s.Equals("4D") && !s.Equals("Instructions_1") &&
            !s.Equals("Instructions_2") && !s.Equals("Instructions_3") &&
            !s.Equals("Instructions_4") && !s.Equals("Instructions_5") &&
            !s.Equals("Instructions_6") && !s.Equals("Instructions_7") &&
            !s.Equals("Instructions_8"))
            LevelTrack.prevLevel = Application.loadedLevel;
        Debug.Log("Overloaded fade called " + s);
        curr = 1;
        nextLevel = LevelTrack.indexToString(level);
        fadeToBlack();
    }

    public void fadeToBlack()
    {
        if (alpha >= 0.95f)
        {
            alpha = 1;
            gt.color = new Color(0, 0, 0, alpha);
            Debug.Log("Level loading");
            Time.timeScale = 0;
            Application.LoadLevel(nextLevel);
            fadeToClear();
            return;
        }
        alpha += fadeSpeed;
        gt.color = new Color(0, 0, 0, alpha);
        //Debug.Log("Fade to black : " + alpha);
        Invoke("fadeToBlack", timing);
    }

    public void fadeToClear()
    {
        if (alpha <= 0.05f)
        {
            alpha = 0;
            gt.color = new Color(0, 0, 0, alpha);
            Debug.Log("done fading");
            Time.timeScale = 1;
            isFading = false;
            return;
        }
        alpha -= fadeSpeed;
        gt.color = new Color(0, 0, 0, alpha);
        //Debug.Log("Fade to clear : " + alpha);
        Invoke("fadeToClear", timing);
    }
}