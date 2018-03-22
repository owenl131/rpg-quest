using UnityEngine;

public class TextboxCC : MonoBehaviour
{
    private int count;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private string[] text;
	public GameObject textbox;
	public int index;//0 for receptionist, 1 for guy

    private void Start()
    {
        gt.transform.position = new Vector3(0.06f, 0.22f, 0);
        hidden = true;
        gt.font = f;
        gt.fontSize = 32;
        gt.color = Color.black;
        text = new string[5];
        text[0] = "Receptionist: Welcome! Contact 1800-6-668-668 if you \nneed any help or guidance!";
		text[1] = "Guy: Some people think counselling is for the weak. Counselling and \ntherapy are for those smart enough to realise they need help.";
    }
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
		{
			showBox();
		}
	}
	
    public void showBox()
    {
        if (hidden)
        {
            textbox.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            gt.text = text[index];
            hidden = false;
            Time.timeScale = 0;
            count = 0;
        }
    }

    public void hideBox()
    {
        if (!hidden)
        {
            textbox.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
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