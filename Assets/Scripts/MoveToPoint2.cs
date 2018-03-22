using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveToPoint2 : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 destination;
    private int index;
    private bool isPaused;
    private int pauseC;
    public GameObject player;
    public Transform[] point = new Transform[20];
    // Use this for initialization
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        index = Random.Range(0, point.Length);
        if (!player) player = GameObject.FindWithTag("Player");
        isPaused = false;
        pauseC = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        destination = point[index].position;
        agent.destination = destination;
        if (isPaused)
        {
            pauseC++;
            if (pauseC > 40)
            {
                isPaused = false;
                pauseC = 0;
            }
            agent.destination = transform.position;
        }
        if (distance(player.transform.position - transform.position) < 1)
        {
            agent.destination = player.transform.position;
        }
        if (equal(transform.position, destination))
        {
            index = Random.Range(0, point.Length);
        }
    }

    public bool equal(Vector3 v1, Vector3 v2)
    {
        if (Math.Abs(v1.x - v2.x) < 0.01 && Math.Abs(v1.z - v2.z) < 0.01)
            return true;
        return false;
    }

    public double distance(Vector3 v)
    {
        return Math.Sqrt(v.x*v.x + v.y*v.y + v.z*v.z);
    }

    public void pause()
    {
        isPaused = true;
    }
}