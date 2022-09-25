using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Gun Stats", fileName = "GunStats")]
public class GunStats : ScriptableObject
{
    [SerializeField] private AmmoStats ammoStats;
    [SerializeField] private float muzzleVelocityModifier = 1;
    [SerializeField] private float cooldown;

    public AmmoStats AmmoStats => ammoStats;
    public float MuzzleVelocityModifier => muzzleVelocityModifier;
    public float TotalMuzzleVelocity => ammoStats.MuzzleVelocity * muzzleVelocityModifier;
    public float TotalDamage => ammoStats.Damage * muzzleVelocityModifier;
    public float Cooldown => cooldown;
}
