using UnityEngine;

public class UpDownButtons4D : MonoBehaviour
{
    public static int[] temp;
    public static string playerNum;
    public int buttonNum;
    public GUIText gt;

    // Use this for initialization
    private void Start()
    {
        temp = new[] { 0, 0, 0, 0 };
    }

    private void OnMouseDown()
    {
        if (buttonNum == 1 || buttonNum == 2 || buttonNum == 3 || buttonNum == 4)
        {
            if (temp[buttonNum - 1] != 9)
                temp[buttonNum - 1]++;
            else
                temp[buttonNum - 1] = 0;
        }
        else
        {
            if (temp[buttonNum - 5] != 0)
                temp[buttonNum - 5]--;
            else
                temp[buttonNum - 5] = 9;
        }
        update();
    }

    private void update()
    {
        playerNum = "" + temp[0] + temp[1] + temp[2] + temp[3];
        var text = temp[0] + "      " + temp[1] + "       " + temp[2] + "      " + temp[3];
        gt.text = text;
    }
}