using UnityEngine;

public class OpenTV : MonoBehaviour
{
    private Sprite glow;
    private bool isTriggered;
    private Sprite normal;
    private SpriteRenderer sr;

    // Use this for initialization
    private void Start()
    {
        isTriggered = false;
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
        glow = Resources.Load("tv glow", typeof (Sprite)) as Sprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isTriggered)
        {
            sr.sprite = glow;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("HomeTV");
            }
        }
        else
            sr.sprite = normal;
    }

    private void OnTriggerStay2D(Collider2D other)
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
}