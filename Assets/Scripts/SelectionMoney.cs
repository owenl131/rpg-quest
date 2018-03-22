using UnityEngine;

public class SelectionMoney : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (textbox2.selection != 5)
            transform.position = new Vector3(0, 0, 5);
        else
            transform.position = new Vector3(0.982f, -2.07f, -1);
    }
}