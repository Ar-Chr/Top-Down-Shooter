using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInventoryTA : TriggerAction<GameObject>
{
    [SerializeField] private TriggerActionComposite<Inventory> inventoryActions;

    public override void Execute(GameObject gameObject)
    {
        if (!gameObject.TryGetComponent(out Inventory inventory))
            return;

        inventoryActions.Execute(inventory);
    }
}
