using System;
using System.Collections.Generic;
using UnityEngine;
public class Projectile : MonoBehaviour
{
    public event Action<RaycastHit> OnHit;

    [SerializeField] private LayerMask layerMask;

    private Gun gun;

    private new Transform transform;

    private Vector3 velocity;
    private Vector3 prevPosition;

    private HashSet<Health> healthsHit;

    public void Initialize(Gun gun)
    {
        this.gun = gun;
        float muzzleVelocity = gun.GunStats.TotalMuzzleVelocity;
        velocity = transform.forward * muzzleVelocity;
        Destroy(gameObject, CombatUtility.GetProjectileLifetime(muzzleVelocity));
    }

    private void Awake()
    {
        transform = base.transform;
        prevPosition = transform.position;
        healthsHit = new HashSet<Health>();
    }

    private void FixedUpdate()
    {
        Move();
        CheckHit();

        prevPosition = transform.position;
    }

    private void Move()
    {
        float time = Time.deltaTime;

        Vector3 movement =
            velocity * time +
            Physics.gravity * time * time / 2;

        transform.position += movement;
    }

    private void CheckHit()
    {
        if (gun.GunStats.AmmoStats.Radius == 0)
        {
            if (Physics.Linecast(prevPosition, transform.position, out RaycastHit hit, layerMask))
            {
                Hit(hit);
            }
        }
        else
        {
            Vector3 direction = transform.position - prevPosition;
            if (Physics.SphereCast(prevPosition, gun.GunStats.AmmoStats.Radius, direction, out RaycastHit hit, direction.magnitude, layerMask))
            {
                Hit(hit);
            }
        }
    }

    private void Hit(RaycastHit hit)
    {
        if (hit.collider.gameObject.TryGetComponent(out Health health))
        {
            if (!healthsHit.Contains(health))
            {
                health.TakeDamage(gun.GunStats.TotalDamage);
                healthsHit.Add(health);
            }
        }
        OnHit?.Invoke(hit);
    }
}