using UnityEngine;

public class EndGameController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Camera.main.transform.position = new Vector3(8.8f, 0.1f, -10);
        if (MoneyCounter.getResult())
            GameObject.Find("Win").GetComponent<AudioSource>().Play();
        else
        {
            GameObject.Find("Lose").GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Textbox").GetComponent<TextboxBossOffice>().showBox();
        }
    }
}