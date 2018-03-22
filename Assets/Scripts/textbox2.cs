using UnityEngine;

public class textbox2 : MonoBehaviour
{
    public static int selection = 1, temp1, temp2, temp3, temp4;
    public GUIText gt;
    public bool right, left, up, down;
    public string text;
    // Use this for initialization
    private void Start()
    {
        temp1 = 0;
        temp2 = 0;
        temp3 = 0;
        temp4 = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!right)
            {
                if (selection != 6)
                    selection++;
                else
                    selection = 1;
            }
            right = true;
        }
        else
            right = false;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!left)
            {
                if (selection != 1)
                    selection--;
                else
                    selection = 6;
            }
            left = true;
        }
        else
            left = false;
        if (selection != 5 && selection != 6)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!up)
                {
                    if (selection == 1)
                    {
                        if (temp1 != 9)
                            temp1++;
                        else
                            temp1 = 0;
                    }
                    if (selection == 2)
                    {
                        if (temp2 != 9)
                            temp2++;
                        else
                            temp2 = 0;
                    }
                    if (selection == 3)
                    {
                        if (temp3 != 9)
                            temp3++;
                        else
                            temp3 = 0;
                    }
                    if (selection == 4)
                    {
                        if (temp4 != 9)
                            temp4++;
                        else
                            temp4 = 0;
                    }
                }
                up = true;
            }
            else
                up = false;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!down)
                {
                    if (selection == 1)
                    {
                        if (temp1 != 0)
                            temp1--;
                        else
                            temp1 = 9;
                    }
                    if (selection == 2)
                    {
                        if (temp2 != 0)
                            temp2--;
                        else
                            temp2 = 9;
                    }
                    if (selection == 3)
                    {
                        if (temp3 != 0)
                            temp3--;
                        else
                            temp3 = 9;
                    }
                    if (selection == 4)
                    {
                        if (temp4 != 0)
                            temp4--;
                        else
                            temp4 = 9;
                    }
                }
                down = true;
            }
            else
                down = false;
        }
        update();
    }

    private void update()
    {
        text = temp1 + "      " + temp2 + "       " + temp3 + "      " + temp4;
        gt.GetComponent<GUIText>().text = text;
    }
}