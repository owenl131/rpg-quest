using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public Sprite mouseOver;
    private Sprite normal;
    private PhoneMapSetter pms;
    private Vector3 pos;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        normal = sr.sprite;
        pms = GameObject.Find("Map").GetComponent<PhoneMapSetter>();
    }

    private void Update()
    {
    }

    private void OnMouseEnter()
    {
        sr.sprite = mouseOver;
    }

    private void OnMouseExit()
    {
        sr.sprite = normal;
    }

    private void OnMouseDown()
    {
        //selected
        if (gameObject.name.Equals("MapButton"))
        {
            Debug.Log("Map pressed");
            pms.hide();
            pms.set();
        }
        if (gameObject.name.Equals("HelpButton"))
        {
            Debug.Log("Help pressed");
            pms.hide();
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("Instructions_1");
        }
        if (gameObject.name.Equals("4DButton"))
        {
            pms.hide();
            GameObject.Find("ScreenFader").GetComponent<ScreenFader>().fade("4D");
        }
        if (gameObject.name.Equals("StatusButton"))
        {
            Debug.Log("quest pressed");
            pms.hide();
            var x = QuestStatus.questIndex;
            if (x != -1)
            {
                pms.showQuest();
            }
        }
        if (gameObject.name.Equals("CloseButton"))
        {
            Debug.Log("close pressed");
            pms.hide();
            GameObject.FindGameObjectWithTag("Fader")
                .GetComponent<ScreenFader>()
                .fade(GameObject.Find("Phone").GetComponent<PhoneIcon>().getPrevLevel());
        }
    }
}