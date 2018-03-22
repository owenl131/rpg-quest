using UnityEngine;

public class WinningNumber : MonoBehaviour
{
    public static string winningnum;
    private static string blank;
    private static bool hide;
    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        blank = "";
        winningnum = Random.Range(0, 10) + "      " + Random.Range(0, 10) + "      " + Random.Range(0, 10) + "      " +
                     Random.Range(0, 10);
    }


    public void reset()
    {
        blank = "";
        winningnum = Random.Range(0, 10) + "      " + Random.Range(0, 10) + "      " + Random.Range(0, 10) + "      " +
                     Random.Range(0, 10);
    }
    

    public static void generateNum()
    {
        winningnum = Random.Range(0, 10) + " " + Random.Range(0, 10) + " " + Random.Range(0, 10) + " " +
                     Random.Range(0, 10);
    }
}