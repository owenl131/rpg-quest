using UnityEngine;

public class BossStoneController : MonoBehaviour
{
    private int count;
    private Rigidbody rb;

    private void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        count++;
        if (count > 200) Destroy(transform.gameObject);
        rb.velocity = Vector3.Normalize(rb.velocity)*Time.deltaTime*200f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.name == "BossStone")
        {
            Destroy(transform.gameObject);
            GameObject.Find("HealthBar").GetComponent<HealthBar>().reduceHealth();
        }
        else if (other.tag == "AhLong" && gameObject.name == "PlayerStone")
        {
            Destroy(transform.gameObject);
            GameObject.Find("BossHealthBar").GetComponent<BossHealthBar>().reduceHealth();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.name == "PlayerStone" && other.gameObject.name == "PlayerRangeSphere")
            Destroy(gameObject);
        if (gameObject.name == "BossStone" && other.gameObject.name == "BossRangeSphere")
            Destroy(gameObject);
    }
}