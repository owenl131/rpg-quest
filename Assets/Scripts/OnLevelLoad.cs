using UnityEngine;

public class OnLevelLoad : MonoBehaviour
{
    private void Start()
    {
        var ll = LevelTrack.indexToString(Application.loadedLevel);
        var prev = LevelTrack.indexToString(LevelTrack.prevLevel);
        var player = GameObject.FindWithTag("Player");
        if (ll.Equals("StartPage"))
        {
            Debug.Log("Menu");
            Application.LoadLevel("Menu");
            Debug.Log("Loaded menu");
        }
        if (ll.Equals("Computer"))
        {
            Debug.Log("computer");
            GameObject.Find("Computer").GetComponent<ComputerData>().showScreen();
        }
        if (player == null) return;
        if (ll.Equals("Town"))
        {
            if (prev.Equals("Casino"))
            {
                player.transform.position = new Vector3(3.94f, 1.08f, 0f);
            }
            else if (prev.Equals("Home"))
            {
                player.transform.position = new Vector3(-3.58f, 0.58f, 0f);
            }
            else if (prev.Equals("Office"))
            {
                player.transform.position = new Vector3(4.57f, -3.85f, 0f);
            }
            else if (prev.Equals("Bank"))
            {
                player.transform.position = new Vector3(-1.82f, -2.95f, 0f);
            }
        }
        else if (ll.Equals("Home"))
        {
            if (prev.Equals("Town"))
            {
                player.transform.position = new Vector3(0.28f, -1.84f, 0f);
            }
            else if (prev.Equals("HomeTV"))
            {
                player.transform.position = new Vector3(-1.56f, -1.15f, 0);
            }
            else if (prev.Equals("Sleep"))
            {
                player.transform.position = new Vector3(0.22f, 1.76f, 0);
            }
        }
        else if (ll.Equals("Office"))
        {
            //next level is Office
            if (prev.Equals("Computer"))
            {
                player.transform.position = new Vector3(0.745f, 0.95f, 0);
            }
            if (prev.Equals("CounsellingCentre"))
            {
                player.transform.position = new Vector3(-2.6f, 0.8f, 0);
            }
        }
        else if (ll.Equals("Forest3D") || ll.Equals("Dungeon"))
        {
            if (!prev.Equals("Phone"))
            {
                GameObject.Find("HealthBar").GetComponent<HealthBar>().show();
                GameObject.Find("HealthBar").GetComponent<HealthBar>().reset();
            }
        }
        else if (ll.Equals("Quest7BossBattle"))
        {
            GameObject.Find("HealthBar").GetComponent<HealthBar>().show();
            GameObject.Find("HealthBar").GetComponent<HealthBar>().reset(10);
        }
        else if (ll.Equals("Casino"))
        {
            if (prev.Equals("slotmachine"))
            {
                GameObject.FindWithTag("Player").transform.position = SlotMachineColliders.prevPos;
            }
        }
        if (prev.Equals("Phone"))
        {
            var pi = GameObject.Find("Phone").GetComponent<PhoneIcon>();
            var name = pi.getPrevName();
            var pos = pi.getPrevPos();
            var g = FindObjectsOfType<GameObject>();
            for (var i = 0; i < g.Length; i++)
            {
                for (var j = 0; j < name.Count; j++)
                {
                    if (g[i].gameObject.name.Equals(name[j]))
                        g[i].transform.position = pos[j];
                }
            }
            Debug.Log(player.transform.position.ToString("G4"));
        }
    }
}