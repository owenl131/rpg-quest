using UnityEngine;

public class SleepSystem : MonoBehaviour
{
    public Transform text;
    private bool triggered;
    // Use this for initialization
    private void Start()
    {
        triggered = false;
    }

    private void Update()
    {
        if (triggered)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                DayCounter.reduceDays();
                Time.timeScale = 1;
                text.position = new Vector3(text.position.x, text.position.y, -20);
                GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Sleep");
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Time.timeScale = 1;
                text.position = new Vector3(text.position.x, text.position.y, -20);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0;
            text.position = Camera.main.transform.position + new Vector3(0, -1.5f, 10);
            triggered = true;
        }
    }
}