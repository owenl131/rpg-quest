using UnityEngine;

public class TextboxQuest10 : MonoBehaviour
{
    private int complete;
    private bool done;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.05f, 0.22f, 0);
        text = new string[100];
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        index = 0;
        var x = 0;
        text[x++] = "Mr CIP: Ah, you're here. Follow me, I've gathered a few gamblers \nin another room.";
        text[x++] = "...";
        complete = x;
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            hidden = false;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            if (text[index] != null)
                gt.text = text[index];
            if (Input.GetKeyDown(KeyCode.Space))
            {
                index++;
            }
            else if (index == complete && !done)
            {
                Time.timeScale = 1;
                done = true;
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Quest10");
            }
        }
    }
}