using UnityEngine;

public class OkayButton4D : MonoBehaviour
{
    public static string numberBought;
    public GUIText gt;

    private void OnMouseDown()
    {
        MoneyCounter.reduceAmt(MoneyUpDown4D.betAmt);
        numberBought = gt.text;
        WinningNumber.generateNum();
        GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Phone");
    }
}