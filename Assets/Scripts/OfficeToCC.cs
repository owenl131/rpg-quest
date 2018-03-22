using UnityEngine;

public class OfficeToCC : MonoBehaviour
{
    public int dir; //0 for to CC, 1 for to Office
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            string loc;
            if (dir == 0)
                loc = "CounsellingCentre";
            else
                loc = "Office";
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade(loc);
        }
    }
}