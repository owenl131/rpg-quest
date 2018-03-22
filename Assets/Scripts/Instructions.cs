using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Font font;
    private GUIText gt;

    public int index;

    private void Start()
    {
        transform.position = new Vector3(0.5f, 0.45f, 0);
        gt = GetComponent<GUIText>();
        gt.alignment = TextAlignment.Center;
        gt.font = font;
        gt.fontSize = 24;
        gt.anchor = TextAnchor.MiddleCenter;
        gt.color = Color.white;
        var s = "";
        if (index == 1)
        {
            s += "Storyline: \n";
            s += "Bob, a Problem Gambler, has made a firm resolve to stop gambling, \n";
            s += "but unfortunately, the story doesn't end here.\n";
            s += "His debt has escalated and needs to be repaid urgently.\n";
            s += "Join him as he struggles to find a job (hopefully) to earn money, \n";
            s += "trying to change the fate he himself created.\n";
            s += "Within these " + GameProperties.deadline + " days, \n";
            s += "armed with your prefrontal cortex and your strong judgement, \n";
            s += "will you be able to pull Bob out of the darkness?\n";
            s += "Can you fix it?";
        }
        if (index == 2)
        {
            s += "Quests: \n";
            s += "The quests are the main element of gameplay and your main source of income.\n";
            s += "They range in difficulties and rewards, so choose carefully.\n";
            s += "To select a quest, click on it on the computer in your office.\n";
            s += "A quest selected is a contract signed, so choose carefully!\n";
            s += "You may only take one quest at a time, the last clicked quest would be the one you embark on.\n";
            s += "Check your handphone to access the current quest details.\n";
            s += "Good luck on your quest to Recovery from Pathological Gambling!\n";
        }
        if (index == 3)
        {
            s += "Places: \n";
            s += "Home: \nYour spawning point. Sleep there to pass a day, or check out the 4D results on your TV.\n";
            s += "Town: \nFeel free to explore the town and visit the other buildings.\n";
            s +=
                "Casino: \nNeed extra cash? We've got just the place for you, \nat Juicy Stakes Casino. Do so at your own risk!\n";
            s += "Office: \nCheck the computer in the office to accept quests.\n\n";
            s +=
                "Counselling centre: \nNeed help in your journey? Visit the counselling centre! \nWatch out for events too.\n";
            s += "Bank: \nStore your money safely in GOSB (Gamblers only Savings Bank)!";
        }
        if (index == 4)
        {
            s += "Others: \n";
            s += "Notes: Collect notes found in the forest and dungeon to reveal a bit of your forgotten history.\n";
            s += "4D: Accessible from your phone, the 4D online is a reliable source of income. (Source: 4D4life Co.)\n";
            s += "Slot machines: Found in casino. Stakes are juicy, but odds are uneven.\n";
            s +=
                "Phone: Icon found on the right of the screen. Check the map for bearings, get help and see selected quest details.\n";
            s += "Posters: Feeling tired? Read the appealing posters to strengthen your resolve.\n";
            s +=
                "NPCs: Multiple NPCs standing around, appearing to mind their own business, but actually thirsting for conversation.\n";
        }
        if (index == 5)
        {
            s += "Watch out for: \n";
            s +=
                "Ah longs in the forest and dungeon. They might throw stones at you to injure you or take your money from you.\n";
            s += "Your health: You fail a quest if your health reaches 0.\n";
        }
        if (index == 6)
        {
            s += "Are you lost? <Tips>/<FAQs>\n";
            s += "Where should I go at the start of the game?\n";
            s += "Explore the accessible locations to familiarise yourself with the surroundings.\n";
            s += "Or else, go to the office building to get a quest.\n";
            s += "Where should I go for this quest?\n";
            s += "Open your phone (click on the icon on the right of the screen) and select 'Quest'.\n";
            s += "The quest location should be clearly stated there.\n";
            s += "I don't know what to do for this quest?\n";
            s += "Again, read the description on the phone and find the person/go to the place/...\n";
            s += "I give up!\n";
            s +=
                "If you need to escape, for the forest, go back to where you appeared when you entered the forest to leave.\n";
            s += "For the dungeon, go to the spawning location and press the spacebar.\n";
            s += "Note that you cannot continue the quest once you give up on it.\n";
        }
        if (index == 7)
        {
            s += "Controls: ";
            s += "Movement: WASD or Arrow Keys, we know players have different preferences so we are catering to all.\n";
            s +=
                "Textboxes: Press the spacebar to go to the next line, or press the appropriate key when asked to make a decision.\n";
            s += "4D: Click on the up and down arrow buttons to select wager and number to bet on.\n";
            s += "Slot machine: ";
        }
        if (index == 8)
        {
            s += "Objective: Accumulate enough money to repay your debt within the deadline.\n";
            s += "\"May the odds be never in your favour.\" -The Dealer\n";
            s += "When you're ready, dive into the world of problem gamblers.\n";
            s += "Correction: You are already in it. It is reality.\n";
            s += "Off you go on your rPG Quest!\n";
        }


        gt.text = s;
    }
}