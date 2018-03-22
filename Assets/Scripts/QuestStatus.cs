using UnityEngine;

public class QuestStatus : MonoBehaviour
{
    public static int questIndex = -1;
    public static int questLoc = -1; //1 for Forest, 2 for dungeon

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        questIndex = -1;
        questLoc = -1;
    }

    public static void reset()
    {
        questIndex = -1;
        questLoc = -1;
    }
}