using UnityEngine;

public class Textbox : MonoBehaviour
{
    public Font f;
    public GUIText gt;
    private bool hidden;
    public string textLine1;
    public string textLine2;
    // Use this for initialization
    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.22f, 0);
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
    }

    public void showBox()
    {
        if (hidden)
        {
            Time.timeScale = 0;
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            gt.text = textLine1 + "\n" + textLine2;
            hidden = false;
        }
    }

    public void hideBox()
    {
        if (!hidden)
        {
            Time.timeScale = 1;
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                -20);
            gt.text = "";
            hidden = true;
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            if (Input.anyKeyDown)
            {
                hideBox();
            }
        }
    }
}