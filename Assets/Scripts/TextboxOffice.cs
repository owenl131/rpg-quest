using UnityEngine;

public class TextboxOffice : MonoBehaviour
{
    public Camera cam;
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 1.4f, transform.position.z);
    }
}