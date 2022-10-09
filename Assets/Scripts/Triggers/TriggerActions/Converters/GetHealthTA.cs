using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHealthTA : TriggerAction<GameObject>
{
    [SerializeField] TriggerActionComposite<Health> healthActions;

    public override void Execute(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out Health health))
            return;

        healthActions?.Execute(health);
    }
}
