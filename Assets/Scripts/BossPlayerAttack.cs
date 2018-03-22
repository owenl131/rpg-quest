using UnityEngine;

public class BossPlayerAttack : MonoBehaviour
{
    private int count;
    public Texture2D manaEmpty;
    public Texture2D manaFull;
    private Vector2 manaPos;
    private Vector2 manaSize;
    public Transform pPos;
    public Sprite s;

    // Update is called once per frame
    private void Start()
    {
        count = 0;
        if (s == null) s = Resources.Load("Stone", typeof (Sprite)) as Sprite;
        manaPos = new Vector2(20, 300);
        manaSize = new Vector2(50, 200);
    }

    private void OnGUI()
    {
        if (Time.timeScale.Equals(1.0f))
        {
            GUI.BeginGroup(new Rect(manaPos.x, manaPos.y, manaSize.x, manaSize.y + 50.0f));
            GUI.Box(new Rect(0, 0, manaSize.x, manaSize.y), manaEmpty);
            GUI.BeginGroup(new Rect(0, manaSize.y*(1.0f - count/500.0f), manaSize.x, manaSize.y*(count/500.0f)));
            GUI.Box(new Rect(0, 0, manaSize.x, manaSize.y), manaFull);
            GUI.EndGroup();
            GUI.EndGroup();
        }
    }

    private void Update()
    {
        if (count < 500)
            count++;
        if (Input.GetKeyDown(KeyCode.Space) && count >= 500)
        {
            shoot(transform.position + new Vector3(1, 0, 0));
            shoot(transform.position + new Vector3(0, 0, 1));
            shoot(transform.position + new Vector3(-1, 0, 0));
            shoot(transform.position + new Vector3(0, 0, -1));
            shoot(transform.position + new Vector3(1, 0, 1));
            shoot(transform.position + new Vector3(-1, 0, -1));
            shoot(transform.position + new Vector3(-1, 0, 1));
            shoot(transform.position + new Vector3(1, 0, -1));
        }
        if (Input.GetMouseButtonDown(0) && count > 40)
        {
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.y = 0;
            count = 0;
            shoot(worldPos);
        }
    }

    private void shoot(Vector3 pos)
    {
        var g = new GameObject("PlayerStone");
        g.gameObject.tag = "stone";
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
        rb.velocity = Vector3.Normalize(pos - transform.position)*Time.deltaTime*stoneSpeed;
        g.AddComponent<BossStoneController>();
        count = 0;
    }

    public float distance(Vector3 v)
    {
        return Mathf.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
    }
}