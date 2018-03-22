using UnityEngine;

public class textbox3 : MonoBehaviour
{
    public GUIText gt;
    private bool hidden = true;
    public int results;
    public string text1;
    public string text2;

    private void Start()
    {
        /*text1 = "\t\t\t\t\t Game Over\n\n" +
               "You ran out of time to repay your debts!\n" +
                "As you've experienced in our game,\n" +
                "it is not easy to clear the debts\n" +
                "from gambling!\n\n" +
                "Remember that addiction to gambling\n" +
                "can start at an early age, from\n" +
                "the little things such as playing \n" +
                "with a slot machine on your phone.\n" +
                "Even when you bet with small amounts\n" +
                "in 4D, remember that it is still gambling!";

        text2 = "\t\t\t\t\t Game Over\n\n" +
                "We hope you have enjoyed our game! \n" +
                "As you've experienced in our game,\n" +
                "it is not easy to clear the debts\n" +
                "from gambling!\n\n" +
                "Remember that addiction to gambling\n" +
                "can start at an early age, from\n" +
                "the little things such as playing \n" +
                "with a slot machine on your phone\n" +
                "Even when you bet with small amounts\n" +
                "in 4D, remember that it is still gambling!";*/

        text1 = "\t\t\t\t\t Game Over\n\n" +
                "You ran out of time to repay your debts! \n" +
                "As you've experienced in our game,\n" +
                "it is not easy to clear debts incurred from gambling.\n\n" +
                "Bob later put in this 200% in order to earn enough to repay his debts\n" +
                "He would like to enforce that gambling\n" +
                "is not always dangerous, but it is\n" +
                "when the high risks come into play.\n" +
                "It's all about the Time, Money, \n" +
                "Energy and Motivation.";

        text2 = "\t\t\t\tGame Over\n\n" +
                "We hope you've enjoyed our game! As you've experienced in our game,\n" +
                "it is not easy to clear debts incurred from gambling.\n\n" +
                "Bob later designed many creative campaigns, \n" +
                "games and apps to combat problem gambling,\n" +
                "but has yet to release them to the public.\n" +
                "He would like to enforce that gambling\n" +
                "is not always dangerous, but it is\n" +
                "when the high risks come into play.\n" +
                "It's all about the Time, Money, \n" +
                "Energy and Motivation.";

        if (MoneyCounter.getResult())
            results = 0;
        else
            results = 1;
    }

    public void show()
    {
        hidden = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (hidden)
        {
            gt.GetComponent<GUIText>().text = "";
            return;
        }
        //if gameover
        if (results == 1)
        {
            gt.GetComponent<GUIText>().text = text1;
        }
        //if endgame
        else
        {
            gt.GetComponent<GUIText>().text = text2;
        }
    }
}