using System;
using UnityEngine;
using System.Collections;

public class Quest7Controller : MonoBehaviour
{
    public GUIText gt;
    private String[] text;
    private int index;
    private int complete;
    public Font font;

	// Use this for initialization
	void Start () {
	    text = new string[20];
        gt.transform.position = new Vector3(0.05f, 0.22f, 0);
        transform.position = new Vector3(Camera.main.transform.position.x, 
            0, Camera.main.transform.position.z - 1.4f);
	    int x = 0;
	    index = 0;
	    gt.font = font;
	    gt.fontSize = 32;
        gt.color = Color.black;
	    Time.timeScale = 0;
	    text[x++] = "Me: What is this place...?";
	    text[x++] = "Boss: Greetings, you poor thing, welcome to the underworld.";
	    text[x++] = "Boss: Congratulations on frustrating me, now, \nhave a taste of my wrath!";
	    text[x++] = "Me: What happened to my life...";
	    text[x++] = "Me: (Are these stones on the ground?)";
	    text[x++] = "Player found stones. Player can now attack enemies.";
	    text[x++] = "[Instructions]";
	    text[x++] = "Click in the direction of the boss to throw a stone at him.";
	    text[x++] = "Press the spacebar when your mana bar is full to use a \nspecial attack.";
	    text[x++] = "Both attacks consume mana and whoever survives longer wins.";
	    text[x++] = "The mana bar is reduced to zero whichever attack is used, \nso plan your attacks well!";
	    text[x++] = "Good luck! May the best man win!";
	    complete = x;
	    text[x++] = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (text[index] != null)
	        gt.text = text[index];
	    if (index == complete)
	    {
	        Time.timeScale = 1;
	        gt.text = "";
	        GetComponent<SpriteRenderer>().enabled = false;
	    }
	    else if (index < complete)
	    {
	        Time.timeScale = 0;
            transform.position = new Vector3(Camera.main.transform.position.x,
                0, Camera.main.transform.position.z - 1.4f);
            if (Input.GetKeyDown(KeyCode.Space))
	            index++;
	    }

	}
}
