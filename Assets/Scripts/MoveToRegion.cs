using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveToRegion : MonoBehaviour
{
    private NavMeshAgent agent;
    public int count;
    public Vector3 destination;
    public float maxX;
    public float maxZ;
    public float minX;
    public float minZ;
    public GameObject player;
    private Vector3 prevPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!player) player = GameObject.FindWithTag("Player");
        var posX = Random.Range(minX, maxX);
        var posZ = Random.Range(minZ, maxZ);
        destination = new Vector3(posX, 0, posZ);
        count = 0;
    }

    private void Update()
    {
        if (equal(transform.position, prevPos))
        {
            count++;
        }
        else
        {
            prevPos = transform.position;
            count = 0;
        }
        if (count >= 20)
        {
            var posX = Random.Range(minX, maxX);
            var posZ = Random.Range(minZ, maxZ);
            destination = new Vector3(posX, 0, posZ);
            count = 0;
        }
        agent.destination = destination;
        if (distance(player.transform.position - transform.position) < 2)
        {
            agent.destination = player.transform.position;
        }
        if (equal(transform.position, destination))
        {
            var posX = Random.Range(minX, maxX);
            var posZ = Random.Range(minZ, maxZ);
            destination = new Vector3(posX, 0, posZ);
        }
    }

    public bool equal(Vector3 v1, Vector3 v2)
    {
        if (Math.Abs(v1.x - v2.x) < 0.0001 && Math.Abs(v1.z - v2.z) < 0.0001)
            return true;
        return false;
    }

    public double distance(Vector3 v)
    {
        return Math.Sqrt(v.x*v.x + v.z*v.z);
    }
}