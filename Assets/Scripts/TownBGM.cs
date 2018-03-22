using UnityEngine;

public class TownBGM : MonoBehaviour
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
                audio.Stop();
        }
    }

    private bool checkScene()
    {
        if (Application.loadedLevelName.Equals("Home") || Application.loadedLevelName.Equals("Town") ||
            Application.loadedLevelName.Equals("Bank") || Application.loadedLevelName.Equals("Casino") ||
            Application.loadedLevelName.Equals("Office") || Application.loadedLevelName.Equals("CounsellingCentre") ||
            Application.loadedLevelName.Equals("HomeTV") || Application.loadedLevelName.Equals("Phone") ||
            Application.loadedLevelName.Equals("4D") || Application.loadedLevelName.Equals("Computer"))
            return true;
        return false;
    }
}