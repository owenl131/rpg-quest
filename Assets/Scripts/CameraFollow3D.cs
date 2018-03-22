using UnityEngine;

public class CameraFollow3D : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        if (!player)
            player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        //GetComponent<Camera>().orthographicSize = Screen.height/100f/4f;
        var ll = LevelTrack.indexToString(Application.loadedLevel);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 20, 0), 1f);
        if (ll.Equals("Forest3D"))
        {
            if (transform.position.x < -12.7f)
                transform.position = new Vector3(-12.7f, transform.position.y, transform.position.z);
            if (transform.position.x > 13.9f)
                transform.position = new Vector3(13.9f, transform.position.y, transform.position.z);
            if (transform.position.z > 9.8f)
                transform.position = new Vector3(transform.position.x, transform.position.y, 9.8f);
            if (transform.position.z < -10.1f)
                transform.position = new Vector3(transform.position.x, transform.position.y, -10.1f);
        }
    }
}