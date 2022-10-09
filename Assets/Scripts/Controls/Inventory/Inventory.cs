using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public event Action AmmoChanged;

    [SerializeField] private List<Item> ammo;

    public int GetAmmoCount(AmmoStats ammoType)
    {
        return FindItem(ammoType).Count;
    }

    public void TakeAmmo(AmmoStats ammoType, int value)
    {
        if (value < 0)
            return;

        FindItem(ammoType).Count += value;
        AmmoChanged?.Invoke();
    }

    public void SpendAmmo(AmmoStats ammoType, int value)
    {
        if (value < 0)
            return;

        FindItem(ammoType).Count -= value;
        AmmoChanged?.Invoke();
    }

    private Item FindItem(AmmoStats ammoType)
    {
        return ammo.Find(item => item.AmmoType == ammoType);
    }
}

[Serializable]
public class Item
{
    public AmmoStats AmmoType;
    public int Count;
}