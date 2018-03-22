using UnityEngine;

public class BasicCameraFollow : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -10), 0.1f);
    }
}