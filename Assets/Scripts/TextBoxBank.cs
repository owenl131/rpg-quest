using UnityEngine;

public class TextBoxBank : MonoBehaviour
{
    private static int balance;
    private int count;
    public Font f;
    public GUIText gt;
    private bool hidden;
    private int index;
    private string[] options;
    private string[] text;

    private void Start()
    {
        gt.transform.position = new Vector3(0.05f, 0.22f, 0);
        hidden = true;
        gt.font = f;
        gt.fontSize = 31;
        gt.color = Color.black;
        text = new string[10];
        options = new string[10];
        index = 0;
        text[0] =
            "Receptionist: Welcome to Gamblers only Savings Bank (GOSB)!\nPress:\t1) Deposit\t\t2) Withdraw\t\t3) Check balance\t\t4) Close";
        options[0] = "Select amount to deposit: \n1) $100\t\t2) $500\t\t3) $2000\t\t4) All money on hand";
        options[1] = " deposited!";
        options[5] = "Select amount to withdrawn: \n1) $100\t\t2) $500\t\t3) $2000\t\t4) All money in account";
        options[6] = " withdrawn!";
        balance = 0;
    }

    public static void reset()
    {
        balance = 0;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    public void showBox()
    {
        if (count > 20 && hidden)
        {
            index = 0;
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                0);
            hidden = false;
            GetComponent<SpriteRenderer>().enabled = true;
            Time.timeScale = 0;
        }
    }

    public static int getBalance()
    {
        return balance;
    }

    public void hideBox()
    {
        if (!hidden)
        {
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 1.4f,
                -20);
            gt.text = "";
            Time.timeScale = 1;
            GetComponent<SpriteRenderer>().enabled = false;
            hidden = true;
            count = 0;
        }
    }

    private void Update()
    {
        if (!hidden)
        {
            gt.text = text[index];
            if (index == 0)
            {
                var x = getInput();
                if (x.Equals(""))
                    return;
                if (x.Equals("1"))
                {
                    text[1] = options[0];
                    text[2] = options[1];
                    index = 1;
                }
                if (x.Equals("2"))
                {
                    text[3] = options[5];
                    text[4] = options[6];
                    index = 3;
                }
                if (x.Equals("3"))
                {
                    text[5] = "The amount of money in your account is $" + balance + ".";
                    index = 5;
                }
                if (x.Equals("4"))
                {
                    hideBox();
                }
            }
            else if (index == 1)
            {
                var x = getInput();
                if (x.Equals(""))
                    return;
                if (x.Equals("1"))
                    deposit(100);
                if (x.Equals("2"))
                    deposit(500);
                if (x.Equals("3"))
                    deposit(2000);
                if (x.Equals("4"))
                    deposit(MoneyCounter.getAmt());
                index++;
            }
            else if (index == 3)
            {
                var x = getInput();
                if (x.Equals(""))
                    return;
                if (x.Equals("1"))
                    withdraw(100);
                if (x.Equals("2"))
                    withdraw(500);
                if (x.Equals("3"))
                    withdraw(2000);
                if (x.Equals("4"))
                    withdraw(balance);
                index++;
            }
            if (index == 5 || index == 2 || index == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    hideBox();
                }
            }
        }
        else
            count++;
    }

    public void interest()
    {
        double a = balance;
        a *= 1.01;
        balance = (int) a;
    }

    private int deposit(int x)
    {
        if (MoneyCounter.getAmt() < x)
            x = MoneyCounter.getAmt();
        balance += x;
        MoneyCounter.reduceAmt(x);
        text[2] = "$" + x + text[2];
        return x;
    }

    private int withdraw(int x)
    {
        if (balance < x)
            x = balance;
        balance -= x;
        MoneyCounter.addAmt(x);
        text[4] = "$" + x + text[4];
        return x;
    }

    private string getInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            return "1";
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            return "2";
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            return "3";
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
            return "4";
        return "";
    }
}