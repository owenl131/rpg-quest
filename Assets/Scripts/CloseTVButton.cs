using UnityEngine;

public class CloseTVButton : MonoBehaviour
{
    private bool isColliding;

    private void OnMouseEnter()
    {
        var close2 = GameObject.Find("CloseButton2");
        close2.transform.position = new Vector3(close2.transform.position.x, close2.transform.position.y, 0);
        isColliding = true;
    }

    private void OnMouseExit()
    {
        var close2 = GameObject.Find("CloseButton2");
        close2.transform.position = new Vector3(close2.transform.position.x, close2.transform.position.y, -20);
        isColliding = false;
    }

    private void OnMouseUp()
    {
        GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Home");
    }
}