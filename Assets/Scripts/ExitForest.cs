using UnityEngine;

public class ExitForest : MonoBehaviour
{
    private bool isTriggered;
    public Transform textbox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTriggered = true;
            textbox.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z - 1.4f);
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                var percentLoss = 5;
                Time.timeScale = 1;
                MoneyCounter.reducePercentage(percentLoss);
                DayCounter.reduceDays();
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("ExitQuest");
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                Time.timeScale = 1;
                textbox.position = new Vector3(textbox.position.x, 20, textbox.position.z);
                isTriggered = false;
            }
        }
    }
}