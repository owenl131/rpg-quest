using UnityEngine;
using System.Collections;

public class MumNPC : MonoBehaviour {
	private bool isTriggered;
	private bool spoken;
	private SpriteRenderer sr;
	private Sprite turn;
	private Sprite normal;
	public Transform text;
	public GUIText gt;
	private string[] conversation;
	// Use this for initialization
	void Start () {
		spoken = false;
		sr = GetComponent<SpriteRenderer>();
		normal = sr.sprite;
		turn = Resources.Load("Mum front view", typeof (Sprite)) as Sprite;
		gt.text = "";
		conversation = new string[10];
		conversation [9] = "Son, are you going for work now? Do take care of yourself well.\nYou'll be back for dinner right?";
		conversation [8] = "Son, are you going for work now? I hope they are not driving you too \nhard.";
		conversation [7] = "Son, have you finished your meals? Look after your health well!";
		conversation [6] = "Son, how are you feeling today? Don't hesitate to tell me if you need \nanything.";
		conversation [5] = "Son, are you going for work already? Will you be back early today? \nIt's been a while since we went out together.";
		conversation [4] = "Son, I found small tears in your clothes. Are you getting along well \nwith your friends, clients and colleagues?";
		conversation [3] = "Son, you look flustered today. Is there anything bothering you?";
		conversation [2] = "Son, how are the finances? I took a look at the bills yesterday. \nTell me if you need help.";
		conversation [1] = "Son, some guys came over yesterday. They looked rather menacing \nso I did not open the door...";
		conversation [0] = "Son, I'm scared, the guys have sticks and stones and paint, I don't \ndare to step out of the house.";
        //give the impression that mom does not really understand the situation fully
        //player hiding things from mom
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			isTriggered = true;
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            isTriggered = false;
    }

	// Update is called once per frame
	void Update () {
		if (isTriggered && Input.GetKeyDown(KeyCode.Space)) {
			Time.timeScale = 0;
			sr.sprite = turn;
			text.position = Camera.main.transform.position + new Vector3 (0, -1.5f, 10);
			gt.text = conversation [DayCounter.getDays() - 1];
			spoken = true;
		}
		else if (spoken && Input.anyKeyDown){
			Time.timeScale = 1;
			sr.sprite = normal;
			gt.text = "";
			text.position = Camera.main.transform.position + new Vector3 (0, 0, -10);
			spoken = false;
		}
	}
}
