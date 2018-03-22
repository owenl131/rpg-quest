using UnityEngine;

public class Quest8Controller : MonoBehaviour
{
    private readonly float speed = 1f;
    private bool isDone;
    public GameObject player;
    // Use this for initialization
    private void Start()
    {
        isDone = false;
    }

    // Update is called once per frame
    private void Update()
    {
        player.GetComponent<Animator>().SetFloat("inputY", 1);
        player.GetComponent<Animator>().SetFloat("inputX", 0);
        if (player.transform.position.y < -2.53f)
        {
            player.transform.position += new Vector3(0, speed*Time.deltaTime, 0);
            player.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else
        {
            if (!isDone)
            {
                isDone = true;
                player.GetComponent<Animator>().SetBool("isWalking", false);
                GameObject.Find("Quest8Textbox").GetComponent<TextboxQuest8>().showBox();
            }
        }
    }
}