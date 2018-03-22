using System;
using UnityEngine;

public class MoveToPoint1 : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 destination;
    private int index;
    public Transform[] point = new Transform[3];
    public Transform point1;
    public Transform point2;
    public Transform point3;
    // Use this for initialization
    private void Start()
    {
        point[0] = point1;
        point[1] = point2;
        point[2] = point3;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        destination = point[index].position;
        agent.destination = destination;
        if (equal(transform.position, destination))
        {
            index++;
            index = index%3;
        }
    }

    public bool equal(Vector3 v1, Vector3 v2)
    {
        if (Math.Abs(v1.x - v2.x) < 0.01 && Math.Abs(v1.z - v2.z) < 0.01)
            return true;
        return false;
    }
}