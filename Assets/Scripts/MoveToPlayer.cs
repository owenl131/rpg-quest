using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination;
    // Use this for initialization
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = destination.position;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.destination = destination.position;
    }
}