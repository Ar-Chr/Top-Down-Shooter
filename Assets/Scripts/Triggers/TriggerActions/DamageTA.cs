using UnityEngine;

public class DamageTA : TriggerAction<Health>
{
    [SerializeField] int damage = 10;

    public override void Execute(Health health)
    {
        health.TakeDamage(damage);
    }
}
