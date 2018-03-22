using UnityEngine;

public class Quest5Bins : MonoBehaviour
{
    private bool check;
    private Quest5Controller controller;
    private bool isOver;
    private Rect r;

    private void Start()
    {
        check = false;
        isOver = false;
    }

    private void Update()
    {
        if (check)
        {
            var size = GetComponent<Renderer>().bounds.size;
            var position = transform.position;
            r = new Rect(position.x - size.x/2, position.y - size.y/2, size.x, size.y);
            if (Input.GetMouseButtonDown(0))
            {
                if (r.Contains(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    controller.selectionMade(gameObject.name);
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

    public void setCheck(Quest5Controller controller, bool check)
    {
        this.controller = controller;
        this.check = check;
    }
}