using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveAmmoTA : TriggerAction<Inventory>
{
    [SerializeField] private AmmoStats ammoStats;
    [SerializeField] private int ammoCount;

    public override void Execute(Inventory inventory)
    {
        inventory.TakeAmmo(ammoStats, ammoCount);
    }
}
