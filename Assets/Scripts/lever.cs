using UnityEngine;

public class lever : MonoBehaviour
{
    // Use this for initialization
    public Animator anim;
    private bool check;
    private bool isColliding;
    public scrolling scrolling1One, scrolling1Two;
    public scrolling2 scrolling2One, scrolling2Two;
    public scrolling3 scrolling3One, scrolling3Two;
    public SpriteRenderer sr;
    private int time;

    private void Start()
    {
        anim.speed = 0;
        time = 0;
        check = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (sr.sprite.name == "leverflip_0" && time > 10) //time==44)
        {
            time = 0;
            check = false;
            anim.speed = 0;
        }
        if (check)
            time++;
    }

    private void OnMouseEnter()
    {
        isColliding = true;
    }

    private void OnMouseExit()
    {
        isColliding = false;
    }

    private void OnMouseUp()
    {
        if (isColliding)
        {
            MoneyCounter.reduceAmt(100);
            check = true;
            anim.speed = 1;
            scrolling1One.leverPulled();
            scrolling1Two.leverPulled();
            scrolling2One.leverPulled();
            scrolling2Two.leverPulled();
            scrolling3One.leverPulled();
            scrolling3Two.leverPulled();
        }
    }
}