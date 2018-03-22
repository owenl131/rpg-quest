using System.Collections.Generic;
using UnityEngine;

public class PhoneIcon : MonoBehaviour
{
    private GUITexture gt;
    public Texture mouseOver;
    private Texture normal;
    private int prevLevel;
    private Vector3 prevLoc;
    private List<string> prevName;
    private List<Vector3> prevPos;
    private Rect r;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        gt = GetComponent<GUITexture>();
        normal = gt.texture;
        var height = Screen.height*transform.localScale.y;
        var width = Screen.width*transform.localScale.x;
        var pos = Camera.main.ViewportToScreenPoint(transform.position);
        Debug.Log(width + "," + height);
        r = new Rect(pos.x - width/2, pos.y - height/2, width, height);
        prevName = new List<string>();
        prevPos = new List<Vector3>();
    }

    // Update is called once per frame
    private void Update()
    {
        var ll = LevelTrack.indexToString(Application.loadedLevel);
        if (ll.Equals("StartPage") || ll.Equals("Menu") || ll.Equals("Credits") || ll.Equals("Introduction") ||
            ll.Equals("Instructions_1") || ll.Equals("Instructions_2") || ll.Equals("Instructions_3") ||
            ll.Equals("Instructions_4") || ll.Equals("Instructions_5") || ll.Equals("4D") ||
            ll.Equals("CounsellingCentre") || ll.Equals("Sleep") ||
            ll.Equals("EndGame") || ll.Equals("Computer") || ll.Equals("Phone") || ll.Equals("Quest5") ||
            ll.Equals("FailQuest") || ll.Equals("ExitQuest") || ll.Equals("HomeTV") || ll.Equals("CompleteQuest") ||
            ll.Equals("Quest10") || ll.Equals("Quest7BossBattle") ||
            ll.Equals("Instructions_6") || ll.Equals("Instructions_7") || ll.Equals("Instructions_8") ||
            ll.Equals("slotmachine"))
        {
            gt.enabled = false;
        }
        else
        {
            gt.enabled = true;
        }
        if (gt.enabled && r.Contains(Input.mousePosition))
        {
            gt.texture = mouseOver;
            if (Input.GetMouseButtonDown(0))
            {
                //prevLoc = GameObject.FindGameObjectWithTag("Player").transform.position;
                //Debug.Log(prevLoc.ToString("G4"));
                prevName.Clear();
                prevPos.Clear();
                var g = FindObjectsOfType<GameObject>();
                for (var i = 0; i < g.Length; i++)
                {
                    prevName.Add(g[i].gameObject.name);
                    prevPos.Add(g[i].transform.position);
                }
                prevLevel = Application.loadedLevel;
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Phone");
            }
        }
        else if (gt.enabled)
        {
            gt.texture = normal;
        }
    }

    public List<string> getPrevName()
    {
        return prevName;
    }

    public List<Vector3> getPrevPos()
    {
        return prevPos;
    }

    public Vector3 getPrevLoc()
    {
        return prevLoc;
    }

    public int getPrevLevel()
    {
        return prevLevel;
    }
}