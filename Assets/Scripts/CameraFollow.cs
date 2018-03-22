using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position - new Vector3(0, 0, 10), 1f);
        var ll = LevelTrack.indexToString(Application.loadedLevel);
        if (ll.Equals("Town"))
        {
            if (transform.position.x < -3.3)
                transform.position = new Vector3(-3.3f, transform.position.y, -10);
            if (transform.position.x > 4)
                transform.position = new Vector3(4f, transform.position.y, -10);
            if (transform.position.y < -3)
                transform.position = new Vector3(transform.position.x, -3, -10);
            if (transform.position.y > 2.4f)
                transform.position = new Vector3(transform.position.x, 2.4f, -10);
        }
        if (ll.Equals("Office"))
        {
            transform.position = new Vector3(transform.position.x, 0, -10);
            if (transform.position.x < -0.45f)
                transform.position = new Vector3(-0.45f, transform.position.y, -10);
            if (transform.position.x > 0.45f)
                transform.position = new Vector3(0.45f, transform.position.y, -10);
        }
        if (ll.Equals("Casino"))
        {
            if (transform.position.x < 0.3f)
                transform.position = new Vector3(0.3f, transform.position.y, -10);
            if (transform.position.x > 2.1f)
                transform.position = new Vector3(2.1f, transform.position.y, -10);
            if (transform.position.y < -1.2f)
                transform.position = new Vector3(transform.position.x, -1.2f, -10);
            if (transform.position.y > 1.9f)
                transform.position = new Vector3(transform.position.x, 1.9f, -10);
        }
        if (ll.Equals("Home"))
        {
            if (transform.position.x < -0.95f)
                transform.position = new Vector3(-0.95f, transform.position.y, -10);
            if (transform.position.x > 0.95f)
                transform.position = new Vector3(0.95f, transform.position.y, -10);
            if (transform.position.y < -0.4)
                transform.position = new Vector3(transform.position.x, -0.4f, -10);
            if (transform.position.y > 0.36)
                transform.position = new Vector3(transform.position.x, 0.36f, -10);
        }
        if (ll.Equals("CounsellingCentre"))
        {
            transform.position = new Vector3(transform.position.x, -1.92f, -10);
            if (transform.position.x < 2.85f)
                transform.position = new Vector3(2.85f, transform.position.y, -10);
            if (transform.position.x > 3.85f)
                transform.position = new Vector3(3.85f, transform.position.y, -10);
        }
        if (ll.Equals("Bank"))
        {
            if (transform.position.y < -0.35f)
                transform.position = new Vector3(transform.position.x, -0.35f, -10);
            if (transform.position.y > 0.4f)
                transform.position = new Vector3(transform.position.x, 0.4f, -10);
            if (transform.position.x < -0.7f)
                transform.position = new Vector3(-0.7f, transform.position.y, -10);
            if (transform.position.x > 0.22f)
                transform.position = new Vector3(0.22f, transform.position.y, -10);
        }
    }
}