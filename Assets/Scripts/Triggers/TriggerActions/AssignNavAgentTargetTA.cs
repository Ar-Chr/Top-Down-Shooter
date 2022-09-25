using UnityEngine;

public class AssignNavAgentTargetTA : TriggerAction<GameObject>
{
    [SerializeField] Transform target;

    public override void Execute(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out AgentMoveToTarget agent))
            return;

        agent.SetTarget(target);
    }
}
