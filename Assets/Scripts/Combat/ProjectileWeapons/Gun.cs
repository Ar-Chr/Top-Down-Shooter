using System;
using UnityEngine;

[Serializable]
public class Gun : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GunStats gunStats;
    [SerializeField] private Transform muzzle;

    private float remainingCooldown;

    private int chamber;
    private int magazine;

    public GunStats GunStats => gunStats;

    private void Update()
    {
        remainingCooldown -= Time.deltaTime;

        if (chamber == 0)
            Chamber();
    }

    public void TryShoot()
    {
        if (chamber == 0)
        {
            DryShoot();
            return;
        }

        if (remainingCooldown > 0)
            return;

        Shoot();
    }

    private void DryShoot()
    {
        
    }

    private void Shoot()
    {
        chamber--;
        remainingCooldown = gunStats.Cooldown;

        Projectile bullet = Instantiate(gunStats.AmmoStats.BulletPrefab, muzzle.position, muzzle.rotation);
        bullet.Initialize(this);
    }

    private void Chamber()
    {
        if (magazine == 0)
            return;        

        magazine--;
        chamber++;
    }

    public void TryReload()
    {
        int roundsLoaded = Mathf.Min(inventory.GetAmmoCount(gunStats.AmmoStats), gunStats.MagazineSize - magazine);
        if (roundsLoaded == 0)
            return;

        inventory.SpendAmmo(gunStats.AmmoStats, roundsLoaded);
        Load(roundsLoaded);
    }

    private void Load(int count)
    {
        magazine += count;
    }
}
