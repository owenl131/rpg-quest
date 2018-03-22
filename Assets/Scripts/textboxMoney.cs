using UnityEngine;

public class textboxMoney : MonoBehaviour
{
    public static int number = 10;
    public GUIText gt;
    public string text;
    public bool up, down;

    private void Update()
    {
        if (textbox2.selection == 5)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!up)
                {
                    number += 10;
                }
                up = true;
            }
            else
                up = false;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!down)
                {
                    if (number != 10)
                        number -= 10;
                }
                down = true;
            }
            else
                down = false;
        }
        else
            transform.position = new Vector3(0.982f, -2.07f, -1);
        update();
    }

    private void update()
    {
        text = number + "";
        gt.GetComponent<GUIText>().text = text;
    }
}