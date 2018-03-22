using UnityEngine;

public class StartingBGM : MonoBehaviour
{
    private AudioSource audio;
    private bool inCorrectScene;

    private bool isPlaying;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        inCorrectScene = checkScene();
        isPlaying = audio.isPlaying;
        if (!isPlaying)
        {
            if (inCorrectScene)
                audio.Play();
        }
        else
        {
            if (!inCorrectScene)
            {
                audio.Stop();
            }
        }
    }

    private bool checkScene()
    {
        if (Application.loadedLevelName.Equals("StartPage") || Application.loadedLevelName.Equals("Menu") ||
            Application.loadedLevelName.Equals("Credits") || Application.loadedLevelName.Equals("Instructions_1") ||
            Application.loadedLevelName.Equals("Instructions_2") || Application.loadedLevelName.Equals("Instructions_3") ||
            Application.loadedLevelName.Equals("Instructions_4") || Application.loadedLevelName.Equals("Instructions_5") ||
            Application.loadedLevelName.Equals("Introduction") || Application.loadedLevelName.Equals("Instructions_6") ||
            Application.loadedLevelName.Equals("Instructions_7") || Application.loadedLevelName.Equals("Instructions_8"))
            return true;
        return false;
    }
}