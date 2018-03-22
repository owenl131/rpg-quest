using UnityEngine;
using System.Collections;

public class MultipleQuests : MonoBehaviour
{

    private bool hidden;

	// Use this for initialization
	void Start ()
	{
	    hidden = true;
	    GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (!hidden && Input.anyKeyDown)
	    {
	        GetComponent<SpriteRenderer>().enabled = false;
	    }
	}

    public void show()
    {
        hidden = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

}
