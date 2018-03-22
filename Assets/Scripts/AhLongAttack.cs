using UnityEngine;

public class AhLongAttack : MonoBehaviour
{
    private int count;
    public Transform pPos;
    // Update is called once per frame
    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        count++;
        if (pPos && count > 100)
        {
            if (distance(transform.position - pPos.position) < 1.5)
            {
                var s = Resources.Load("Stone", typeof (Sprite)) as Sprite;
                var g = new GameObject("Stone");
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
                g.AddComponent<StoneController>();
                count = 0;
            }
        }
    }

    public float distance(Vector3 v)
    {
        return Mathf.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
    }
}