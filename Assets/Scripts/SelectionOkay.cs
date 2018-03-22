using UnityEngine;

public class SelectionOkay : MonoBehaviour
{
    public static string numberBought;
    public static int amount;
    private GUIText gt;

    private void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        amount = textboxMoney.number;
    }

    private void Update()
    {
        amount = textboxMoney.number;
        if (textbox2.selection != 6)
        {
            transform.position = new Vector3(0, 0, 5);
        }
        else
        {
            transform.position = new Vector3(3.08f, -2.039f, -2);
            if (Input.GetKey(KeyCode.Space))
            {
                textbox2.selection = 1;
                MoneyCounter.reduceAmt(amount);
                numberBought = gt.text;
                WinningNumber.generateNum();
                GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Phone");
            }
        }
    }
}