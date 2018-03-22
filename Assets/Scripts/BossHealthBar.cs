using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    private float barDisplay;
    public int currHealth = 20;
    public GUIStyle gs;
    private Vector2 pos;
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;
    private Vector2 size;
    public int totalHealth = 20;
    private bool won;

    private void Start()
    {
        pos = new Vector2(50, 100);
        size = new Vector2(200, 40);
        barDisplay = 1;
    }

    private void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y + 50.0f));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);
        GUI.Label(new Rect(0, 30.0f, size.x, size.y + 50.0f), "    Boss: " + currHealth/2 + "/" + totalHealth/2, gs);
        GUI.BeginGroup(new Rect(0, 0, size.x*barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);


        GUI.EndGroup();
        GUI.EndGroup();
    }

    private void Update()
    {
        barDisplay = (float) currHealth/totalHealth;
        if (currHealth < 1 && !won)
        {
            won = true;
            MoneyCounter.addAmt(3000);
            DayCounter.reduceDays();
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("CompleteQuest");
        }
    }

    public void reduceHealth()
    {
        currHealth--;
    }
}