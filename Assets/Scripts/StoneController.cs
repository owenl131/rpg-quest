using UnityEngine;

public class StoneController : MonoBehaviour
{
    private int timer;
    // Use this for initialization
    private void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        timer++;
        if (timer > 100)
        {
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(transform.gameObject);
            GameObject.Find("HealthBar").GetComponent<HealthBar>().reduceHealth();
        }
    }
}