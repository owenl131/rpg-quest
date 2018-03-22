using UnityEngine;

public class MoneyUpDown4D : MonoBehaviour
{
    public static int betAmt;
    public int buttonNum;
    public GUIText gt;

    // Use this for initialization
    private void Start()
    {
        betAmt = 10;
    }

    private void OnMouseDown()
    {
        if (buttonNum == 1)
        {
            if (betAmt < MoneyCounter.getAmt())
                betAmt += 10;
        }
        else
        {
            if (betAmt > 10)
                betAmt -= 10;
        }
        gt.text = betAmt + "";
    }
}