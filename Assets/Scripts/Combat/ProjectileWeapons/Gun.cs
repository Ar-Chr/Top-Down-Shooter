using System;
using UnityEngine;

[Serializable]
public class Gun
{
    [SerializeField] private GunStats gunStats;

    public GunStats GunStats => gunStats;
}
