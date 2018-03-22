using UnityEngine;

public class BossOfficeTriggers : MonoBehaviour
{
    public GUIText gt;
    private bool isShowing;
    public Transform textbox;
    public int type; // 1 for entrance, 2 for out-of-bound areas
    // Use this for initialization
    private void Start()
    {
        isShowing = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (isShowing)
        {
            if (Input.anyKeyDown)
            {
                textbox.position = new Vector3(textbox.position.x, textbox.position.y, -20);
                gt.text = "";
                isShowing = false;
                Time.timeScale = 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (type == 1)
            {
                textbox.position = new Vector3(textbox.position.x, textbox.position.y, 0);
                gt.text = "Wait, don't leave yet. The boss has something to say to you.";
                isShowing = true;
                Time.timeScale = 0;
            }
            if (type == 2)
            {
                textbox.position = new Vector3(textbox.position.x, textbox.position.y, 0);
                gt.text = "Hey, don't stick your nose into other people's business.\nGo straight to the boss.";
                isShowing = true;
                Time.timeScale = 0;
            }
        }
    }
}