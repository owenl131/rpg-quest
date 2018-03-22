using UnityEngine;

public class ShowLose : MonoBehaviour
{
    public GUIText gt;
    public string text;
    // Update is called once per frame

    private void update()
    {
        gt.GetComponent<GUIText>().text = text;
    }
}