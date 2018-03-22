using UnityEngine;

public class TextboxCasino : MonoBehaviour
{
    private int count;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.22f, 0);
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        text = new string[5];
        text[0] = "Receptionist: Welcome to Juicy Stakes Casino!\nMay the odds be ever in your favour!";
    }

    public void showBox()
    {
        if (hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            gt.text = text[0];
            hidden = false;
            Time.timeScale = 0;
            count = 0;
        }
    }

    public void hideBox()
    {
        if (!hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                -20);
            gt.text = "";
            Time.timeScale = 1;
            hidden = true;
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            count++;
            if (Input.anyKeyDown && count > 10)
            {
                hideBox();
            }
        }
    }
}