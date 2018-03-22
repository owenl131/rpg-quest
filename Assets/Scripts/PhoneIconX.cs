using UnityEngine;

public class PhoneIconX : MonoBehaviour
{
    private float horizontalSize;
    private bool isOver;
    private Sprite mouseOver;
    private Sprite normal;
    private int prevLevel;
    private Vector3 prevLoc;
    //private Rect r;
    private SpriteRenderer sr;
    private float verticalSize;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
        mouseOver = Resources.Load("iPhoneSprite2", typeof (Sprite)) as Sprite;
        isOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //Physics.IgnoreCollision(GetComponent<Collider>(), GameObject.FindWithTag("Player").GetComponent<Collider>());
        //var size = GetComponent<Renderer>().bounds.size;
        //var position = transform.position;

        var ll = LevelTrack.indexToString(Application.loadedLevel);
        if (ll.Equals("StartPage") || ll.Equals("Menu") || ll.Equals("Credits") || ll.Equals("Introduction") ||
            ll.Equals("Instructions_1") || ll.Equals("Instructions_2") || ll.Equals("Instructions_3") ||
            ll.Equals("Instructions_4") || ll.Equals("Instructions_5") || ll.Equals("4D") ||
            ll.Equals("CounsellingCentre") || ll.Equals("Sleep") ||
            ll.Equals("EndGame") || ll.Equals("Computer") || ll.Equals("Phone") || ll.Equals("Quest5") ||
            ll.Equals("FailQuest") || ll.Equals("ExitQuest") || ll.Equals("HomeTV") || ll.Equals("CompleteQuest"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Camera.main != null)
        {
            if (ll.Equals("Forest3D") || ll.Equals("Dungeon") || ll.Equals("Quest7BossBattle"))
            {
                transform.eulerAngles = new Vector3(90, 0, 0);
                verticalSize = Camera.main.orthographicSize*2.0f;
                horizontalSize = verticalSize*Screen.width/Screen.height;
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3((0.93f*horizontalSize) - horizontalSize/2 + Camera.main.transform.position.x, 0,
                        (0.39f*verticalSize) - verticalSize/2 + Camera.main.transform.position.z), 0.1f);
                //r = new Rect(position.x - size.x/2, position.z - size.y/2, size.x, size.y);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                verticalSize = Camera.main.orthographicSize*2.0f;
                horizontalSize = verticalSize*Screen.width/Screen.height;
                transform.position = Vector3.Lerp(transform.position,
                    new Vector3((0.93f*horizontalSize) - horizontalSize/2 + Camera.main.transform.position.x,
                        (0.39f*verticalSize) - verticalSize/2 + Camera.main.transform.position.y, 0), 0.1f);
                //r = new Rect(position.x - size.x / 2, position.y - size.y / 2, size.x, size.y);
            }
            /*if (Input.GetMouseButtonDown(0) && GetComponent<SpriteRenderer>().enabled)
            {
                if (r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    prevLoc = GameObject.FindGameObjectWithTag("Player").transform.position;

                    Debug.Log(prevLoc.ToString("G4"));
                    prevLevel = Application.loadedLevel;
                    GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Phone");
                }
            }
            if (!isOver && r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                isOver = true;
                sr.sprite = mouseOver;
            }
            if (isOver && !r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                isOver = false;
                sr.sprite = normal;
            }*/
        }
    }

    private void OnMouseOver()
    {
        sr.sprite = mouseOver;
    }

    private void OnMouseExit()
    {
        sr.sprite = normal;
    }

    private void OnMouseDown()
    {
        if (!sr.enabled)
            return;
        sr.sprite = normal;
        prevLoc = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log(prevLoc.ToString("G4"));
        prevLevel = Application.loadedLevel;
        GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Phone");
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