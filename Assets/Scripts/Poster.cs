using UnityEngine;

public class Poster : MonoBehaviour
{
    private Sprite[] glow;
    private bool isTriggered;
    private Sprite normal;
    public int posterNum;
    private bool posterShown;
    private SpriteRenderer sr;
    // Use this for initialization
    private void Start()
    {
        glow = new Sprite[6];
        glow[0] = Resources.Load("Poster 1 (In Game) Glow", typeof (Sprite)) as Sprite;
        glow[1] = Resources.Load("Poster 2 (In Game) Glow", typeof (Sprite)) as Sprite;
        glow[2] = Resources.Load("Poster 3 (In Game) Glow", typeof (Sprite)) as Sprite;
        glow[3] = Resources.Load("Poster 4 (In Game) Glow", typeof (Sprite)) as Sprite;
        glow[4] = Resources.Load("Poster 5 (In Game) Glow", typeof (Sprite)) as Sprite;
        glow[5] = Resources.Load("Poster 6 (In Game) Glow", typeof (Sprite)) as Sprite;
        isTriggered = false;
        posterShown = false;
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            Debug.Log("Triggered");
        }
    }

    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            Debug.Log ("Still in");
        }
    }
    */

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTriggered = false;
            Debug.Log("Out");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered)
        {
            sr.sprite = glow[posterNum - 1];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var poster = GameObject.Find("Poster " + posterNum).transform;
                poster.position = Camera.main.transform.position + new Vector3(0, 0, 10f);
                Time.timeScale = 0;
                posterShown = true;
            }
            else if (Input.anyKeyDown)
            {
                var poster = GameObject.Find("Poster " + posterNum).transform;
                poster.position = new Vector3(0, 0, -20f);
                posterShown = false;
                Debug.Log("closed");
                Time.timeScale = 1;
            }
        }
        else
        {
            sr.sprite = normal;
        }
    }
}