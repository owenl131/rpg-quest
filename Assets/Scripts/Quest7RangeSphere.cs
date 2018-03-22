using UnityEngine;

public class Quest7RangeSphere : MonoBehaviour
{
    public GameObject player;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "stone")
        {
            Destroy(other.gameObject);
        }
    }
}