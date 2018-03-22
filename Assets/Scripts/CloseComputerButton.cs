using UnityEngine;

public class CloseComputerButton : MonoBehaviour
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
        if (isColliding)
        {
            var a = GameObject.FindGameObjectsWithTag("listItem");
            for (var i = a.Length - 1; i >= 0; i--)
            {
                Destroy(a[i]);
            }
            GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>().fade("Office");
            Debug.Log("To office");
        }
    }
}