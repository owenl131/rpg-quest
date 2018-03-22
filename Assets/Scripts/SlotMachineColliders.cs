using UnityEngine;
using System.Collections;
using System.Net;

public class SlotMachineColliders : MonoBehaviour
{

    private bool isTriggered = false;
    public static Vector3 prevPos = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
	    if (isTriggered && Input.GetKeyDown(KeyCode.P))
	    {
	        prevPos = GameObject.FindWithTag("Player").transform.position;
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("slotmachine");
	    }
	}

    void OnTriggerEnter2D()
    {
        isTriggered = true;
    }

    void OnTriggerExit2D()
    {
        isTriggered = false;
    }


}
