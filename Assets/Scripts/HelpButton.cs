using UnityEngine;

public class HelpButton : MonoBehaviour
{
    private bool isOver;
    private Rect r;
    // Use this for initialization
    private void Start()
    {
        var size = GetComponent<Renderer>().bounds.size;
        var position = transform.position;
        r = new Rect(position.x - size.x/2, position.y - size.y/2, size.x, size.y);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                Debug.Log("Pressed help");
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Instructions_1");
            }
        }
        if (!isOver && r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isOver = true;
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        if (isOver && !r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            isOver = false;
            transform.localScale -= new Vector3(0.1f, 0.1f, 0);
        }
    }
}