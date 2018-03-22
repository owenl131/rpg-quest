using UnityEngine;

public class GameProperties : MonoBehaviour
{
    public static int debt;
    public static int deadline;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        debt = 10000;
        deadline = 10;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}