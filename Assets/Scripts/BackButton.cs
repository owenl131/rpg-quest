using UnityEngine;

public class BackButton : MonoBehaviour
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
                var ll = LevelTrack.indexToString(Application.loadedLevel);
                if (ll.Equals("Instructions_1") || ll.Equals("Credits"))
                    Application.LoadLevel(LevelTrack.prevLevel);
                else if (ll.Equals("Instructions_2"))
                    Application.LoadLevel("Instructions_1");
                else if (ll.Equals("Instructions_3"))
                    Application.LoadLevel("Instructions_2");
                else if (ll.Equals("Instructions_4"))
                    Application.LoadLevel("Instructions_3");
                else if (ll.Equals("Instructions_5"))
                    Application.LoadLevel("Instructions_4");
                else if (ll.Equals("Instructions_6"))
                    Application.LoadLevel("Instructions_5");
                else if (ll.Equals("Instructions_7"))
                    Application.LoadLevel("Instructions_6");
                else if (ll.Equals("Instructions_8"))
                    Application.LoadLevel("Instructions_7");
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