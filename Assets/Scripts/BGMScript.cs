using System;
using UnityEngine;
using System.Collections;

public class BGMScript : MonoBehaviour
{

    public String[] levels;
    private AudioSource audio;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


	// Use this for initialization
	void Start ()
	{
	    audio = GetComponent<AudioSource>();
	    audio.loop = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    bool isPlaying = audio.isPlaying;
        bool isLevel = false;
	    for (int i = 0; i < levels.Length; i++)
	    {
	        if (Application.loadedLevelName.Equals(levels[i]))
	            isLevel = true;
	    }
	    if (isLevel && !isPlaying)
	    {
	        audio.Play();
	    }
        else if (!isLevel && isPlaying)
        {
            audio.Stop();
        }
	}
}
