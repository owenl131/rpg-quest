using UnityEngine;

public class Quest1Character : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return;
        Debug.Log("Collided Quest1");
        GameObject.Find("Darkness").GetComponent<GUITexture>().enabled = false;
        GameObject.Find("BackgroundQuest1").transform.position = new Vector3(Camera.main.transform.position.x, 0,
            Camera.main.transform.position.z);
        Time.timeScale = 0;
        Camera.main.orthographicSize = 1.5f;
        GameObject.Find("TextboxQuest1").GetComponent<TextboxQuest1>().showBox();
    }
}