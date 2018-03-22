using UnityEngine;

public class EndQuest : MonoBehaviour
{
    private int count;
    // Use this for initialization
    private void Start()
    {
        count = 0;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().hide();
    }

    // Update is called once per frame
    private void Update()
    {
        count++;
        if (Input.anyKeyDown && count > 20)
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Home");
    }
}