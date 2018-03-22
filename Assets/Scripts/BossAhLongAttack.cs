using UnityEngine;

public class BossAhLongAttack : MonoBehaviour
{
    private int count;
    public Transform pPos;
    public Sprite s;
    // Update is called once per frame
    private void Start()
    {
        count = 0;
        if (s == null) s = Resources.Load("Stone", typeof (Sprite)) as Sprite;
    }

    private void Update()
    {
        count++;
        if (pPos && count > 100)
        {
            if (distance(transform.position - pPos.position) < 4.0f)
            {
                var g = new GameObject("BossStone");
                g.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                g.transform.eulerAngles = new Vector3(90, 0, 0);
                g.transform.position = transform.position;
                g.AddComponent<SpriteRenderer>();
                g.GetComponent<SpriteRenderer>().sprite = s;
                g.GetComponent<SpriteRenderer>().sortingOrder = 30;
                g.AddComponent<BoxCollider>();
                g.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
                g.GetComponent<BoxCollider>().size = new Vector3(1.28f, 1.28f, 0);
                g.GetComponent<BoxCollider>().isTrigger = true;
                g.AddComponent<Rigidbody>();
                var rb = g.GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = false;
                var stoneSpeed = 200f;
                rb.velocity = Vector3.Normalize(pPos.position - transform.position)*Time.deltaTime*stoneSpeed;
                g.AddComponent<BossStoneController>();
                count = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            for (var i = 0; i < 2; i++)
                GameObject.Find("HealthBar").GetComponent<HealthBar>().reduceHealth();
    }

    public float distance(Vector3 v)
    {
        return Mathf.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
    }
}