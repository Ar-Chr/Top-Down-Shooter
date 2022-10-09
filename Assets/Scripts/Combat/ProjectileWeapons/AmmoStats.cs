using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Ammo Stats", fileName = "AmmoStats")]
public class AmmoStats : ScriptableObject
{
    [SerializeField] private float muzzleVelocity;
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private Projectile bulletPrefab;
    [SerializeField] private Sprite icon;

    public float MuzzleVelocity => muzzleVelocity;
    public float Damage => damage;
    public float Radius => radius;
    public Projectile BulletPrefab => bulletPrefab;
    public Sprite Icon => icon;
}
