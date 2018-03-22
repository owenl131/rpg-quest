using UnityEngine;

public class Selection : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (textbox2.selection == 1)
            transform.position = new Vector3(-2.35f, 0.34f, -1);
        if (textbox2.selection == 2)
            transform.position = new Vector3(-0.84f, 0.34f, -1);
        if (textbox2.selection == 3)
            transform.position = new Vector3(0.673f, 0.34f, -1);
        if (textbox2.selection == 4)
            transform.position = new Vector3(2.179f, 0.34f, -1);
        if (textbox2.selection == 5)
            transform.position = new Vector3(0, 0, 5);
    }
}