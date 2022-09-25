using UnityEngine;
using UnityEngine.AI;

public class AgentMoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private void Update()
    {
        if (target != null)
            agent.SetDestination(target.position);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}