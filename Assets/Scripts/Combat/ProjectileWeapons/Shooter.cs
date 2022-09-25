using R60N.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Coggers
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private new Transform transform;
        [SerializeField] private Transform muzzle;
        [SerializeField] private Transform aimPoint;
        [SerializeField] private Input input;
        [SerializeField] private Gun gun;

        private float remainingCooldown;

        private void Update()
        {
            remainingCooldown -= Time.deltaTime;

            if (input.Shoot)
                TryShoot();
        }

        private void TryShoot()
        {
            if (remainingCooldown > 0)
                return;

            remainingCooldown = gun.GunStats.Cooldown;
            Shoot();
        }

        private void Shoot()
        {
            Quaternion lookRotation = Quaternion.LookRotation((aimPoint.position - transform.position).WithY(0));
            Projectile bullet = Instantiate(gun.GunStats.AmmoStats.BulletPrefab, muzzle.position, lookRotation);
            bullet.Initialize(gun);
        }
    }
}
