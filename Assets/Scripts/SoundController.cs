using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	private GameObject[] objects;
	private SpriteRenderer sr;
	private Sprite off;
	private Sprite on;
	private bool isPlaying;
	// Use this for initialization
	void Start () {
		isPlaying = true;
		sr = GetComponent<SpriteRenderer>();
		on = sr.sprite;
		off = Resources.Load("SoundOff", typeof (Sprite)) as Sprite;
	}

	void OnMouseDown(){
		Debug.Log("In here");
		if (isPlaying) {
		    AudioListener.volume = 0;
		    AudioListener.pause = true;
			isPlaying = false;
			sr.sprite = off;
		} else {
		    AudioListener.volume = 1;
		    AudioListener.pause = false;
			sr.sprite = on;
			isPlaying = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
